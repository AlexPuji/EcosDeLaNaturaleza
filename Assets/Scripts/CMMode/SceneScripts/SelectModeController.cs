using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class SelectModeController : MonoBehaviour
{
    public Button CMButton;
    public Button FMButton;

    public string level1CMScene = "LoadingScene";
    public string level1Scene = "Level1";

    private static SelectModeController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CMButton.onClick.AddListener(LoadLevel1CM);
        FMButton.onClick.AddListener(LoadLevel1);
    }

    private void LoadLevel1CM()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level1CMScene);
    }

    private void LoadLevel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level1Scene);
    }
}
