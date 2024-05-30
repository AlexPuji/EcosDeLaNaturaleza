using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionSound : MonoBehaviour
{
    public AudioSource enemyCollisionSound; // Referencia al AudioSource del sonido de colisión del enemigo

    public void PlayEnemyCollisionSound()
    {
        if (enemyCollisionSound != null)
        {
            enemyCollisionSound.Play();
        }
        else
        {
            Debug.LogWarning("Enemy collision sound is not assigned!");
        }
    }
}
