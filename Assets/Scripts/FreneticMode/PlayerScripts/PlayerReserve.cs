using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReserve : MonoBehaviour
{
    public GameObject playerReserve; // Referencia al GameObject de reserva del jugador

    void Die()
    {
        Debug.Log("El jugador ha muerto.");
        gameObject.SetActive(false); 
        playerReserve.SetActive(true); 
    }
}


