using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalMusicController : MonoBehaviour
{
    public static GlobalMusicController instance;

    private AudioSource audioSource;

    // Definir los clips de audio para las diferentes escenas
    public AudioClip mainMenuMusic;
    public AudioClip selectModeMusic;
    public AudioClip optionsMusic;
    public AudioClip loadingSceneMusic;
    public AudioClip loadingScene1Music;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();

        // Asegurarse de que hay un AudioSource
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Escuchar eventos de cambio de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Detener la música si la escena es una escena de juego
        if (scene.name == "Level 1 CM" || scene.name == "Level 1" || scene.name == "House1CM")
        {
            StopMusic();
            return;
        }

        // Cambiar la música según el nombre de la escena
        switch (scene.name)
        {
            case "MainMenu":
                PlayMusic(mainMenuMusic);
                break;
            case "SelectMode":
                PlayMusic(selectModeMusic);
                break;
            case "Options":
                PlayMusic(optionsMusic);
                break;
            case "LoadingScene":
                PlayMusic(loadingSceneMusic);
                break;
            case "LoadingScene1":
                PlayMusic(loadingScene1Music);
                break;
                // Añadir más casos según sea necesario
        }
    }

    void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public float GetVolume()
    {
        return audioSource.volume;
    }
}
