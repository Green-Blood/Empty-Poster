using UnityEngine;

namespace Character
{
    public sealed class CharacterBootstrap : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D characterRigidBody;
        [SerializeField] private float moveSpeed;

        private CharacterMovement _characterMovement;

        public void Init()
        {
            _characterMovement = new CharacterMovement(moveSpeed, characterRigidBody);
        }
    }
}