namespace Protocols.Packets
{

    public class SendChat : BasePacket
    {
        public string Message { get; set; }
        public string Nickname { get; set; }

        #region 생성자
        public SendChat()
            : base(ChatHubMethodNames.SendChat) { }
        #endregion
    }
    public class SendChatResult : BasePacketResult
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        #region 생성자
        public SendChatResult()
            : base(ChatHubMethodNames.SendChatResult) { }
        #endregion
    }

}
