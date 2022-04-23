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

        internal IMove CharacterMovement;
        internal IJump CharacterJump;
        internal CharacterAnimator CharacterAnimator;
        internal IFlip CharacterFlip;
        private IState _currentState;
        private StateMachine _stateMachine;

        private const float GroundCheckRadius = .1f;

        public void Init(StateMachine stateMachine)
        {
            _currentState = new CharacterIntroState();
            _stateMachine = stateMachine;
            CharacterMovement = new CharacterMovement(moveSpeed, characterRigidBody);
            CharacterJump = new CharacterJump(jumpForce, characterRigidBody, characterAnimator);
            CharacterAnimator = new CharacterAnimator(characterRigidBody, characterAnimator);
            CharacterFlip = new CharacterFlip(characterSprite);
        }

        private void FixedUpdate()
        {
            _currentState = _currentState.DoState(this, _stateMachine);
        }

        internal bool IsGrounded() => Physics2D.OverlapCircle(groundCheckPoint.position, GroundCheckRadius, groundMask);
    }
}