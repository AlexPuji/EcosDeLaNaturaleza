using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerShootSound : MonoBehaviour
{
    public AudioClip shootSound;

    public void PlayShootSound()
    {
        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
        }
    }
}
