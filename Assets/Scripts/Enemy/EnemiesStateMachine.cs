using Character;
using Infrastructure;
using UnityEngine;

namespace Enemy
{
    public class EnemiesStateMachine : MonoBehaviour
    {
        [SerializeField] private EnemyAI[] enemies;

        private StateMachine _stateMachine;
        public void Init(StateMachine stateMachine, CharacterBootstrap characterBootstraper)
        {
            _stateMachine = stateMachine;
            // Should be changed to actual state machine
            _stateMachine.OnStateChanged += OnStateChanged;
            foreach (var enemy in enemies)
            {
                enemy.characterAnimator = characterBootstraper.CharacterAnimator;
            }
        }

        private void OnStateChanged(GameState gameState)
        {
            if (gameState != GameState.Chase) return;
            foreach (var enemy in enemies)
            {
                enemy.followEnabled = true;
            }
        }
    }
}
