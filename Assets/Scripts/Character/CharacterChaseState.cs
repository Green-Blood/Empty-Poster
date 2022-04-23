using Infrastructure;

namespace Character
{
    public class CharacterChaseState : IState
    {
        public IState DoState(CharacterBootstrap characterBootstrap, StateMachine stateMachine)
        {
            characterBootstrap.CharacterMovement.Move();
            characterBootstrap.CharacterJump.Jump(characterBootstrap.IsGrounded());
            characterBootstrap.CharacterAnimator.SetAnimation();
            characterBootstrap.CharacterFlip.TryFlip();
            return this;
        }
    }
}