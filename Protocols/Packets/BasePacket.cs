using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Protocols.Packets
{
    public interface IChatPacket
    {
        string MethodName { get; set; }
        string ToString();
    }

    /// <summary>
    /// 브로드 캐스트용 
    /// </summary>
    public interface IChatBroadCastPacket
    {
        string ToString();
    }

    public interface INoticePacket
    {
        string ToString();
    }

    public abstract class BasePacket : IChatPacket
    {
        public string MethodName { get; set; }
        public long AccountIdx { get; set; }
        public string Version { get; set; }

        #region 생성자
        public BasePacket(string methodName)
        {
            MethodName = methodName;
        }
        #endregion

        public sealed override string ToString()
        {
            StringBuilder s = new StringBuilder();

            s.AppendFormat("[{0}] - [AccountIdx:{1}] - ", GetType().Name, AccountIdx);
            s.Append(JsonConvert.SerializeObject(this));

            return s.ToString();
        }
    }

    public abstract class BasePacketResult : IChatPacket
    {
        public string MethodName { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        #region 생성자
        public BasePacketResult(string methodName)
        {
            ErrorCode = 0;
            ErrorMessage = "SUCCESS";
            MethodName = methodName;
        }
        #endregion

        // result는 base 단에서 유저의 고유 정보를 알 수 없기 때문에 파라미터 인자로 받은 것과 그렇지 않는 함수로 구분해서 만들었다.
        public string ToString(long accountIdx)
        {
            var s = new StringBuilder();

            s.AppendFormat("[{0}] - [AccountIdx:{1}] - [ErrorCode:{2}] - [ErrorMessage:{3}] - ", GetType().Name, accountIdx, ErrorCode, ErrorMessage);

            s.Append(ParsePacket());

            return s.ToString();
        }

        public sealed override string ToString()
        {
            var s = new StringBuilder();

            s.AppendFormat("[{0}] - [ErrorCode:{1}] - [ErrorMessage:{2}] - ", GetType().Name, ErrorCode, ErrorMessage);

            s.Append(ParsePacket());

            return s.ToString();
        }

        string ParsePacket()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            var jObject = JObject.Parse(jsonString);
            jObject.Remove("ErrorCode");
            jObject.Remove("ErrorMessage");

            return JsonConvert.SerializeObject(jObject);
        }
    }

    
}
