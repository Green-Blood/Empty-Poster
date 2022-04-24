using System;

namespace Infrastructure
{
    public sealed class StateMachine
    {
        public GameState GameState { get; private set; }
        public Action<GameState> OnStateChanged;

        public void NextState()
        {
            GameState++;
            OnStateChanged?.Invoke(GameState);
        }
        public void EndState()
        {
            GameState = GameState.End;
            OnStateChanged?.Invoke(GameState);
        }
        public void BeginState()
        {
            GameState = GameState.Intro;
            OnStateChanged?.Invoke(GameState);
        }
    }
}