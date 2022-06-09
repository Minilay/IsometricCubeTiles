using System;
using Client.Scripts.Tools;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private TileWaveAnimation _tileWaveAnimation;
    [SerializeField] private Slider _amplitudeSlider;
    [SerializeField] private Slider _periodSlider;
    [SerializeField] private Slider _wavelengthSlider;
    
    [SerializeField] private Image _directionArrow;
    [SerializeField]private Transform _arrowTransform;
   
    private WaveParameters _waveParameters;
    
    private void Awake()
    {
        _waveParameters = _tileWaveAnimation.WaveParameters;
        
        _amplitudeSlider.value = _waveParameters.Amplitude;
        _periodSlider.value = _waveParameters.Period;
        _wavelengthSlider.value = _waveParameters.WaveLength;
        
        _directionArrow.transform.eulerAngles = new Vector3(0, 0, _waveParameters.WaveDirectionAngle + 135);

    }
    
    public void OnAmplitudeSliderChange(float value) => _waveParameters.Amplitude = value;
    public void OnPeriodSliderChange(float value) => _waveParameters.Period = value;
    public void OnWaveLengthSliderChange(float value) => _waveParameters.WaveLength = value;

    public void OnParametersChange() => _tileWaveAnimation.WaveParameters = _waveParameters;


    private float GetDirectionAngle()
    {
        var pos = _arrowTransform.InverseTransformPoint(Input.mousePosition);

        return Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
    }
    
    public void OnPointerDrag()
    {

        var angle = GetDirectionAngle();
        _directionArrow.transform.eulerAngles = new Vector3(0, 0, angle - 90);

        _waveParameters.WaveDirectionAngle = angle + 135;
    }

}
