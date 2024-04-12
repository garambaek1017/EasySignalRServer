namespace EasyTestClient.ClientState
{
    /// <summary>
    /// 상태를 가지는 클래스 
    /// </summary>
    public class Context
    {
        private BaseState _state = null;

        public Context(BaseState state)
        {
            SetState(state);
        }

        public void SetState(BaseState state)
        {
            _state = state;
        }

        /// <summary>
        /// 상태에 맞춰 실행되는 함수 
        /// </summary>
        public void Do()
        {
            switch (_state)
            {
                // 유저 정보 저장, 닉네임 저장 
                case UserInfoState userInfoState:
                    userInfoState.Do();
                    break;

                // 네트워크 셋팅 
                case NetworkState networkSate:
                    networkSate.Do();
                    break;

                // 채팅 상태 
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
