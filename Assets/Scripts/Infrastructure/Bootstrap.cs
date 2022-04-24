using Character;
using Enemy;
using Sounds;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CharacterBootstrap character;
        [SerializeField] private CameraFollower cameraFollower;
        [SerializeField] private StatePoint statePoint;
        [SerializeField] private StatePoint endStatePoint;
        [SerializeField] private EnemiesStateMachine enemiesStateMachine;
        [SerializeField] private EndScreen endScreen;
        [SerializeField] private FinishScreen finishScreen;
        [SerializeField] private Sounds.Sounds sounds;
        [SerializeField] private SirenPoint sirenPoint;

        private StateMachine _stateMachine;
        private void Awake()
        {
            _stateMachine = new StateMachine();
            statePoint.Init(_stateMachine);
            endStatePoint.Init(_stateMachine);
            character.Init(_stateMachine);
            cameraFollower.Init(_stateMachine);
            enemiesStateMachine.Init(_stateMachine, character);
            endScreen.Init(_stateMachine, cameraFollower);
            finishScreen.Init(_stateMachine, cameraFollower);
            sounds.Init(_stateMachine);
            sirenPoint.Init(sounds);
        }
    }
}