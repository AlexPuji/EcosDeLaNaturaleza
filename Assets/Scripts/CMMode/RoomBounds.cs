using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAreaBounds : MonoBehaviour
{
    public Vector2 minBounds = new Vector2(-9f, -5f); // Límite inferior izquierdo del área permitida
    public Vector2 maxBounds = new Vector2(9f, 5f); // Límite superior derecho del área permitida

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(maxBounds.x - minBounds.x, maxBounds.y - minBounds.y, 1f));
    }
}
