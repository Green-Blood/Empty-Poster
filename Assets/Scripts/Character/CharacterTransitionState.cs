using Infrastructure;

namespace Character
{
    public sealed class CharacterTransitionState : IState
    {
        private bool _isTriggered;
        public IState DoState(CharacterBootstrap characterBootstrap, StateMachine stateMachine)
        {
            if (!_isTriggered)
            {
                characterBootstrap.CharacterAnimator.SetTransitionTrigger();
                _isTriggered = true;
            }
            return stateMachine.GameState == GameState.Transition ? this : new CharacterChaseState();
        }
    }
}