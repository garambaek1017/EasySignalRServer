using System;
using System.CodeDom;

namespace EasyTestClient.ClientState
{
    public class Context
    {
        private BaseState _state = null;

        public Context(BaseState state)
        {
            SetState(state);
        }

        public void SetState(BaseState state) {
            _state = state;
        }

        /// <summary>
        /// 상태에 맞춰 실행되는 함수 
        /// </summary>
        public void Do()
        {
            switch (_state)
            {
                case UserInfoState userInfoState:
                    userInfoState.Do();
                    break;

                case NetworkState networkSate:
                    networkSate.Do();
                    break;
                
                case ChattingState chattingState:
                    chattingState.Do(); 
                    break;

                case WaitState waitState:
                    waitState.Do();
                    break;
            }
        }
    }
}
