using UnityEngine;

namespace Character
{
    public sealed class CharacterFlip : IFlip
    {
        private readonly SpriteRenderer _characterSprite;
        private const string HorizontalAxis = "Horizontal";

        public CharacterFlip(SpriteRenderer characterSprite)
        {
            _characterSprite = characterSprite;
        }

        public void TryFlip()
        {
            float axis = Input.GetAxisRaw(HorizontalAxis);
            _characterSprite.flipX = axis < 0;
        }
    }
}