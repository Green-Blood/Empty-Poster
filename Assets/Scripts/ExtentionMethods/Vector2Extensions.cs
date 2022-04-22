using UnityEngine;

namespace ExtentionMethods
{
    public static class Vector2Extensions
    {
        public static Vector2 With(this Vector2 original, float? x = null, float? y = null)
        {
            return new Vector2(x ?? original.x, y ??  original.y);
        }

        public static Vector2 Flat(this Vector2 original)
        {
            return new Vector2(original.x, 0);
        }
    }
}