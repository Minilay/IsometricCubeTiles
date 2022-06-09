using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _waveUI;
    [SerializeField] private GameObject _hoverUI;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private GameSystem _gameSystem;
    
 
    private bool _isInHoverMode; 
    private void Awake()
    {
        _isInHoverMode = false;
        _buttonText.text = "Switch to Hover Mode";
    }

    
    public void OnHoverModeClick()
    {
        _gameSystem.Switch();
        
        _buttonText.text = _isInHoverMode ? "Switch to Hover Mode" : "Switch to Wave Mode";

        _waveUI.SetActive(_isInHoverMode);
        _hoverUI.SetActive(!_isInHoverMode);
       
        _isInHoverMode = !_isInHoverMode; 
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}