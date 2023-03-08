namespace Protocols.Packets
{
    public enum PacketType
    {
        Echo,
        BroadCast,
    }


    public class Packets
    {
        protected PacketType PacketType { get; set; }
        public string MethodName { get; set; }
        public Packets(string methodName, PacketType packetType)
        {
            PacketType = packetType;
            MethodName = methodName;
        }
    }

    public class SendPacket : Packets
    {
        public string Nickname { get; set; }
        public string Message { get; set; }

        public SendPacket(string nickname, string message)
            : base(PacketNames.SendMessage, PacketType.Echo)
        {
            Nickname = nickname;
            Message = message;
        }
    }



    public class BroadCastPacket : Packets
    {
        public string Sender { get; set; }
        public string Message { get; set; }

        public BroadCastPacket(string sender, string message)
          : base(PacketNames.BroadcastMessage, PacketType.BroadCast)
        {
            Sender = sender;
            Message = message;
        }
    }

}
