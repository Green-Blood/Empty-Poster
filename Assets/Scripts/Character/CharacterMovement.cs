using UnityEngine;

namespace Character
{
    public sealed class CharacterMovement : IMove
    {
        private readonly float _moveSpeed;
        private readonly Rigidbody2D _characterRigidBody;

        private static string HorizontalAxis = "Horizontal";


        public CharacterMovement(float moveSpeed, Rigidbody2D characterRigidBody)
        {
            _moveSpeed = moveSpeed;
            _characterRigidBody = characterRigidBody;
        }

        public void Move()
        {
            float axis = Input.GetAxisRaw(HorizontalAxis);
            _characterRigidBody.velocity =
                new Vector2(axis * _moveSpeed, _characterRigidBody.velocity.y);
        }
    }
}