using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionController : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions = new Resolution[]
    {
        new Resolution { width = 800, height = 600 },
        new Resolution { width = 1280, height = 720 },
        new Resolution { width = 1360, height = 768 },
        new Resolution { width = 1440, height = 900 },
        new Resolution { width = 1680, height = 1050 },
        new Resolution { width = 1856, height = 1392 },
        new Resolution { width = 1920, height = 1080 },
        new Resolution { width = 2560, height = 1440 }
    };

    void Start()
    {
        PopulateResolutionDropdown();
        LoadSettings();

        // Asignar eventos programáticamente
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(resolutionDropdown.value); });
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(fullscreenToggle.isOn); });
    }

    void PopulateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        foreach (Resolution res in resolutions)
        {
            options.Add(res.width + " x " + res.height);
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(resolutionDropdown.value); });
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(fullscreenToggle.isOn); });

        // Load saved resolution if it exists
        int savedResolutionIndex = PlayerPrefs.GetInt("resolutionIndex", 0);
        resolutionDropdown.value = savedResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        OnResolutionChange(savedResolutionIndex);
    }

    void OnResolutionChange(int index)
    {
        Resolution selectedResolution = resolutions[index];
        bool isFullscreen = fullscreenToggle.isOn;
        Debug.Log("Changing resolution to: " + selectedResolution.width + " x " + selectedResolution.height + " Fullscreen: " + isFullscreen);
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, isFullscreen);
        PlayerPrefs.SetInt("resolutionIndex", index);
    }

    void OnFullscreenToggle(bool isFullscreen)
    {
        Debug.Log("Changing fullscreen mode to: " + isFullscreen);
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("fullscreen", isFullscreen ? 1 : 0);
    }

    void LoadSettings()
    {
        int savedFullscreen = PlayerPrefs.GetInt("fullscreen", 1);
        fullscreenToggle.isOn = savedFullscreen == 1;
    }
}

