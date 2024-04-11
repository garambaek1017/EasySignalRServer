using Protocols.Packets;
using System;
using System.Collections.Generic;

namespace EasyTestClient.ClientState
{
    public class ChattingState : BaseState
    {
        public ChattingState() {

        }

        public override void Do()
        {
            Console.WriteLine($"### input your message ###");
            var message = Console.ReadLine();

            if(message == "stop")
            {
                ChattingClient.Instance.Stop();
            }
            else
            {

                ChattingClient.Instance.SendChat(message);

                // 잠시 대기상태 
                ChattingClient.Instance.Context.SetState(new WaitState());
            }

        }
    }
}
