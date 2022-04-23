using Infrastructure;

namespace Character
{
    public class CharacterTransitionState : IState
    {
        private bool isTriggered;
        public IState DoState(CharacterBootstrap characterBootstrap, StateMachine stateMachine)
        {
            characterBootstrap.CharacterAnimator.SetAnimation();
            return stateMachine.GameState == GameState.Transition ? this : new CharacterChaseState();
        }
    }
}