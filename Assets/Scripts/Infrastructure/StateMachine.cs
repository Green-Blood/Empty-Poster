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
        public void SetState(GameState stateToChange)
        {
            GameState = stateToChange;
            OnStateChanged?.Invoke(GameState);
        }
        public void EndState()
        {
            if(GameState == GameState.Finish) return;
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