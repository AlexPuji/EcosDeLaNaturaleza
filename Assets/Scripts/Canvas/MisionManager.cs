using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionManager : MonoBehaviour
{
    public int enemiesKilled = 0;
    public int enemiesToKill = 200;
    public Text missionText;
    private bool missionCompleted = false;

    void Start()
    {
        UpdateMissionText();
    }

    public void EnemyKilled()
    {
        if (missionCompleted)
        {
            return;
        }
        enemiesKilled++;
        UpdateMissionText();

        if (enemiesKilled >= enemiesToKill)
        {
            Debug.Log("Mission Completed!");
            missionCompleted = true;
            
        }
    }

    void UpdateMissionText()
    {
        if (missionText != null)
        {
            missionText.text = "Kill " + enemiesToKill + " Enemies: " + enemiesKilled + "/" + enemiesToKill;
        }
    }
}
