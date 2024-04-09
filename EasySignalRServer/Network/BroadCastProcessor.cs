using Microsoft.AspNet.SignalR;
using Protocols.Packets;
using Microsoft.AspNet.SignalR.Hubs;
using RLog;
using Microsoft.AspNet.SignalR.Messaging;
using System.Threading.Tasks;

namespace EasySignalRServer.Network
{
    
    public partial class ChatHub : Hub
    {
        // 브로드캐스트 
        public void Broadcast(BroadcastPacket broadCastPacket)
        {
            Clients.Group(ChatGroupName).Invoke(ChatHubMethodNames.BroadcastMessage, broadCastPacket);
        }

        public void NotifyToAllUser(NotifyPacket notifyPacket)
        {
            //Clients.All.ReceiveMessage(ChatHubMethodNames.NotifyMessage, notifyPacket);

        }
        
    }
}
