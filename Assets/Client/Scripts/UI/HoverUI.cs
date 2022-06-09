using UnityEngine;
using UnityEngine.UI;

public class HoverUI : MonoBehaviour
{

    [SerializeField] private TileSelector _tileSelector;
    [SerializeField] private Slider _shiftSlider;
    [SerializeField] private Slider _curveSlider;


    private void Awake()
    {  
        _shiftSlider.value = _tileSelector.ShiftDistance;
        _curveSlider.value = _tileSelector.SelectionCurve;
    }
    
    

    public void OnShiftSliderChange(float value) => _tileSelector.ShiftDistance = value;
    public void OnCurveSliderChange(float value) => _tileSelector.SelectionCurve = value;

}
