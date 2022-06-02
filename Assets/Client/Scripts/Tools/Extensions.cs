using UnityEngine;

namespace Client.Scripts.ExtensionMethods
{
    public static class Extensions
    {
        public static Vector2Int Vector2IntConstructor (this Vector2 vector2)
        {
            return new (
                Mathf.FloorToInt(vector2.x),
                Mathf.FloorToInt(vector2.y));
        }
    }
}