using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int shotsToDie = 3;
    private int shotsReceived = 0;
    public TextController textController;
    public KillZombiesMission killZombiesMission; 

    public bool ContributesToMission = true;

    void Start()
    {
        // Scripts para misiones y texto
        textController = FindObjectOfType<TextController>();
        killZombiesMission = FindObjectOfType<KillZombiesMission>(); 
    }

    public void TakeDamage()
    {
        shotsReceived++;
        // Morir por Tiros
        if (shotsReceived >= shotsToDie)
        {
            Die();
        }
    }

    void Die()
    {
        // Contar puntos 
        if (textController != null)
        {
            textController.SumarPuntos(100);
        }

        // Contar muerte en la misión
        if (killZombiesMission != null && ContributesToMission)
        {
            //killZombiesMission.EnemyKilled();
        }

        Destroy(gameObject);
    }


}
