using System;
using UnityEngine;
using UnityEngine.UI;

public class HoverController : MonoBehaviour
{
    [SerializeField] private TileSelector _tileSelector;
    [SerializeField] private DoubleSlider _doubleSlider;
    [SerializeField] private float _shiftRange;
    [SerializeField] private Vector2 _curveRange;


    private void Start()
    {
        _doubleSlider.SetKnobPositionByValue(
            new Vector2(
                     _tileSelector.ShiftDistance / _shiftRange,
                     (_tileSelector.Curve - _curveRange.x) / (_curveRange.y - _curveRange.x)
                )
            );
    }

    public void ApplyUIChanges(Vector2 value)
    {
        _tileSelector.ShiftDistance = value.x * _shiftRange;
        _tileSelector.Curve = (_curveRange.y - _curveRange.x) * value.y + _curveRange.x; 
    }
    
}
