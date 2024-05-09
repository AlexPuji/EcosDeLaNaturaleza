using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObjectCollector : MonoBehaviour
{
    public int objectCount = 0; // Contador de objetos recolectados
    public Text objectCountText; // Texto para mostrar el contador de objetos

    // Método para recolectar un objeto
    public void CollectObject()
    {
        objectCount++; // Incrementa el contador de objetos
        UpdateObjectCountText(); // Actualiza el texto del contador de objetos
    }

    // Método para actualizar el texto del contador de objetos
    private void UpdateObjectCountText()
    {
        objectCountText.text = "x " + objectCount.ToString(); 
    }
}
