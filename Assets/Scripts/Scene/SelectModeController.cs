using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static MisionManager;

public class SelectModeController : MonoBehaviour
{
    public Button easyButton;
    public Button normalButton;
    public Button hardButton;

    public string level1Scene = "Level1";

    private string selectedDifficulty;
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
        easyButton.onClick.AddListener(() => SelectDifficulty("easy"));
        normalButton.onClick.AddListener(() => SelectDifficulty("normal"));
        hardButton.onClick.AddListener(() => SelectDifficulty("hard"));
    }

    private void SelectDifficulty(string difficulty)
    {
        selectedDifficulty = difficulty;
        LoadLevel(level1Scene);
    }

    private void LoadLevel(string levelScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelScene);
    }

    public string GetSelectedDifficulty()
    {
        return selectedDifficulty;
    }
}
