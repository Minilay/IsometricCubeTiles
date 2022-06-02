using System;
using System.Collections;
using System.Collections.Generic;
using Client.Scripts;
using Client.Scripts.ExtensionMethods;
using Client.Scripts.Objects;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TileGenerator))]
public class TileSelector : MonoBehaviour
{
    [SerializeField] private float _shiftDistance;
    [Range(1, 10)]
    [SerializeField] private float _selectionCurve;
    
    
    private TileData _tileData;
    
    private Camera _camera;

    private int _rows;
    private int _columns;
    private float _tileDistance;
    
    private Vector2Int _oldPosition;
    
    public void Init()
    {
        _camera = Camera.main;

        _tileData = GetComponent<TileGenerator>().TileData;
        
        _rows = _tileData.Rows;
        _columns = _tileData.Columns;
        _tileDistance = _tileData.Distance;
    }

    

    private float GetShiftAmount(Vector2Int tilePosition, Vector2Int mousePosition)
    {
        var distance = Utils.GetDistanceBetweenTwoPoints(tilePosition, mousePosition);
        var curve = 1 / (distance + _selectionCurve);
        return curve * _shiftDistance;
    }
    private void SelectTileWave(Vector2Int mousePosition)
    {
        for(var i = 0; i < _rows; i++)
            for (var j = 0; j < _columns; j++)
                _tileData.Tiles[i].TileList[j]
                    .ShiftTilesY(
                        GetShiftAmount(
                            new Vector2Int(i, j),
                            mousePosition
                    ));
    }

    private Vector2 GetMousePosition() => _camera.ScreenToWorldPoint(Input.mousePosition);
        

    private Vector2Int MouseIsometricPosition()
    {
        var mousePosition = GetMousePosition();
        
        var x = (mousePosition.x + 2 * mousePosition.y - 0.5f) / _tileDistance + _rows / 2.0f;
        var y = (-mousePosition.x + 2 * mousePosition.y - 0.5f) / _tileDistance + _columns / 2.0f;
        
        Utils.LimitValue(ref x, 0, _rows - 1);
        Utils.LimitValue(ref y, 0, _columns - 1);
        
        return new Vector2(x, y).Vector2IntConstructor();
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