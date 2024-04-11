using System;
using System.Threading;

namespace EasyTestClient.ClientState
{
    public class NetworkState : BaseState
    {
        public NetworkState() {
            
        }   

        public async override void Do()
        {
            Console.WriteLine("NetworkState...");

            ChattingClient.Instance.Context.SetState(new WaitState());

            var isConnection = await ChattingClient.Instance.SetNetworkAndConnection();

            if(isConnection)
            {
                ChattingClient.Instance.Context.SetState(new ChattingState());
                //this._context.Do();
            }
            else
            {
                Console.WriteLine("connection is fail");
            }
        }
    }
}
