using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAreaLimit : MonoBehaviour
{
    private Collider2D mapCollider; // Referencia al Collider 2D del objeto

    private void Start()
    {
        // Obtener referencia al Collider 2D
        mapCollider = GetComponent<Collider2D>();
        if (mapCollider == null)
        {
            Debug.LogError("No se encontr� un Collider 2D en el objeto.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            // Impedir que el jugador entre en el �rea del mapa
            // Puedes hacer algo aqu�, como teletransportar al jugador de vuelta a una posici�n segura
            Debug.Log("�No puedes pasar m�s all� de los l�mites del mapa!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (mapCollider != null)
        {
            Gizmos.color = Color.blue;
            // Obtener el tama�o del Collider
            Vector2 size = mapCollider.bounds.size;
            // Dibujar un wireframe alrededor del Collider
            Gizmos.DrawWireCube(mapCollider.bounds.center, new Vector3(size.x, size.y, 1f));
        }
    }

}
