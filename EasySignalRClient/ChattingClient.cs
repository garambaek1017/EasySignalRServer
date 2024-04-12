using EasyTestClient.ClientState;
using Protocols.Packets;
using System;
using System.Threading.Tasks;

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

        /// <summary>
        /// 상태 처리용 
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        /// 네트워크 처리 클래스 
        /// </summary>
        public SignalRNetwork Network { get; set; }

        /// <summary>
        /// 유저 닉네임
        /// </summary>
        public string Nickname { get; set; } = string.Empty;

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

        /// <summary>
        /// 실행 함수 
        /// </summary>
        public void Run()
        {
            // 최초 실행 상태, 유저 정보 셋팅 
            Context = new Context(new UserInfoState());

            // 상태에 따라 자기 할일 함 
            while (true)
            {
                Context.Do();
            }
        }

        /// <summary>
        /// 채팅 메시지 받음
        /// </summary>
        /// <param name="sendChatResult"></param>
        public void ReceiveChat(SendChatResult sendChatResult)
        {
            Console.WriteLine($"[{sendChatResult.Sender}]:{sendChatResult.Message}");
        }

        /// <summary>
        /// 브로드 캐스트 메시지 받음 
        /// </summary>
        /// <param name="broadCastPacket"></param>

        public void ReceiveBroadCastMessage(BroadcastPacket broadCastPacket)
        {

            if(string.Equals(broadCastPacket.Sender, Nickname) == true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"[Sender:{broadCastPacket.Sender}]:{broadCastPacket.Message}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[Sender:{broadCastPacket.Sender}]:{broadCastPacket.Message}");
            }

            Console.ForegroundColor = ConsoleColor.White;

            Context.SetState(new ChattingState());
        }

        /// <summary>
        /// 노티 메시지 받음 
        /// </summary>
        /// <param name="notifyPacket"></param>
        public void ReceiveNotifyMessage(NotifyPacket notifyPacket)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Sender:{notifyPacket.NotiMessage}]");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 메시지 전송 
        /// </summary>
        /// <param name="message"></param>
        public void SendChat(string message)
        {
            var req = new SendChat()
            {
                Nickname = Nickname,
                Message = message
            };

            Network.RequestToServer(req);
        }

        /// <summary>
        /// 프로그램 종료 
        /// </summary>
        public void Stop()
        {
            Network.Stop();
            Environment.Exit(0);
        }
    }
}
