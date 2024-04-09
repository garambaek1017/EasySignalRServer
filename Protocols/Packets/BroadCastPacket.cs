using Newtonsoft.Json;
using System.Text;

namespace Protocols.Packets
{
    public class BroadcastPacket : IChatBroadCastPacket
    {
        /// <summary>
        /// 메시지 보낸 사람 
        /// </summary>
        public string Sender { get; set; } 
        /// <summary>
        /// 메시지 내용
        /// </summary>
        public string Message { get; set; }

        public BroadcastPacket(string sender, string message)
        {
            Sender = sender;
            Message = message;
        }   

        public sealed override string ToString()
        {
            StringBuilder s = new StringBuilder();

            s.AppendFormat("[{0}] - ", GetType().Name);
            s.Append(JsonConvert.SerializeObject(this));

            return s.ToString();
        }
    }
}
