using Microsoft.AspNet.SignalR.Client;
using Protocols.Packets;

namespace EasyTestClient.Player
{
    public partial class TestPlayer
    {
        public void SendMessage(string message)
        {
            var packet = new SendPacket(this.Nickname, message);
            SendPacket(packet);
        }

        void SendPacket(Packets packet)
        {
            // 패킷 이름을 호출! 
            if (HubConnection.State == ConnectionState.Connected)
                Proxy.Invoke(packet.MethodName, packet);
        }
    }
}
