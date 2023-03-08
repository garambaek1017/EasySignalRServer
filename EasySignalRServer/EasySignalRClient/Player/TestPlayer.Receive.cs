using Microsoft.AspNet.SignalR.Client;
using Protocols.Packets;
using RLog;

namespace EasyTestClient.Player
{
    public partial class TestPlayer
    {
        void DisConnectToServer()
        {
            HubConnection.Stop();
        }

        public void MessageNoitify(BroadCastPacket result)
        {
            RLogger.Debug($"Sender : {result.Sender}, Message : {result.Message}");
        }

        public void Disconnect()
        {
            if (HubConnection.State == ConnectionState.Connected)
                HubConnection.Stop();
        }
    }
}
