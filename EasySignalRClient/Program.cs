using RLog;

namespace EasyTestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 로그 프로그램 init
            RLogger.Init();

            RLogger.Debug("[Start Test SignalR Chatting Client]");

            ChattingClient.Instance.ShowMenu();

            var signalRNetwork = new SignalRNetwork($"http://localhost:2023/");

            ChattingClient.Instance.SetNetwork(signalRNetwork);

            ChattingClient.Instance.Run();
        }
    }
}
