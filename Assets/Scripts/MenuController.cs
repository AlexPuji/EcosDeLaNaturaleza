using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public Button playButton;
    public string sceneToLoad = "Scene/SampleScene"; // Ajustar el nombre de la escena aquí

    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        if (sceneLoader == null)
        {
            Debug.LogError("No se encontró un objeto SceneLoader en la escena.");
        }

        playButton.onClick.AddListener(LoadNextScene);
    }

    private void LoadNextScene()
    {
        if (sceneLoader != null)
        {
            sceneLoader.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("No se puede cargar la escena porque no se encontró un objeto SceneLoader.");
        }
    }
}
