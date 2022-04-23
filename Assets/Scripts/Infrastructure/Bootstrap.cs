using System;
using Character;
using Unity.VisualScripting;
using UnityEngine;

namespace Infrastructure
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CharacterBootstrap character;
        [SerializeField] private CameraFollower cameraFollower;
        [SerializeField] private StatePoint statePoint; 

        private StateMachine _stateMachine;
        private void Awake()
        {
            _stateMachine = new StateMachine();
            statePoint.Init(_stateMachine);
            character.Init(_stateMachine);
            cameraFollower.Follow(character.transform);
        }
    }
}