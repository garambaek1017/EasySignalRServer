using EasyTestClient.ClientState;
using System;
using System.Collections.Generic;

namespace EasyTestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Console Chatting Program..");
            
            ChattingClient.Instance.Run();
        }
    }
}
