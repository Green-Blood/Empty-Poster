using UnityEngine;

namespace Character
{
    public sealed class CharacterAnimator
    {
        private readonly Rigidbody2D _characterRigidBody;
        private readonly Animator _animator;

        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        private static readonly int TakeSign = Animator.StringToHash("TakeSign");
        private static readonly int ChaseStateTrigger = Animator.StringToHash("ChaseStateTrigger");
        private static readonly int IsFall = Animator.StringToHash("IsFall");

        public CharacterAnimator(Rigidbody2D characterRigidBody, Animator animator)
        {
            _characterRigidBody = characterRigidBody;
            _animator = animator;
        }

        public void SetAnimation() => _animator.SetFloat(MoveSpeed, Mathf.Abs(_characterRigidBody.velocity.x));
        public void SetTransitionTrigger() => _animator.SetTrigger(TakeSign);
        public void SetChaseTrigger() => _animator.SetTrigger(ChaseStateTrigger);
        public void SetIsFall() => _animator.SetBool(IsFall, true);
    }
}