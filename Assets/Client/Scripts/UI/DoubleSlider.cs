using System;
using Client.Scripts.ExtensionMethods;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform), typeof(EventTrigger))]
public class DoubleSlider : MonoBehaviour
{
    [SerializeField] private Transform _knob;
    [SerializeField] private UnityEvent<Vector2> _onValueChange;

    [Header("Snapping settings")] [SerializeField]
    private bool _isSnapping;

    [SerializeField] private float _snapDistance;

    private Vector2 _pivot;
    private Vector2 _matrixSize;

    public void SetKnobPositionByValue(Vector2 value) => _knob.localPosition = value * _matrixSize;


    public void OnKnobDrag()
    {
        _knob.localPosition = GetMousePositionInMatrix();
        _onValueChange.Invoke(GetValue());
    }
    
    public Vector2 GetValue() => _knob.localPosition / _matrixSize;

    private void Awake()
    {
        var rectTransform = GetComponent<RectTransform>();
        var rect = rectTransform.rect;
        _matrixSize = new Vector2(
            rect.width, rect.height
        );

        _pivot = rectTransform.pivot;
    }

    private Vector2 GetMousePositionInMatrix()
    {
        var position = Utils.GetMousePositionOnUI(transform).ClampPosition(_matrixSize, _pivot);

        if (!_isSnapping) return position;


        var k = _matrixSize.y / _matrixSize.x;
        if (Mathf.Abs(position.x * k - position.y) <= _snapDistance)
        {
            position = new Vector2(1 / k, 1) * (position.x * k + position.y) / 2;
        }

        return position;
    }
}