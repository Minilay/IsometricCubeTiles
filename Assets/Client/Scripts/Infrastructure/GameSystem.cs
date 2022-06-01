using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private TileGenerator _tileGenerator;
    [SerializeField] private TileSelector _tileSelector;
    [SerializeField] private TileWaveAnimation tileWaveAnimation;
    
    private void Awake()
    {
        _tileGenerator.Generate();
        _tileSelector.Init();
    }

    public void Switch(bool flag)
    {
        _tileSelector.enabled = flag;
        tileWaveAnimation.enabled = !flag;
    }

    
}
