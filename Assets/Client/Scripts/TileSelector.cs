using System;
using System.Collections;
using System.Collections.Generic;
using Client.Scripts;
using Client.Scripts.Objects;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TileGenerator))]
public class TileSelector : MonoBehaviour
{
    [SerializeField] private float _shiftDistance;
    [Range(1, 10)]
    [SerializeField] private float _selectionCurve;
    
    
    private TileMatrix _tileMatrix;
    
    private Camera _camera;

    private int _rows;
    private int _columns;
    private float _tileDistance;
    
    private Coordinate _oldPosition;
    
    public void Init()
    {
        _camera = Camera.main;

        _tileMatrix = GetComponent<TileGenerator>().TileMatrix;
        
        _rows = _tileMatrix.Rows;
        _columns = _tileMatrix.Columns;
        _tileDistance = _tileMatrix.Distance;
    }

    

    private float GetShiftAmount(Coordinate tilePosition, Coordinate mousePosition)
    {
        var distance = Coordinate.GetDistance(tilePosition, mousePosition);
        var curve = 1 / (distance + _selectionCurve);
        return curve * _shiftDistance;
    }
    private void SelectTileWave(Coordinate mousePosition)
    {
        for(var i = 0; i < _rows; i++)
            for (var j = 0; j < _columns; j++)
                _tileMatrix.Tiles[i].TileList[j]
                    .ShiftTilesY(
                        GetShiftAmount(
                            new Coordinate(i, j),
                            mousePosition
                    ));
    }

    private Vector2 GetMousePosition() => _camera.ScreenToWorldPoint(Input.mousePosition);
        

    private Coordinate MouseIsometricPosition()
    {
        var mousePosition = GetMousePosition();
        
        var x = (mousePosition.x + 2 * mousePosition.y - 0.5f) / _tileDistance + _rows / 2.0f;
        var y = (-mousePosition.x + 2 * mousePosition.y - 0.5f) / _tileDistance + _columns / 2.0f;
        
        Utils.LimitValue(ref x, 0, _rows - 1);
        Utils.LimitValue(ref y, 0, _columns - 1);
        
        return new Coordinate(x, y);
    }
    
    
    private void FixedUpdate()
    {
        var mouseCoordinates = MouseIsometricPosition();

        if (mouseCoordinates != _oldPosition)
        {
            SelectTileWave(mouseCoordinates); 
        }

        _oldPosition = mouseCoordinates;

    }
}
