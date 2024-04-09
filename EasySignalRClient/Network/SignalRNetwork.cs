using Microsoft.AspNet.SignalR.Client;
using RLog;
using System.Threading.Tasks;
using System;
using Protocols.Packets;

namespace EasyTestClient
{
    public class SignalRNetwork
    {
        #region Network
        public HubConnection HubConnection { get; set; }
        public IHubProxy Proxy { get; set; }
        #endregion

        public SignalRNetwork(string serverEndPoint)
        {
            HubConnection = new HubConnection(serverEndPoint);

            HubConnection.Closed += OnClose;
            HubConnection.Error += OnError;
            HubConnection.Received += OnReceive;
            HubConnection.Reconnected += OnReConnect;

            RegisterProxy();

        }

        public void Connect()
        {
            if(string.IsNullOrEmpty(HubConnection.Url) == true)
            {
                RLogger.Error($"Chatting url is null, check your url");
            }
            else
            {
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
                });
            }
        }

        // 프록시를 등록해서 chathub에 연결 
        void RegisterProxy()
        {
            Proxy = HubConnection.CreateHubProxy("ChatHub");
            
            Proxy.On<SendChatResult>(ChatHubMethodNames.SendChat, ChattingClient.Instance.ReceiveChat);

            Proxy.On<BroadcastPacket>(ChatHubMethodNames.BroadcastMessage, ChattingClient.Instance.ReceiveBroadCastMessage);
            Proxy.On<NotifyPacket>(ChatHubMethodNames.NotifyMessage, ChattingClient.Instance.ReceiveNotifyMessage);
        }

        public void RequestToServer(BasePacket req)
        {
            // 클라 -> 서버로 요청할때 Invoke로 호출 하면 됩니다. 
            Proxy.Invoke(req.MethodName, req);
        }

        public void Stop()
        {
            HubConnection.Stop();
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
