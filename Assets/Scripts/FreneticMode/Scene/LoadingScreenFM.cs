using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenFM : MonoBehaviour
{
    public Slider slider;
    public float loadingTime = 10f; 
    public string targetLevelName = "Level 1";
    public GameObject pressAnyButtonMessage; 

    private void Start()
    {
        
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        float timer = 0f;
        bool showMessage = false;

        
        while (timer < loadingTime)
        {
            timer += Time.deltaTime; 
            float progress = Mathf.Clamp01(timer / loadingTime); 
            slider.value = progress; 

            
            if (timer >= 10f && !showMessage)
            {
                pressAnyButtonMessage.SetActive(true); 
                showMessage = true; 
            }

            yield return null; 
        }

        
        while (!Input.anyKeyDown)
        {
            yield return null; 
        }

        
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(targetLevelName);

        
        while (!loadingOperation.isDone)
        {
            float progress = Mathf.Clamp01(loadingOperation.progress / 0.9f); 
            slider.value = progress;
            yield return null; 
        }
    }
}
