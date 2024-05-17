using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillZombiesMission: MonoBehaviour
{
    public int totalEnemiesToKill = 200;
    private int enemiesKilled = 0;
    public TextController textController;

    public void EnemyKilled()
    {
        enemiesKilled++;
        UpdateMissionProgress();
    }

    private void UpdateMissionProgress()
    {
        textController.ActualizarMisionUI(enemiesKilled, totalEnemiesToKill);
    }

}

