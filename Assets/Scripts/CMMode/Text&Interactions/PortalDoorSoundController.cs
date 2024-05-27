using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDoorSoundController : MonoBehaviour
{
    public static PortalDoorSoundController Instance { get; private set; }

    public AudioSource portalSound; // Asigna el clip de audio del portal desde el Inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Mantén este objeto entre escenas
    }

    public void PlayPortalSound()
    {
        if (portalSound != null)
        {
            portalSound.Play();
        }
    }

    public float GetPortalSoundDuration()
    {
        if (portalSound != null)
        {
            return portalSound.clip.length;
        }
        else
        {
            return 0f;
        }
    }
}
