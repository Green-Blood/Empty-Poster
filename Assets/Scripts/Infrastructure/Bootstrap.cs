using Character;
using UnityEngine;

namespace Infrastructure
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CharacterBootstrap character;
        [SerializeField] private CameraFollower cameraFollower;

        private void Awake()
        {
            character.Init();
            cameraFollower.Follow(character.transform);
        }
    }
}