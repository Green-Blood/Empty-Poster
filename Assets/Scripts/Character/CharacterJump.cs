using Infrastructure;
using UnityEngine;

namespace Character
{
    public sealed class CharacterJump : IJump
    {
        private readonly float _jumpForce;
        private readonly float _jumpTime;
        private readonly float _hangTime;
        private readonly Rigidbody2D _characterRigidBody;
        private readonly Animator _characterAnimator;
        private static readonly int IsJump = Animator.StringToHash("IsJump");

        private const float VelocityMultiplier = .5f;
        private const string JumpButton = "Jump";
        private bool _isJumping;
        private float _jumpTimeCounter;
        private float _hungCounter;


        public CharacterJump(float jumpForce, float jumpTime, float hangTime, Rigidbody2D characterRigidBody,
            Animator characterAnimator)
        {
            _jumpForce = jumpForce;
            _jumpTime = jumpTime;
            _hangTime = hangTime;
            _characterRigidBody = characterRigidBody;
            _characterAnimator = characterAnimator;
        }


        public void Jump(bool isGrounded)
        {
            if (isGrounded)
            {
                _characterAnimator.SetBool(IsJump, false);
                _hungCounter = _hangTime;
            }
            else
            {
                if (_hungCounter > 0)
                    _hungCounter -= Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Space) && _hungCounter > 0)
            {
                // _characterRigidBody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
                _isJumping = true;
                _jumpTimeCounter = _jumpTime;
                _characterRigidBody.velocity = Vector2.up * _jumpForce;
                _characterAnimator.SetBool(IsJump, true);
            }

            if (Input.GetKey(KeyCode.Space) && _isJumping)
            {
                if (_jumpTimeCounter > 0)
                {
                    _characterRigidBody.velocity = Vector2.up * _jumpForce;
                    _jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    _isJumping = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                _isJumping = false;
            }
        }
    }
}