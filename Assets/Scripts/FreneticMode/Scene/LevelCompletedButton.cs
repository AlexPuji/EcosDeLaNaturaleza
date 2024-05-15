using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletedButton : MonoBehaviour
{
    public GameManager gameManager;
    public Button restartButton;
    public Button menuButton;

    private void Start()
    {
        
        menuButton.onClick.AddListener(ReturnToMenu);
    }

    

    private void ReturnToMenu()
    {
        Debug.Log("Menu button clicked");
        gameManager.MainMenu();
    }
}
