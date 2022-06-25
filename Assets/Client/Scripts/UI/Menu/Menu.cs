using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _waveUI;
    [SerializeField] private GameObject _hoverUI;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private GameSystem _gameSystem;

    private bool _isInHoverMode;
    private bool _isFirstWaveConfigs;

    private void Awake()
    {
        _isInHoverMode = false;
    }
    

    public void OnHoverModeClick()
    {
        _gameSystem.Switch();

        _buttonText.text = _isInHoverMode ? "Hover Mode" : "Wave Mode";

        _waveUI.SetActive(_isInHoverMode);
        _hoverUI.SetActive(!_isInHoverMode);

        _isInHoverMode = !_isInHoverMode;
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}