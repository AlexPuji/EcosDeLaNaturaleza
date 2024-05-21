using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private enum GameState
    {
        GamePlay,
        PauseMenu,
    }

    //Estat actual del joc
    private GameState currentState = GameState.GamePlay;

    
    public GameObject pauseMenuUI;

    void Start()
    {
       
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.GamePlay)
            {
                PauseGame();
            }
            else if (currentState == GameState.PauseMenu)
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        currentState = GameState.PauseMenu;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //Pausar el temps de l'escena
    }

    public void ResumeGame()
    {
        currentState = GameState.GamePlay;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //Tornar a iniciar el temps
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToSelectMode()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SelectMode");
    }

    public void GoToOptions()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Options");
    }
}
