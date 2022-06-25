using Client.Scripts.Objects;
using Client.Scripts.Tools;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    [SerializeField] private TileWaveAnimation _tileWaveAnimation;

    [Header("UI elements")] 
    [SerializeField] private Slider _amplitudeSlider;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private DoubleSlider _periodMatrix;

    [Header("Max Values")] 
    [SerializeField] private float _maxWavelength;
    [SerializeField] private Vector2 _periodRange;

    private bool _isSetUp;

    private void Start()
    {
        _isSetUp = false;
        SetUIDefault();
        _isSetUp = true;
    }

    private void SetUIDefault()
    {
        var waveData = _tileWaveAnimation.WaveData;
        var firstWave = waveData.FirstWave;
        var secondWave = waveData.SecondWave;
            
        _amplitudeSlider.value = firstWave.Amplitude * secondWave.Amplitude;

        _joystick.SetBlueKnobValue(firstWave.WaveAngle, firstWave.WaveLength / _maxWavelength);
        _joystick.SetRedKnobValue(secondWave.WaveAngle, secondWave.WaveLength / _maxWavelength);
        
        _periodMatrix.SetKnobPositionByValue(
            new Vector2(
                    firstWave.Period, 
                    secondWave.Period
                ) / _periodRange.y
            );
    }
    

    private void OnValidate()
    {
        if (_maxWavelength < 0)
            _maxWavelength = 0;

        if (_periodRange.x > _periodRange.y)
        {
            _periodRange.x = _periodRange.y;
        }

        if (_periodRange.x < 0)
            _periodRange.x = 0;
        if (_periodRange.y < 0)
            _periodRange.y = 0;
    }

    public void ApplyUIChanges()
    {
        if (!_isSetUp) return;
        _tileWaveAnimation.WaveData = GetValueFromUI();
    }

    private WaveData GetValueFromUI() =>  new (
            ConstructWave(_joystick.GetBlueKnobValue(), _periodMatrix.GetValue().x), 
            ConstructWave(_joystick.GetRedKnobValue(), _periodMatrix.GetValue().y)
            );

    private WaveParameters ConstructWave(Vector2 joystickPosition, float period) =>
        new(
            _amplitudeSlider.value,
            _periodRange.x + period * (_periodRange.y - _periodRange.x),
            joystickPosition.magnitude * _maxWavelength,
            Mathf.Atan2(joystickPosition.y, joystickPosition.x) * Mathf.Rad2Deg + 135
        );
}