using Infrastructure;

namespace Character
{
    public class CharacterEndState : IState
    {
        public IState DoState(CharacterBootstrap characterBootstrap, StateMachine stateMachine)
        {
            characterBootstrap.CharacterAnimator.StopJump();
            characterBootstrap.CharacterAnimator.SetIsFall(true);
            return new CharacterEndState();
        }
    }
}