using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    public Button returnButton; // Asigna el botón desde el inspector
    public string mainMenuScene = "MainMenu"; // Nombre de la escena del menú principal

    private void Start()
    {
        if (returnButton != null)
        {
            returnButton.onClick.AddListener(ReturnToMainMenu);
        }
        else
        {
            Debug.LogError("El botón no está asignado en el inspector.");
        }
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
