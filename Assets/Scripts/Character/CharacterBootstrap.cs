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

        public void Init(StateMachine stateMachine)
        {
            _currentState = new CharacterIntroState();
            _stateMachine = stateMachine;
            CharacterMovement = new CharacterMovement(moveSpeedBeforeIntro, characterRigidBody);
            CharacterJump = new CharacterJump(jumpForce, characterRigidBody, characterAnimator);
            CharacterAnimator = new CharacterAnimator(characterRigidBody, characterAnimator);
            CharacterFlip = new CharacterFlip(characterSprite);
            _stateMachine.OnStateChanged += OnStateChanged;
        }


        private void FixedUpdate()
        {
            _currentState = _currentState.DoState(this, _stateMachine);
        }

        internal bool IsGrounded() => Physics2D.OverlapCircle(groundCheckPoint.position, GroundCheckRadius, groundMask);

        private void OnStateChanged(GameState changedState)
        {
            _currentState = changedState switch
            {
                GameState.End => new CharacterEndState(),
                GameState.Finish => new CharacterEndState(),
                GameState.Intro => new CharacterIntroState(),
                _ => _currentState
            };
        }
    }
}