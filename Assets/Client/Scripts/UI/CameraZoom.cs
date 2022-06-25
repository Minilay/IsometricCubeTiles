using System;
using System.Collections;
using System.Collections.Generic;
using Client.Scripts.ExtensionMethods;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Vector2 _zoomRange;
    [SerializeField] private float _zoomSpeed;
    [Range(0, 1)]
    [SerializeField] private float _zoomSmoothness;
    
    private Camera _camera;
    private bool _isZooming;
    private IEnumerator _currentCoroutine;
    private float _targetZoom;
    private void OnValidate()
    {
        if (_zoomSpeed < 0) _zoomSpeed = 0;
        if (_zoomRange.x > _zoomRange.y) _zoomRange.x = _zoomRange.y;
    }

    private void Awake()
    {
        _camera = Camera.main;
        _targetZoom = _camera.orthographicSize;
    }

    private void Update()
    {
       ZoomOnMouseWheel();
       ZoomOnSensor();
    }

    private void ZoomOnSensor()
    {
        if (Input.touchCount != 2) return;
        
        SetTargetZoom(_targetZoom - GetZoomOnSensorAmount() * 0.02f);
        _camera.orthographicSize = _targetZoom;
    }

    private float GetZoomOnSensorAmount()
    {
        var touchZero = Input.GetTouch(0);
        var touchOne = Input.GetTouch(1);

        return  
            Utils.GetDistance(touchZero.position, touchOne.position) - 
            Utils.GetDistance(touchZero.GetPrevious(), touchOne.GetPrevious()); 
    }
    private void ZoomOnMouseWheel()
    {
        SetTargetSizeOnMouseWheel();
        ZoomToTargetSize();
    }

    private void SetTargetSizeOnMouseWheel()
    {
        switch (Input.GetAxis("Mouse ScrollWheel"))
        {
            case > 0:
                SetTargetZoom(_targetZoom - _zoomSpeed);
                break;
            case < 0:
                SetTargetZoom(_targetZoom + _zoomSpeed);
                break;
        }
    }

    private void ZoomToTargetSize()
    {
        if (_isZooming)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = SmoothZoom();
        StartCoroutine(_currentCoroutine);
    }
    private void SetTargetZoom(float zoomAmount)
    {
        _targetZoom = zoomAmount;
        _targetZoom = Mathf.Clamp(_targetZoom, _zoomRange.x, _zoomRange.y);
    }
    private IEnumerator SmoothZoom()
    {
        _isZooming = true;

        var _currentZoom = _camera.orthographicSize;
        while (!_currentZoom.ApproximatelyEqual(_targetZoom))
        {
            var size = _camera.orthographicSize;
            _camera.orthographicSize = Mathf.Lerp(size, _targetZoom, _zoomSmoothness);

            yield return null;
        }
        _camera.orthographicSize = _targetZoom;

        _isZooming = false;
    }

}
