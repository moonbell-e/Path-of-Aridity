using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _newGameButton;


    [Header("Volume Settings")]
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private float _defaultVolume = 1.0f;
    [SerializeField] private AudioMixer _audioMixer;

    [Header("Levels To Load")]
    [SerializeField] private string _newGameLevel;

    [Header("Graphics Settings")]
    [SerializeField] private TMP_Dropdown _qualityDropdown;
    [SerializeField] private Toggle _fullScreenToggle;

    [Header("Resolution Dropdowns")]
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    private Resolution[] _resolutions;


    private int _qualityLevel;
    private bool _isFullScreen;

    private void Start()
    {
        if(PlayerPrefs.HasKey("NewGameStarted"))
        {
            _playButton.SetActive(true);
            Destroy(_newGameButton);
        }


        if (!PlayerPrefs.HasKey("AddedResolutions"))
        {
            _resolutions = Screen.resolutions;

            List<string> _options = new List<string>();

            int _currentResolutionIndex = 0;

            for (int i = 0; i < _resolutions.Length; i++)
            {
                string _option = _resolutions[i].width + " x " + _resolutions[i].height + " " + _resolutions[i].refreshRate + " Hz";
                _options.Add(_option);
                Debug.Log("Added");
                if (_resolutions[i].width == Screen.width && _resolutions[i].height == Screen.height)
                    _currentResolutionIndex = i;
            }

            _resolutionDropdown.AddOptions(_options);
            _resolutionDropdown.value = _currentResolutionIndex;
            _resolutionDropdown.RefreshShownValue();
        }
    }




    public void StartingNewGame()
    {
        //PlayerPrefs.SetInt("AddedResolutions", 1);
        SceneManager.LoadScene(_newGameLevel);
    }

    public void ExitGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("Volume", volume);
    }

    public void ResetVolume()
    {
        _volumeSlider.value = _defaultVolume;
    }



    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex;
        QualitySettings.SetQualityLevel(_qualityLevel);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution _resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(_resolution.width, _resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        _isFullScreen = isFullScreen;
        Screen.fullScreen = _isFullScreen;
    }

    public void ResetGraphics()
    {
        _qualityDropdown.value = 1;
        QualitySettings.SetQualityLevel(1);

        _fullScreenToggle.isOn = false;
        Screen.fullScreen = false;

        Resolution _currentResolution = Screen.currentResolution;
        Screen.SetResolution(_currentResolution.width, _currentResolution.height, Screen.fullScreen);
        _resolutionDropdown.value = _resolutions.Length;
    }

}
