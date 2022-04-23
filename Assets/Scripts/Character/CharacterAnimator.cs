using UnityEngine;

namespace Character
{
    public sealed class CharacterAnimator
    {
        private readonly Rigidbody2D _characterRigidBody;
        private readonly Animator _animator;
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");

        public CharacterAnimator(Rigidbody2D characterRigidBody, Animator animator)
        {
            _characterRigidBody = characterRigidBody;
            _animator = animator;
        }

        public void SetAnimation()
        {
            _animator.SetFloat(MoveSpeed, Mathf.Abs(_characterRigidBody.velocity.x));
        }
    }
}