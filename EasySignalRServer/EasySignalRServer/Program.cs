using Microsoft.Owin.Hosting;
using RLog;
using System;

namespace EasySignalRServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RLogger.Init();

            var url = "http://localhost:2023";
            RLogger.Debug($"signalr connection base url: " + url);

            WebApp.Start(url);
            RLogger.Debug($"Ram's easy SignalR Server is Run");

            Run();
        }

        static void Run()
        {
            while (true)
            {
                string cmd = Console.ReadLine().ToLower();

                if (cmd.Contains("exit") == true)
                    break;
            }
        }
    }
}
