using System;
using UnityEngine;

namespace Client.Scripts.ExtensionMethods
{
    public static class Extensions
    {
        public static Vector2Int Vector2IntConstructor(this Vector2 vector2)
        {
            return new(
                Mathf.FloorToInt(vector2.x),
                Mathf.FloorToInt(vector2.y));
        }

        public static Vector2 ClampPosition(this Vector2 position, Vector2 size, Vector2 pivot) => new(
            Mathf.Clamp(position.x, -pivot.x * size.x, (1 - pivot.x) * size.x),
            Mathf.Clamp(position.y, -pivot.y * size.y, (1 - pivot.y) * size.y)
        );

        public static bool ApproximatelyEqual(this float a, float b) => Mathf.Abs(a - b) < 0.001f;

        public static Vector2 GetPrevious(this Touch touch) => touch.position - touch.deltaPosition;
    }
}