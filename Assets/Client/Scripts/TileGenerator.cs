using System.Collections.Generic;
using Client.Scripts.Objects;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    [field: SerializeField] public TileMatrix TileMatrix { get; private set; }
    
   
    private Tile InstantiateNewTile(int x, int y)
    {
        var newTile = Instantiate(_tilePrefab, transform, true);
        newTile.SetTileRenderPriority(x,y);
        newTile.name = $"{x}-{y}";
        newTile.transform.position = TileMatrix.TileCoordinatesToPosition(x, y);

        return newTile;
    }
    
    public void Generate()
    {
        var rows = TileMatrix.Rows;
        var columns = TileMatrix.Columns;
        for (var i = -rows/2; i < (rows + 1) / 2; i++)
        {
            var temporaryList = new TileContainer();
            for (var j = -columns / 2; j < (columns + 1) / 2; j++)
            {
                temporaryList.TileList.Add(InstantiateNewTile(i, j));
            }
            TileMatrix.Tiles.Add(temporaryList);
        }
    }

   
}
