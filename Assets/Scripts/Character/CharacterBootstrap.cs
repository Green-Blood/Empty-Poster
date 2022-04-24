using System;
using Infrastructure;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Character
{
    public sealed class CharacterBootstrap : MonoBehaviour
    {
        [TabGroup("Parameters")] [SerializeField]
        internal float moveSpeedBeforeIntro = 4f;

        [TabGroup("Parameters")] [SerializeField]
        internal float moveSpeedAfterIntro = 6f;

        [TabGroup("Parameters")] [SerializeField]
        internal float jumpForce;
        [TabGroup("Parameters")] [SerializeField]
        internal float jumpTime = 0.35f;

        [TabGroup("Parameters")] [SerializeField]
        internal LayerMask groundMask;

        [TabGroup("References")] [SerializeField]
        internal Transform groundCheckPoint;

        [TabGroup("References")] [SerializeField]
        internal Rigidbody2D characterRigidBody;

        [TabGroup("References")] [SerializeField]
        internal Animator characterAnimator;

        [TabGroup("References")] [SerializeField]
        internal SpriteRenderer characterSprite;


        private bool _isGrounded;

        internal IMove CharacterMovement;
        internal IJump CharacterJump;
        internal CharacterAnimator CharacterAnimator;
        internal IFlip CharacterFlip;
        private IState _currentState;
        private StateMachine _stateMachine;

        private const float GroundCheckRadius = .1f;
        private Vector3 _initialPosition;
        internal bool CanMove = true;

        public void Init(StateMachine stateMachine)
        {
            _currentState = new CharacterIntroState();
            _stateMachine = stateMachine;
            CharacterMovement = new CharacterMovement(moveSpeedBeforeIntro, characterRigidBody);
            CharacterJump = new CharacterJump(jumpForce, jumpTime, characterRigidBody, characterAnimator);
            CharacterAnimator = new CharacterAnimator(characterRigidBody, characterAnimator);
            CharacterFlip = new CharacterFlip(characterSprite);
            _initialPosition = transform.position;
            _stateMachine.OnStateChanged += OnStateChanged;
        }

        private void Restart()
        {
            transform.position = _initialPosition;
            CharacterAnimator.SetIsFall(false);
        }

        private void Update()
        {
            _currentState = _currentState.DoState(this, _stateMachine);
        }

        private void FixedUpdate()
        {
            if(!CanMove) return;
            CharacterMovement.Move();
        }

        internal bool IsGrounded() => Physics2D.OverlapCircle(groundCheckPoint.position, GroundCheckRadius, groundMask);

        private void OnStateChanged(GameState changedState)
        {
            switch (changedState)
            {
                case GameState.End:
                case GameState.Finish:
                    _currentState = new CharacterEndState();
                    CanMove = false;
                    break;
                case GameState.Intro:
                    _currentState = new CharacterIntroState();
                    Restart();
                    CanMove = true;
                    break;
                case GameState.Transition:
                    CanMove = false;
                    break;
                case GameState.Chase:
                    CanMove = true;
                    break;
                default:
                    _currentState = _currentState;
                    break;
            }
        }
    }
}