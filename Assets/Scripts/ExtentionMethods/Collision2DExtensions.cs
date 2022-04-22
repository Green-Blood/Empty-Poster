using UnityEngine;

namespace Extensions
{
    public static class Collision2DExtensions
    {
        public static float GetImpactForce(this Collision2D collision)
        {
            float impulse = 0F;

            foreach (ContactPoint2D point in collision.contacts)
            {
                impulse += point.normalImpulse;
            }

            return impulse / Time.fixedDeltaTime;
        }
    }
}