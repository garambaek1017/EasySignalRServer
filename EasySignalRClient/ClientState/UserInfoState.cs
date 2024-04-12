using System;

namespace EasyTestClient.ClientState
{
    public class UserInfoState : BaseState
    {
        public UserInfoState()
        {
        }

        public override void Do()
        {
            Console.Clear();

            Console.Write("#### Input your Nickname >>>> ");

            var nickname = Console.ReadLine();

            ChattingClient.Instance.Nickname = nickname;
            Console.WriteLine("#### Nickname Setting is Done : " + ChattingClient.Instance.Nickname);


            ChattingClient.Instance.Context.SetState(new NetworkState());
        }
    }
}
