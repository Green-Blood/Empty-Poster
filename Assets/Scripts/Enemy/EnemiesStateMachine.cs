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
                enemy.Init(stateMachine);
                enemy.target = characterBootstraper.characterRigidBody.transform;
            }
        }

        private void OnStateChanged(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Chase:
                {
                    foreach (var enemy in enemies)
                    {
                        enemy.allowRunning = true;
                    }

                    break;
                }
                case GameState.Intro:
                {
                    foreach (var enemy in enemies)
                    {
                        enemy.Restart();
                    }

                    break;
                }
            }
        }
    }
}