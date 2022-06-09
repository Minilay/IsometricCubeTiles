using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private RectTransform _menu;
    [SerializeField] private RectTransform _arrow;
    
    [SerializeField] private float _transitionSpeed;
    [SerializeField] private Button _button;
    private float _menuOffset; 

    private bool _isOpen;

    private void Awake()
    {
        _isOpen = false;

        _menuOffset = _menu.sizeDelta.x; 
    }

    public void OnMouseDown()
    {
        StartCoroutine(MenuOpening(_isOpen ?_menuOffset : 0, _isOpen ? 0f : 180f));
        _isOpen = !_isOpen; 

    }

    private IEnumerator MenuOpening(float endPosition, float endAngle)
    {
        _button.enabled = false;
        
        var position = _menu.anchoredPosition.x;
        var angle = _arrow.eulerAngles.z; 
        
        while (Mathf.Abs(endPosition - position) > 0.5f)
        {
            position = Mathf.Lerp(position, endPosition,  Time.deltaTime * _transitionSpeed);
            angle = Mathf.Lerp(angle, endAngle, Time.deltaTime * _transitionSpeed);
            
            _menu.anchoredPosition = new Vector2(position, 0);
            _arrow.eulerAngles = new Vector3(0, 0, angle);
            
            yield return null;
        }
        _menu.anchoredPosition = new Vector2(endPosition, 0);
        _arrow.eulerAngles = new Vector3(0, 0, endAngle);
        
        _button.enabled = true;

    }
    
}
