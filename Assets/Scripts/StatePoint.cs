using Character;
using UnityEngine;

namespace Infrastructure
{
    public sealed class StatePoint : MonoBehaviour
    {
        private bool _isChanged;
        private StateMachine _stateMachine;
        public void Init(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(_isChanged) return;
            if (!other.TryGetComponent(out CharacterBootstrap character)) return;
            _stateMachine.NextState();
            _isChanged = true;
        }
    }
}