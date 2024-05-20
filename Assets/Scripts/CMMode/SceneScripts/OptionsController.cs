using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
   //Botons i Panels
    public GameObject audioPanel;     
    public GameObject gameplayPanel;  
    public GameObject screenPanel;    

    public Button audioButton;        
    public Button gameplayButton;     
    public Button screenButton;       

    private void Start()
    {
        
        ShowScreenOptions();

        //Activar sol 1 panel
        audioButton.onClick.AddListener(ShowAudioOptions);
        gameplayButton.onClick.AddListener(ShowGameplayOptions);
        screenButton.onClick.AddListener(ShowScreenOptions);
    }
    //Per activar i desactiva panels
    private void ShowAudioOptions()
    {
        audioPanel.SetActive(true);
        gameplayPanel.SetActive(false);
        screenPanel.SetActive(false);
    }

    private void ShowGameplayOptions()
    {
        audioPanel.SetActive(false);
        gameplayPanel.SetActive(true);
        screenPanel.SetActive(false);
    }

    private void ShowScreenOptions()
    {
        audioPanel.SetActive(false);
        gameplayPanel.SetActive(false);
        screenPanel.SetActive(true);
    }
}
