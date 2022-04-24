using Infrastructure;

namespace Character
{
    public class CharacterEndState : IState
    {
        public IState DoState(CharacterBootstrap characterBootstrap, StateMachine stateMachine)
        {
            characterBootstrap.CharacterAnimator.SetIsFall();
            return new CharacterEndState();
        }
    }
}