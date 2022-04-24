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
                enemy.Init(characterBootstraper.CharacterAnimator, stateMachine);
                enemy.target = characterBootstraper.characterRigidBody.transform;
            }
        }

        private void OnStateChanged(GameState gameState)
        {
            if (gameState != GameState.Chase) return;
            foreach (var enemy in enemies)
            {
                enemy.allowRunning = true;
            }
        }
    }
}
