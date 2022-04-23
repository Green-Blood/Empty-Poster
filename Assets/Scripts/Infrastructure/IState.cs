using Character;

namespace Infrastructure
{
    public interface IState
    {
        IState DoState(CharacterBootstrap characterBootstrap, StateMachine stateMachine);
    }
}