namespace Protocols.Packets
{
    public class NotifyPacket : INoticePacket
    {
        public string NotiMessage { get; set; }
        public NotifyPacket()
        {

        }
    }
}
