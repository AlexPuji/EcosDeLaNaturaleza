using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public Button playButton;
    public string sceneToLoad = "Level 2"; //Poner Nombre de la escena que toque

    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        if (sceneLoader == null)
        {
            Debug.LogError("No se encontró un objeto SceneLoader en la escena.");//Revisar si salta debug
        }

        playButton.onClick.AddListener(LoadNextScene);//Em donava  error el click
    }

    private void LoadNextScene()
    {
        if (sceneLoader != null)
        {
            sceneLoader.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("No se puede cargar la escena porque no se encontró un objeto SceneLoader.");// Revisar si salta debug
        }
    }
}
