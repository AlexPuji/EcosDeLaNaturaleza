using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSound : MonoBehaviour
{
    public AudioSource shootAudioSource;

    public void PlayShootSound()
    {
        if (shootAudioSource != null)
        {
            shootAudioSource.Play();
        }
    }
}
