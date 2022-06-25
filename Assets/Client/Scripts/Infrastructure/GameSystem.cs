using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private TileGenerator _tileGenerator;
    [SerializeField] private TileSelector _tileSelector;
    [SerializeField] private TileWaveAnimation tileWaveAnimation;


    private bool _isInHoverMode; 
    private void Awake()
    {
        _tileGenerator.Generate();
        _tileSelector.Init();

        _isInHoverMode = false;
    }

    public void Switch()
    {
        _isInHoverMode = !_isInHoverMode; 
        _tileSelector.enabled = _isInHoverMode;
        tileWaveAnimation.enabled = !_isInHoverMode;
    }

    
}
