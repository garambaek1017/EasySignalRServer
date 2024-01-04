using Microsoft.AspNet.SignalR;
using Protocols.Packets;
using Microsoft.AspNet.SignalR.Hubs;
using RLog;

namespace EasySignalRServer.Network
{
    public partial class ChatHub : Hub
    {
        
        [HubMethodName(PacketNames.SendMessage)]
        
        public void SendPacket(SendPacket sendPacket)
        {
            Clients.Caller.Invoke(sendPacket.MethodName, sendPacket);

            var broadCastPacket = new BroadCastPacket(sendPacket.Nickname, sendPacket.Message);

            Clients.Group(ChatGroupName).Invoke(broadCastPacket.MethodName, broadCastPacket);

            RLogger.Debug($"Sender:{broadCastPacket.Sender}, Message:{broadCastPacket.Message}");

        }

        // 브로드캐스트 
        void BroadCast(BroadCastPacket broadCastPacket)
        {
            Clients.Group(ChatGroupName).Invoke(broadCastPacket.MethodName, broadCastPacket);
        }
    }
}
