using Client.Scripts;
using UnityEngine;
using TileData = Client.Scripts.Objects.TileData;

[RequireComponent(typeof(TileGenerator))]
public class TileWaveAnimation : MonoBehaviour
{
    [SerializeField] private float _amplitude;
    [SerializeField] private float _period;
    [SerializeField] private float _waveLength;
    [Range(0, 360)]
    [SerializeField] private float _waveDirectionAngle;
    

    private TileData _tileData;
    private int _rows;
    private int _columns;
    private float _time;

   
    private void OnValidate()
    {
        if (_period <= 0)
            _period = 0.001f;
        
        if (_waveLength <= 0)
            _waveLength = 0.001f;
    }
    private void Start()
    {
        _tileData = GetComponent<TileGenerator>().TileData;
        _rows = _tileData.Rows;
        _columns = _tileData.Columns;
    }


    private float PhaseByTilePosition(int i, int j) => 
        Vector2.Dot(
            Utils.AngleToVector(_waveDirectionAngle),
            new Vector2(i, j)
            );

    private float TileShiftAmount(int i, int j) =>
        new HarmonicMotion(_amplitude, _period, _waveLength, PhaseByTilePosition(i, j))
            .GetPosition(_time);
   
    private void Update()
    {
        _time += Time.deltaTime;
        
        for (var i = 0; i < _rows; i++)
        {
            for (var j = 0; j < _columns; j++)
            {
                _tileData.Tiles[i].TileList[j].ShiftTilesY(TileShiftAmount(i, j));
            }
        }
    }
}
