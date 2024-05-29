using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameData currentGameData;
    public Transform playerTransform;  // Asegúrate de asignar esto en el Inspector

    void Start()
    {
        LoadGame(); // Cargar datos al iniciar la escena
        SetupGame(currentGameData); // Configurar el juego con los datos cargados
    }

    void SetupGame(GameData data)
    {
        if (data != null)
        {
            // Configura tu juego con los datos cargados
            Debug.Log($"Player Level: {data.playerLevel}, Player Health: {data.playerHealth}");
            // Configurar la posición del jugador
            playerTransform.position = new Vector3(data.playerPositionX, data.playerPositionY, playerTransform.position.z);
        }
        else
        {
            Debug.LogError("No game data to setup.");
        }
    }

    public void SaveGame()
    {
        if (currentGameData != null && playerTransform != null)
        {
            // Actualizar datos de juego antes de guardar
            currentGameData.playerPositionX = playerTransform.position.x;
            currentGameData.playerPositionY = playerTransform.position.y;

            SaveSystem.SaveGame(currentGameData);
            Debug.Log("Game Saved");
        }
        else
        {
            Debug.LogError("Cannot save game. Data or player transform is null.");
        }
    }

    public void LoadGame()
    {
        currentGameData = SaveSystem.LoadGame();
        if (currentGameData != null)
        {
            SetupGame(currentGameData);
        }
        else
        {
            currentGameData = new GameData { playerLevel = 1, playerHealth = 100f, playerPositionX = 0f, playerPositionY = 0f }; // Inicializa si no hay datos
            Debug.Log("Initialized new game data.");
        }
    }

    public void DeleteSave()
    {
        SaveSystem.DeleteSave();
        Debug.Log("Save Deleted");
    }

    public void CheckSaveData()
    {
        GameData loadedData = SaveSystem.LoadGame();
        if (loadedData != null)
        {
            Debug.Log($"Saved Data - Player Level: {loadedData.playerLevel}, Player Health: {loadedData.playerHealth}");
        }
        else
        {
            Debug.Log("No save data found.");
        }
    }

    public void ModifyGameData()
    {
        if (currentGameData != null)
        {
            // Modifica los datos del juego, por ejemplo, aumenta el nivel del jugador y reduce la salud
            currentGameData.playerLevel += 1;
            currentGameData.playerHealth -= 10f;
            Debug.Log($"Modified Data - Player Level: {currentGameData.playerLevel}, Player Health: {currentGameData.playerHealth}");
        }
        else
        {
            Debug.LogError("No game data to modify.");
        }
    }
}
