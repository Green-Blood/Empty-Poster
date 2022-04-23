using Infrastructure;
using UnityEngine;

namespace Enemy
{
    public class EnemiesStateMachine : MonoBehaviour
    {
        [SerializeField] private EnemyAI[] enemies;

        private StateMachine _stateMachine;
        public void Init(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            // Should be changed to actual state machine
            _stateMachine.OnStateChanged += OnStateChanged;
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
