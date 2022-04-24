using Infrastructure;
using UnityEngine;

namespace Character
{
    public class CharacterIntroState : IState
    {
        public IState DoState(CharacterBootstrap characterBootstrap, StateMachine stateMachine)
        {
            characterBootstrap.CharacterAnimator.SetAnimation();
            characterBootstrap.CharacterFlip.TryFlip();

            return stateMachine.GameState == GameState.Intro ? this : new CharacterTransitionState();
        }
    }
}