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
        textController = FindObjectOfType<TextController>();
        missionManager = FindObjectOfType<MisionManager>();
    }

    public void TakeDamage()
    {
        shotsReceived++;

        if (shotsReceived >= shotsToDie)
        {
            Die();
        }
    }

    void Die()
    {
        if (textController != null)
        {
            textController.SumarPuntos(100);
        }

        
        if (missionManager != null && ContributesToMission)
        {
            missionManager.EnemyKilled();
        }

        Destroy(gameObject);
    }


}
