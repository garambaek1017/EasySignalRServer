namespace Protocols.Packets
{
    public class ChatHubMethodNames
    {
        #region 클라이언트가 양방향 통신하는 부분
        public const string SendChat = "SendChat";
        public const string SendChatResult = "SendChatResult";
        #endregion

        #region  서버가 보내는거 
        // 서버가 보내는거 
        public const string BroadcastMessage = "BroadcastMessage";
        // 서버가 보내는거 
        public const string NotifyMessage = "NotifyMessage";
        #endregion
    }
}
