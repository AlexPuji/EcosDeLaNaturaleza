using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenFM : MonoBehaviour
{
    public Slider slider;
    public float loadingTime = 20f; // Loading time in seconds
    public string targetLevelName = "Level 1"; // Name of the level you want to load
    public GameObject pressAnyButtonMessage; // Reference to the "Press any button" message GameObject

    private void Start()
    {
        // Start loading the level asynchronously
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        float timer = 0f;
        bool showMessage = false;

        // While the timer is less than the loading time, update the slider value
        while (timer < loadingTime)
        {
            timer += Time.deltaTime; // Increase the timer by the time passed since the last frame
            float progress = Mathf.Clamp01(timer / loadingTime); // Calculate the progress based on the timer and loading time
            slider.value = progress; // Update the slider value

            // If the timer reaches 20 seconds and the message hasn't been shown yet, show the message
            if (timer >= 20f && !showMessage)
            {
                pressAnyButtonMessage.SetActive(true); // Show the message
                showMessage = true; // Set the flag to true to indicate that the message has been shown
            }

            yield return null; // Wait for one frame before continuing
        }

        // Wait for the player to press any button
        while (!Input.anyKeyDown)
        {
            yield return null; // Wait for one frame before checking input again
        }

        // Start loading the level asynchronously after the loading time has passed
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(targetLevelName);

        // While the level is loading, update the slider value
        while (!loadingOperation.isDone)
        {
            float progress = Mathf.Clamp01(loadingOperation.progress / 0.9f); // Normalize the progress between 0 and 1
            slider.value = progress; // Update the slider value
            yield return null; // Wait for one frame before continuing
        }
    }
}
