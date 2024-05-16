using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int shotsToDie = 3;
    private int shotsReceived = 0;
    public TextController textController;
    public MisionManager missionManager;

    
    public bool ContributesToMission = true;

    void Start()
    {
        //Scripts para misiones y texto
        textController = FindObjectOfType<TextController>();
        missionManager = FindObjectOfType<MisionManager>();
    }

    public void TakeDamage()
    {
        shotsReceived++;
        //morir Tiros
        if (shotsReceived >= shotsToDie)
        {
            Die();
        }
    }

    void Die()
    {
        // contar puntos 
        if (textController != null)
        {
            textController.SumarPuntos(100);
        }

        //contar muerte
        if (missionManager != null && ContributesToMission)
        {
            //missionManager.EnemyKilled();
        }

        Destroy(gameObject);
    }


}
