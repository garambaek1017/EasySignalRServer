using System;

namespace EasyTestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 채팅 프로그램 시작 
                ChattingClient.Instance.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
