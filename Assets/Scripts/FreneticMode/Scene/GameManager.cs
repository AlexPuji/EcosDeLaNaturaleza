using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += HandlePlayerDeath; 
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= HandlePlayerDeath;
    }

    private void HandlePlayerDeath()
    {
        
        SceneManager.LoadScene("LevelCompleted");
    }

    public void PlayerDied()
    {
        //Cargar escena LevelCompleted
        SceneManager.LoadScene("LevelCompleted");
    }

    public void LevelCompleted()
    {
        //Implementar en cas de que sigui necessari pero de moment ja sha trobat solucio.
    }

    /*
    public void RestartLevel()
    {
        // Reiniciar amb Restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    */
    public void MainMenu()
    {
        // Tornar al Menu
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        // Sortir del joc en cas de tenir Build
        Application.Quit();
    }
}
