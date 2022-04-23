using UnityEngine;

namespace Character
{
    public sealed class CharacterMovement
    {
        private readonly float _moveSpeed;
        private readonly Rigidbody2D _characterRigidBody;

        public CharacterMovement(float moveSpeed, Rigidbody2D characterRigidBody)
        {
            _moveSpeed = moveSpeed;
            _characterRigidBody = characterRigidBody;
        }

        public void Move()
        {
            
        }
    }
}
