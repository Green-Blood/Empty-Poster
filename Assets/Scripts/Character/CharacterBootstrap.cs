using System;
using Infrastructure;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Character
{
    public sealed class CharacterBootstrap : MonoBehaviour
    {
        [TabGroup("Parameters")] [SerializeField]
        private float moveSpeed;

        [TabGroup("Parameters")] [SerializeField]
        private float jumpForce;

        [TabGroup("Parameters")] [SerializeField]
        private LayerMask groundMask;

        [TabGroup("References")] [SerializeField]
        private Transform groundCheckPoint;

        [TabGroup("References")] [SerializeField]
        private Rigidbody2D characterRigidBody;

        [TabGroup("References")] [SerializeField]
        private Animator characterAnimator;

        [TabGroup("References")] [SerializeField]
        private SpriteRenderer characterSprite;


        private bool _isGrounded;

        private IMove _characterMovement;
        private IJump _characterJump;
        private CharacterAnimator _characterAnimator;
        private IFlip _characterFlip;
        private StateMachine _stateMachine;

        private const float GroundCheckRadius = .2f;

        public void Init(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _characterMovement = new CharacterMovement(moveSpeed, characterRigidBody);
            _characterJump = new CharacterJump(jumpForce, characterRigidBody, _stateMachine);
            _characterAnimator = new CharacterAnimator(characterRigidBody, characterAnimator);
            _characterFlip = new CharacterFlip(characterSprite);
        }

        private void Update()
        {
            _characterMovement.Move();
            _characterJump.Jump(IsGrounded());
            _characterAnimator.SetAnimation();
            _characterFlip.TryFlip();
        }

        private bool IsGrounded() => Physics2D.OverlapCircle(groundCheckPoint.position, GroundCheckRadius, groundMask);
    }
}