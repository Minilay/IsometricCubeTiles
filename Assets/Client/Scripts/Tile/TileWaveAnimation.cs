using Client.Scripts;
using Client.Scripts.Tools;
using UnityEngine;
using TileData = Client.Scripts.Objects.TileData;

[RequireComponent(typeof(TileGenerator))]
public class TileWaveAnimation : MonoBehaviour
{
    [field: SerializeField] public WaveParameters WaveParameters { get;  set; }
    private TileData _tileData;
    
    private float _time;

   
    private void Start()
    {
        _tileData = GetComponent<TileGenerator>().TileData;
    }


    private float PhaseByTilePosition(int i, int j) => 
        Vector2.Dot(
            Utils.AngleToVector(WaveParameters.WaveDirectionAngle),
            new Vector2(i, j)
            );

    private float TileShiftAmount(int i, int j) =>
        new HarmonicMotion(WaveParameters, PhaseByTilePosition(i, j))
            .GetPosition(_time);
   
    private void Update()
    {
        _time += Time.deltaTime;
        
        for (var i = 0; i < _tileData.Rows; i++)
        {
            for (var j = 0; j < _tileData.Columns; j++)
            {
                _tileData.Tiles[i].TileList[j].ShiftTilesY(TileShiftAmount(i, j));
            }
        }
    }
}
