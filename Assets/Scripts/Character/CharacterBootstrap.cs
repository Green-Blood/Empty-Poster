using System;
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


        private bool _isGrounded;

        private IMove _characterMovement;
        private IJump _characterJump;

        private const float GroundCheckRadius = .2f;

        public void Init()
        {
            _characterMovement = new CharacterMovement(moveSpeed, characterRigidBody);
            _characterJump = new CharacterJump(jumpForce, characterRigidBody);
        }

        private void Update()
        {
            _characterMovement.Move();
            _characterJump.Jump(IsGrounded());
        }

        private bool IsGrounded() => Physics2D.OverlapCircle(groundCheckPoint.position, GroundCheckRadius, groundMask);
    }
}