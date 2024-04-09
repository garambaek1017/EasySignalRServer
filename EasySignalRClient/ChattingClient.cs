using Microsoft.AspNet.SignalR.Client;
using Protocols.Packets;
using RLog;
using System;
using System.Collections.Generic;

namespace EasyTestClient
{
    public enum ChattingClientState
    {
        WAIT = 0,

        START = 1,
        SET_NICKNAME = 2,
        CHATTING = 3,
        STOP = 4,
    }

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
        private string Nickname { get; set; }
        private List<string> ChattingLines { get; set; } = new List<string>();
        private SignalRNetwork Network { get; set; }
        private ChattingClientState ClientState { get; set; } = ChattingClientState.START;
        #endregion


        /// <summary>
        /// 네트워크 초기화 
        /// </summary>
        /// <param name="network"></param>
        public void SetNetwork(SignalRNetwork network)
        {
            Network = network;
        }

        public void Run()
        {
            while (true)
            {
                string cmd = Console.ReadLine().ToLower();

                if (ClientState == ChattingClientState.START)
                {
                    ShowLines();
                    ClientState = ChattingClientState.WAIT;
                }
                else if (ClientState == ChattingClientState.WAIT)
                {
                    if (cmd.Contains("nickname") == true || cmd.Contains("1") == true)
                    {
                        RLogger.Info("Input NickName >> ");
                        Nickname = Console.ReadLine();
                        RLogger.Info("Nickname setting is done : " + Nickname);
                    }

                    if (cmd.Contains("connect") == true || cmd.Contains("2") == true)
                    {
                        Network.Connect();
                    }

                    if (cmd.Contains("send") == true || cmd.Contains("3") == true)
                    {
                        ClientState = ChattingClientState.CHATTING;
                    }
                }
                else if(ClientState == ChattingClientState.CHATTING)
                {
                    Console.Write("Input Message >> ");

                    var message = Console.ReadLine();

                    var req = new SendChat()
                    {
                        Nickname = Nickname,
                        Message = message
                    };

                    Network.RequestToServer(req);
                }

                if (cmd.Contains("exit") == true || cmd.Contains("4") == true)
                {
                    Network.Stop();
                }
            }
        }


        public void ReceiveChat(SendChatResult sendChatResult)
        {
            RLogger.Debug($"[{sendChatResult.Sender}]:{sendChatResult.Message}");
        }

        public void ReceiveBroadCastMessage(BroadcastPacket broadCastPacket)
        {
            Console.Clear();
            ChattingLines.Clear();
            SetDefaultLines();

            this.ChattingLines.Add($"{broadCastPacket.Sender}::{broadCastPacket.Message}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            ShowLines();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ReceiveNotifyMessage(NotifyPacket notifyPacket)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            RLogger.Debug($"{notifyPacket.NotiMessage}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // 메뉴 표시 
        public void ShowMenu()
        {
            Console.Clear();
            RLogger.Debug("[1] or [nickname] : 보내는 사람 이름 설정");
            RLogger.Debug("[2] or [connect] : 서버에 연결");
            RLogger.Debug("[3] or [send] : 메시지 보내기");
        }

        public void Start()
        {
            if(ClientState == ChattingClientState.START)
            {
                SetDefaultLines();
            }
        }

        void SetDefaultLines()
        {
            this.ChattingLines.Add("[1] or [nickname] : 보내는 사람 이름 설정");
            this.ChattingLines.Add("[2] or [connect] : 서버에 연결");
            this.ChattingLines.Add("[3] or [send] : 메시지 보내기");
        }

        void ShowLines()
        {
            foreach(var r in ChattingLines)
            {
                RLog.RLogger.Info(r);
            }
        }

    }
}
