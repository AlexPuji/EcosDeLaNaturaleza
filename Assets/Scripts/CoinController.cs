using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Realiza las acciones necesarias cuando el jugador recolecta la moneda

            // Desactiva la moneda en lugar de destruirla
            gameObject.SetActive(false);
        }
    }

}
