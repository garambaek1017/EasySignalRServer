using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Protocols.Packets;
using RLog;
using System;
using System.Threading.Tasks;

namespace EasySignalRServer.Network
{
    [HubName("ChatHub")]
    public partial class ChatHub : Hub
    {
        static string ChatGroupName = "Chat";

        // 커넥션 관리
        public override Task OnConnected()
        {
            RLogger.Debug($"connect client... clientID: {Context.ConnectionId}");

            // 접속시 채팅 그룹에 유저 추가함
            Groups.Add(Context.ConnectionId, ChatGroupName);

            var noti = new NotifyPacket();
            noti.NotiMessage = "Login one User";

            NotifyToAllUser(noti);

            return base.OnConnected();
        }

        // Disconnect 관리 
        public override Task OnDisconnected(bool stopCalled)
        {
            try
            {
                if (stopCalled)
                {
                    RLogger.Debug($"Client {Context.ConnectionId} explicitly closed the connection.");
                }
                else
                {
                    RLogger.Debug($"Client {Context.ConnectionId} timed out .");
                }
            }
            catch (Exception e)
            {
                RLogger.Debug($"{e.Message.ToString()}");
                RLogger.Debug($"{e.StackTrace.ToString()}");
            }

            return base.OnDisconnected(stopCalled);
        }
        
    }
}
