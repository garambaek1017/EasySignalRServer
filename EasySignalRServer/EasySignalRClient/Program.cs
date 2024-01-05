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
        static int consoleLineCount = 0; // 대략적으로 셈

        static void Main(string[] args)
        {
            RLogger.Init();

            RLogger.Debug("Start Test SignalR Client");

            var testPlayer = new TestPlayer
            {
                ChatServerEndPoint = $"http://localhost:2023/"
            };

            ShowMenu();

            Run(testPlayer);
        }

        // 메뉴 표시 
        static void ShowMenu()
        {
            RLogger.Debug("[1] or [nickname] : 보내는 사람 이름 설정");
            RLogger.Debug("[2] or [connect] : 서버에 연결");
            RLogger.Debug("[3] or [send] : 메시지 보내기");
        }
        
        static void Run(TestPlayer testPlayer)
        {
            while (true)
            {
                string cmd = Console.ReadLine().ToLower();

                if (cmd.Contains("nickname") == true || cmd.Contains("1") == true)
                {
                    Console.Write("Input nickName >> ");
                    consoleLineCount++;

                    var nickname = Console.ReadLine();
                    testPlayer.Nickname = nickname;

                    RLogger.Debug("Nickname setting is done");
                    consoleLineCount++;
                }

                if (cmd.Contains("connect") == true || cmd.Contains("2") == true)
                {
                    testPlayer.Connect();
                }

                if (cmd.Contains("send") == true || cmd.Contains("3") == true)
                {
                    Console.Write("Input Message >> ");
                    var message = Console.ReadLine();
                    testPlayer.SendMessage(message);

                    consoleLineCount++;
                }

                if (cmd.Contains("exit") == true || cmd.Contains("4") == true)
                {
                    testPlayer.Disconnect();
                }

                // 대충 10줄 넘으면 지움 
                if(consoleLineCount >= 10)
                {
                    Console.Clear();
                    ShowMenu();
                    consoleLineCount = 0;
                }
            }
        }
    }
}
