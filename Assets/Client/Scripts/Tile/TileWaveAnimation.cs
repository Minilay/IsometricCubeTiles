using Client.Scripts;
using Client.Scripts.Objects;
using UnityEngine;
using TileData = Client.Scripts.Objects.TileData;

[RequireComponent(typeof(TileGenerator))]
public class TileWaveAnimation : MonoBehaviour
{
    [field: SerializeField] public WaveData WaveData { get; set; }

    private TileData _tileData;

    private float _time;


    private void Start()
    {
        _tileData = GetComponent<TileGenerator>().TileData;
    }


    private float CalculateTilePhase(Vector2Int position, float angle) =>
        Vector2.Dot(
            Utils.AngleToVector(angle),
            position
        );

    private float TileShiftAmount(Vector2Int position) =>
        new HarmonicMotion(WaveData.FirstWave, CalculateTilePhase(position, WaveData.FirstWave.WaveAngle))
            .GetPosition(_time) *
        new HarmonicMotion(WaveData.SecondWave, CalculateTilePhase(position, WaveData.SecondWave.WaveAngle))
            .GetPosition(_time);

    private void Update()
    {
        _time += Time.deltaTime;

        for (var i = 0; i < _tileData.Rows; i++)
        {
            for (var j = 0; j < _tileData.Columns; j++)
            {
                _tileData.Tiles[i].TileList[j].ShiftTilesY(TileShiftAmount(new Vector2Int(i, j)));
            }
        }
    }
}