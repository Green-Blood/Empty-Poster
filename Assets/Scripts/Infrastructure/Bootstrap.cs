using Character;
using UnityEngine;

namespace Infrastructure
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CharacterBootstrap character;
        [SerializeField] private CameraFollower cameraFollower;

        private State _state;
        private void Awake()
        {
            _state = new State();
            character.Init(_state);
            cameraFollower.Follow(character.transform);
        }
    }
}