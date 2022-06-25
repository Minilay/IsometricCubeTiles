using UnityEngine;
using UnityEngine.Events;

public class Knob : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private UnityEvent _onValueChanged;
    
    
    public void OnDrag()
    {
        SetKnobPosition();
        _onValueChanged.Invoke();
    }

    private void SetKnobPosition()
    {
        transform.localPosition = _joystick.ClampKnobPosition(Utils.GetMousePositionOnUI(_joystick.transform));
    }

    
   
}
