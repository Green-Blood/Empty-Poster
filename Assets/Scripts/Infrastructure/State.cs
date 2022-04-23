namespace Infrastructure
{
    public sealed class State
    {
        public GameState GameState { get; private set; }

        // public void SetState(GameState state)
        // {
        //     GameState = state;
        // }

        public void NextState() => GameState++;
    }
}