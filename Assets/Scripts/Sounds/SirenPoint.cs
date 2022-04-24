using Character;
using UnityEngine;

namespace Sounds
{
    public class SirenPoint : MonoBehaviour
    {
        private Sounds _sounds;
        private bool _isChanged;

        public void Init(Sounds sounds)
        {
            _sounds = sounds;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isChanged) return;
            if (!other.TryGetComponent(out CharacterBootstrap character)) return;
            _sounds.PlaySirens();
            _isChanged = true;
        }
    }
}