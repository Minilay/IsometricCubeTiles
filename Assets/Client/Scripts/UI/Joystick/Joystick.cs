using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] private List<float> _snapPositionsInPercent;
    [SerializeField] private float _snapDistance;
    private float _joystickSize;

    [SerializeField] private Transform _redKnob;
    [SerializeField] private Transform _blueKnob;

    public Vector2 GetRedKnobValue() => CalculateKnobValue(_redKnob.localPosition);
    public Vector2 GetBlueKnobValue() => CalculateKnobValue(_blueKnob.localPosition);

    public void SetRedKnobValue(float angle, float distance)
    {
        _redKnob.localPosition = CalculateKnobPosition(angle, distance);
    }

    public void SetBlueKnobValue(float angle, float distance)
    {
        _blueKnob.localPosition = CalculateKnobPosition(angle, distance);
    }

    private Vector2 CalculateKnobPosition(float angle, float distance) =>
        Utils.AngleToVector(angle - 135) * distance * _joystickSize;


    private void Awake()
    {
        _joystickSize = GetComponent<RectTransform>().rect.width / 2;
    }


    private Vector2 CalculateKnobValue(Vector2 position) => position / _joystickSize;

    public Vector2 ClampKnobPosition(Vector2 position)
    {
        RestrictKnobPosition(ref position);
        SnapKnobPosition(ref position);

        return position;
    }

    private void RestrictKnobPosition(ref Vector2 position) => position =
        Vector2.ClampMagnitude(position, _joystickSize);

    private void SnapKnobPosition(ref Vector2 position)
    {
        SnapKnobAlongCircles(ref position);
        SnapKnobAlongCross(ref position);
    }

    private void SnapKnobAlongCircles(ref Vector2 position)
    {
        foreach (var snapRadius in _snapPositionsInPercent)
        {
            if (Mathf.Abs(position.magnitude - _joystickSize * snapRadius) <= _snapDistance)
            {
                position = position.normalized * _joystickSize * snapRadius;
            }
        }
    }

    private void SnapKnobAlongCross(ref Vector2 position)
    {
        if (Mathf.Abs(position.x) <= _snapDistance)
        {
            position = new Vector2(0, position.y);
        }

        if (Mathf.Abs(position.y) <= _snapDistance)
        {
            position = new Vector2(position.x, 0);
        }

        if (Mathf.Abs(position.x - position.y) <= _snapDistance)
        {
            position = Vector2.one * ((position.x + position.y) / 2);
        }

        if (Mathf.Abs(position.x + position.y) <= _snapDistance)
        {
            position = new Vector2(1, -1) * (position.x - position.y) / 2;
        }
    }
}