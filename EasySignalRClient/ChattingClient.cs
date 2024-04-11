using EasyTestClient.ClientState;
using Protocols.Packets;
using RLog;
using System;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EasyTestClient
{
    public class ChattingClient
    {
        #region Instance
        static ChattingClient m_Instance = new ChattingClient();
        public static ChattingClient Instance
        {
            get { return m_Instance; }
        }
        #endregion

        #region

        public Context Context { get; set; }

        public SignalRNetwork Network { get; set; }

        public string Nickname { get; set; } = string.Empty;
        #endregion

        /// <summary>
        /// 네트워크 초기화 
        /// </summary>
        /// <param name="network"></param>
        public async Task<bool> SetNetworkAndConnection()
        {
            Network = new SignalRNetwork($"http://localhost:2023/");

            var result = await Network.Connect();
            return result;

        }

        public void Run()
        {
            // 최초 실행 상태, 유저 정보 셋팅 
            Context = new Context(new UserInfoState());

            bool isRun = true;
            while (isRun)
            {
                Context.Do();
            }
        }

        public void ReceiveChat(SendChatResult sendChatResult)
        {
            Console.WriteLine($"[{sendChatResult.Sender}]:{sendChatResult.Message}");
        }

        public void ReceiveBroadCastMessage(BroadcastPacket broadCastPacket)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Sender:{broadCastPacket.Sender}]:{broadCastPacket.Message}");
            Console.ForegroundColor = ConsoleColor.White;

            Context.SetState(new ChattingState());
        }

        public void ReceiveNotifyMessage(NotifyPacket notifyPacket)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            RLogger.Debug($"{notifyPacket.NotiMessage}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SendChat(string message)
        {
            var req = new SendChat()
            {
                Nickname = Nickname,
                Message = message
            };

            Network.RequestToServer(req);
        }

        public void Stop()
        {
            Network.Stop();
            Environment.Exit(0);
        }
    }
}
