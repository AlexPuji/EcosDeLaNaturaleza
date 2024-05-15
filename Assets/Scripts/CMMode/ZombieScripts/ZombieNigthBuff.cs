using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNigthBuff : MonoBehaviour
{
    public float nightSpeedBoost = 1f; //buff de nit

    private float originalSpeed; 
    private EnemyDetection enemyDetection; 

    void Start()
    {
        enemyDetection = GetComponent<EnemyDetection>(); 
        originalSpeed = enemyDetection.movementSpeed; 
    }

    void Update()
    {
        if (DayNightCycle.IsNight())
        {
            ApplyNightBuff();
        }
    }

    void ApplyNightBuff()
    {
        //augment de velocitat
        enemyDetection.movementSpeed = originalSpeed + nightSpeedBoost;
    }
}
