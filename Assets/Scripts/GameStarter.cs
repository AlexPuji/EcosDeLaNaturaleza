using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject player;

    public void StartGame()
    {
        // Activa el jugador y realiza otras acciones de inicio del juego
        player.SetActive(true);
        // Aqu� puedes realizar cualquier otra inicializaci�n necesaria para comenzar el juego
    }

    void Start()
    {
        // Desactiva el jugador al inicio
        player.SetActive(false);
    }

    

    
}
