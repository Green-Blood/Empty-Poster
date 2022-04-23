using Infrastructure;

namespace Character
{
    public class CharacterChaseState : IState
    {
        private bool _isChasing;

        public IState DoState(CharacterBootstrap characterBootstrap, StateMachine stateMachine)
        {
            if (!_isChasing)
            {
                characterBootstrap.CharacterAnimator.SetChaseTrigger();
                characterBootstrap.CharacterMovement = new CharacterMovement(characterBootstrap.moveSpeedAfterIntro,
                    characterBootstrap.characterRigidBody);
                _isChasing = true;
            }

            characterBootstrap.CharacterMovement.Move();
            characterBootstrap.CharacterJump.Jump(characterBootstrap.IsGrounded());
            characterBootstrap.CharacterAnimator.SetAnimation();
            characterBootstrap.CharacterFlip.TryFlip();
            return this;
        }
    }
}