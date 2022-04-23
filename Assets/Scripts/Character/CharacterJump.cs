using Infrastructure;
using UnityEngine;

namespace Character
{
    public sealed class CharacterJump : IJump
    {
        private readonly float _jumpForce;
        private readonly Rigidbody2D _characterRigidBody;
        private readonly StateMachine _stateMachine;

        private const float VelocityMultiplier = .5f;
        private const string JumpButton = "Jump";

        public CharacterJump(float jumpForce, Rigidbody2D characterRigidBody, StateMachine stateMachine)
        {
            _jumpForce = jumpForce;
            _characterRigidBody = characterRigidBody;
            _stateMachine = stateMachine;
        }

        public void Jump(bool isGrounded)
        {
            if(_stateMachine.GameState == GameState.Intro) return;
            bool isJumpPressed = Input.GetButtonDown(JumpButton);

            if (isJumpPressed && isGrounded)
            {
                _characterRigidBody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            }

            if (isJumpPressed && _characterRigidBody.velocity.y > 0)
            {
                _characterRigidBody.velocity =
                    new Vector2(_characterRigidBody.velocity.x, _characterRigidBody.velocity.y * VelocityMultiplier);
            }
        }
    }
}