using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Client.Scripts.Objects
{
    [Serializable]
    public class TileContainer
    {
        public List<Tile> TileList { get; private set; }

        public TileContainer()
        {
            TileList = new List<Tile>();
        }

        public TileContainer(List<Tile> tileList)
        {
            TileList = tileList;
        }
    }
}