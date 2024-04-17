using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MisionManager : MonoBehaviour
{
    public Text missionText;

    
    private int easyMissionsCompleted = 0;
    private int normalMissionsCompleted = 0;
    private int hardMissionsCompleted = 0;

    
    private SelectModeController selectModeController;
    private TextController textController; 

    void Start()
    {
        
        selectModeController = FindObjectOfType<SelectModeController>();
        textController = FindObjectOfType<TextController>();

        if (selectModeController == null || textController == null)
        {
            Debug.LogError("No se encontró el SelectModeController o el TextController en la escena.");
            return; 
        }

        
        UpdateMissionText();
    }

    
    void UpdateMissionText()
    {
        
        string difficulty = selectModeController.GetSelectedDifficulty();

        
        string missionDescription = "";

        //Tipo de mission en nivel
        switch (difficulty)
        {
            case "easy":
                missionDescription = "Kill 50 Enemies";
                break;
            case "normal":
                missionDescription = "Kill 100 Enemies";
                break;
            case "hard":
                missionDescription = "Kill 200 Enemies";
                break;
            default:
                missionDescription = "Kill Enemies";
                break;
        }

        //Texto de mision
        if (missionText != null)
        {
            missionText.text = missionDescription;
        }
    }

    
    public void EnemyKilled()
    {
        
        string difficulty = selectModeController.GetSelectedDifficulty();

        //Dificultades
        switch (difficulty)
        {
            case "easy":
                easyMissionsCompleted++;
                break;
            case "normal":
                normalMissionsCompleted++;
                break;
            case "hard":
                hardMissionsCompleted++;
                break;
        }

        
        textController.ActualizarMisionUI(GetTotalMisionesCompletadas(), GetTotalMisionesNecesarias());

        
        if (easyMissionsCompleted >= 50 && normalMissionsCompleted >= 100 && hardMissionsCompleted >= 200)
        {
            
            SceneManager.LoadScene("Level2");//Escena de Frenetic Mode
        }
    }

    
    private int GetTotalMisionesCompletadas()
    {
        return easyMissionsCompleted + normalMissionsCompleted + hardMissionsCompleted;//Volver al completar mision ?¿ Revisar
    }

    
    private int GetTotalMisionesNecesarias()
    {
        
        string difficulty = selectModeController.GetSelectedDifficulty();
        
        // Numero de mission( de monstruos)
        switch (difficulty)
        {
            case "easy":
                return 50;
            case "normal":
                return 100;
            case "hard":
                return 200;
            default:
                return 0;
        }
    }
}
