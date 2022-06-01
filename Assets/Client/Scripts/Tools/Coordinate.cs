using System;
using UnityEngine;

namespace Client.Scripts
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate(float x, float y)
        {
            X = Mathf.FloorToInt(x);
            Y = Mathf.FloorToInt(y);
        }

        public static float GetDistance(Coordinate a, Coordinate b)
            => Utils.GetDistanceBetweenTwoPoints(a.X, a.Y, b.X, b.Y);
        
    }
}