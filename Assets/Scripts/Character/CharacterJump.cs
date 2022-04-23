using Infrastructure;
using UnityEngine;

namespace Character
{
    public sealed class CharacterJump : IJump
    {
        private readonly float _jumpForce;
        private readonly Rigidbody2D _characterRigidBody;
        private readonly Animator _characterAnimator;
        private static readonly int IsJump = Animator.StringToHash("IsJump");

        private const float VelocityMultiplier = .5f;
        private const string JumpButton = "Jump";

        public CharacterJump(float jumpForce, Rigidbody2D characterRigidBody, Animator characterAnimator)
        {
            _jumpForce = jumpForce;
            _characterRigidBody = characterRigidBody;
            _characterAnimator = characterAnimator;
        }

        public void Jump(bool isGrounded)
        {
            bool isJumpPressed = Input.GetButtonDown(JumpButton);
            if (isGrounded)
            {
                _characterAnimator.SetBool(IsJump, false);
            }

            if (isJumpPressed && isGrounded)
            {
                _characterRigidBody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
                _characterAnimator.SetBool(IsJump, true);
            }

            if (isJumpPressed && _characterRigidBody.velocity.y > 0)
            {
                _characterRigidBody.velocity =
                    new Vector2(_characterRigidBody.velocity.x, _characterRigidBody.velocity.y * VelocityMultiplier);
                _characterAnimator.SetBool(IsJump, true);
            }
        }
    }
}