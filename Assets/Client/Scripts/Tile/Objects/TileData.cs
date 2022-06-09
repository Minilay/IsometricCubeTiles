using System;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Scripts.Objects
{
    [Serializable]
    public class TileData
    {
        [field:SerializeField] public int Rows { get; private set; }
        [field:SerializeField] public int  Columns { get; private set; }
        
        [field: SerializeField] public float Distance { get; private set; }

        public List<TileContainer> Tiles { get; private set; }

        public TileData()
        {
            Tiles = new List<TileContainer>();
        }
        public Vector2 GetTileCoordinates(int x, int y) => new Vector2(x, y) * Distance;

        public Vector2 TileCoordinatesToPosition(int x, int y)
        {
            var tilePosition = GetTileCoordinates(x, y);

            return new Vector2(
                tilePosition.x * 2 + tilePosition.y * -2,
                tilePosition.x + tilePosition.y
            ) * 1/4;
        }
    }
}