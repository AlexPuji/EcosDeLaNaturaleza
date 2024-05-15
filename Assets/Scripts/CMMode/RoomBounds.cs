using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAreaBounds : MonoBehaviour
{
    //Limits de l'habitació (Cuadrat)
    public Vector2 minBounds = new Vector2(-9f, -5f); 
    public Vector2 maxBounds = new Vector2(9f, 5f); 
    private void OnDrawGizmosSelected()
    {
        //Color dels Limits del Cuadrat
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(maxBounds.x - minBounds.x, maxBounds.y - minBounds.y, 1f));
    }
}
