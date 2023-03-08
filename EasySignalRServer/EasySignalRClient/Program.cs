using EasyTestClient.Player;
using RLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RLogger.Init();

            RLogger.Debug("Start Test SignalR Client");

            var testPlayer = new TestPlayer
            {
                ChatServerEndPoint = $"http://localhost:2023/"
            };

            Run(testPlayer);
        }

        static void Run(TestPlayer testPlayer)
        {
            while (true)
            {
                string cmd = Console.ReadLine().ToLower();
                if (cmd.Contains("exit") == true)
                    testPlayer.Disconnect();

                if (cmd.Contains("nickname") == true || cmd.Contains("1") == true)
                {
                    var nickname = Console.ReadLine();
                    testPlayer.Nickname = nickname;

                    RLogger.Debug("Nickname setting is done");
                }

                if (cmd.Contains("connect") == true || cmd.Contains("2") == true)
                    testPlayer.Connect();


                if (cmd.Contains("send") == true || cmd.Contains("3") == true)
                {
                    var message = Console.ReadLine();
                    testPlayer.SendMessage(message);
                }
            }
        }
    }
}
