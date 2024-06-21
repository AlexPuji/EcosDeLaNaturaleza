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
    public AudioClip finalSceneMusic; // Nuevo AudioClip para FinalScene
    public AudioClip level1CMMusic; // Nuevo AudioClip para Level 1 CM
    public AudioClip level1Music; // Nuevo AudioClip para Level 1
    public AudioClip house1CMMusic; // Nuevo AudioClip para House1CM

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

        // Configurar el audio source para que haga loop por defecto
        audioSource.loop = true;

        // Escuchar eventos de cambio de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
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
            case "Final Scene": // Nuevo caso para FinalScene
                PlayMusic(finalSceneMusic);
                break;
            case "Level 1 CM":
                PlayMusic(level1CMMusic);
                break;
            case "Level 1":
                PlayMusic(level1Music);
                break;
            case "House1CM":
                PlayMusic(house1CMMusic);
                break;
            default:
                StopMusic();
                break;
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

    void OnDestroy()
    {
        // Desuscribirse del evento de cambio de escena
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
