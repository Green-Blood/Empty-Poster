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
    }
}