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

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }

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
