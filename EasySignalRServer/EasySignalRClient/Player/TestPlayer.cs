using Microsoft.AspNet.SignalR.Client;
using Protocols.Packets;
using RLog;
using System;
using System.Threading.Tasks;

namespace EasyTestClient.Player
{
    public enum PlayerState
    {
        None = 0,
        Connect,
        Login,
        SendMessage,
    }

    public partial class TestPlayer
    {
        public PlayerState PlayerState { get; set; }
        public string ChatServerEndPoint { get; set; }
        public string Nickname { get; set; }

        #region Network
        public HubConnection HubConnection { get; set; }
        public IHubProxy Proxy { get; set; }
        #endregion

        public void Connect()
        {
            RLogger.Debug($"try to connect : {ChatServerEndPoint}");

            HubConnection = new HubConnection(ChatServerEndPoint);

            HubConnection.Closed += OnClose;
            HubConnection.Error += OnError;
            HubConnection.Received += OnReceive;
            HubConnection.Reconnected += OnReConnect;

            RegisterProxy();

            HubConnection.Start().ContinueWith((task) =>
            {
                if (task.IsCompleted == true)
                {
                    RLogger.Debug($"> ConnectResult : {task.Status} : {DateTime.Now}");

                    // 연결 성공 여부 판단 
                    if (task.Status == TaskStatus.RanToCompletion)
                    {
                        RLogger.Debug($"> Connection is success");
                    }
                    // 실패
                    else
                        RLogger.Error($"> Connect Error : {task.Exception.GetBaseException().ToString()} : {DateTime.Now}");
                }
            }
            );
        }

        // 프록시를 등록해서 chathub에 연결 
        void RegisterProxy()
        {
            Proxy = HubConnection.CreateHubProxy("ChatHub");
            Proxy.On<BroadCastPacket>(PacketNames.BroadcastMessage, MessageNoitify);
        }

        #region events
        void OnError(Exception e)
        {
            RLogger.Debug($"> Error_message: {e.Message}");
            RLogger.Debug($"> Error_trace: {e.StackTrace}");
        }
        void OnReceive(string data)
        {
        }
        void OnReConnect()
        {
            RLogger.Debug("> Reconnect");
        }
        void OnClose()
        {
            RLogger.Debug("> Connection Close");
        }
        #endregion
    }
}
