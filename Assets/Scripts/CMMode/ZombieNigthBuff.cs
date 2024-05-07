using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNigthBuff : MonoBehaviour
{
    public float nightSpeedBoost = 1f; // Aumento de velocidad durante la noche

    private float originalSpeed; // Velocidad original del zombie
    private EnemyDetection enemyDetection; // Referencia al script EnemyDetection

    void Start()
    {
        enemyDetection = GetComponent<EnemyDetection>(); // Obtener referencia al script EnemyDetection
        originalSpeed = enemyDetection.movementSpeed; // Guardar la velocidad original del zombie
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
        // Aumentar la velocidad del zombie durante la noche
        enemyDetection.movementSpeed = originalSpeed + nightSpeedBoost;
    }
}
