using Character;
using Enemy;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CharacterBootstrap character;
        [SerializeField] private CameraFollower cameraFollower;
        [SerializeField] private StatePoint statePoint;
        [SerializeField] private EnemiesStateMachine enemiesStateMachine;
        [SerializeField] private EndScreen endScreen;

        private StateMachine _stateMachine;
        private void Awake()
        {
            _stateMachine = new StateMachine();
            statePoint.Init(_stateMachine);
            character.Init(_stateMachine);
            cameraFollower.Init(_stateMachine);
            enemiesStateMachine.Init(_stateMachine, character);
            endScreen.Init(_stateMachine, cameraFollower);
        }
    }
}