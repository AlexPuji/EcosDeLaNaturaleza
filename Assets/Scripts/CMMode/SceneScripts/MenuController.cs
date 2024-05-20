using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button playButton; // Botón para jugar
    public Button optionsButton; // Botón para opciones

    public string sceneToLoad = "SelectMode"; // Nombre de la escena a cargar para jugar
    public string optionsScene = "Options"; // Nombre de la escena a cargar para opciones

    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        if (sceneLoader == null)
        {
            Debug.LogError("No se encontró un objeto SceneLoader en la escena."); // Revisar si salta debug
        }

        playButton.onClick.AddListener(LoadNextScene); // Asignar evento al botón de jugar
        optionsButton.onClick.AddListener(LoadOptionsScene); // Asignar evento al botón de opciones
    }

    private void LoadNextScene()
    {
        if (sceneLoader != null)
        {
            sceneLoader.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("No se puede cargar la escena porque no se encontró un objeto SceneLoader."); // Revisar si salta debug
        }
    }

    private void LoadOptionsScene()
    {
        if (sceneLoader != null)
        {
            sceneLoader.LoadScene(optionsScene);
        }
        else
        {
            Debug.LogError("No se puede cargar la escena de opciones porque no se encontró un objeto SceneLoader."); // Revisar si salta debug
        }
    }
}
