using Microsoft.AspNet.SignalR;
using Protocols.Packets;
using Microsoft.AspNet.SignalR.Hubs;
using RLog;

namespace EasySignalRServer.Network
{
    
    public partial class ChatHub : Hub
    {
        
        [HubMethodName(ChatHubMethodNames.SendChat)]
        
        public void SendPacket(SendChat sendPacket)
        {
            RLogger.Debug($"Sender: {sendPacket.Nickname} Message:{sendPacket.Message}");

            // 호출자에게 리턴 
            Clients.Caller.Invoke(ChatHubMethodNames.SendChatResult, sendPacket);

            var broadCastPacket = new BroadcastPacket(sendPacket.Nickname, sendPacket.Message);
            Broadcast(broadCastPacket);
        }
    }
}
