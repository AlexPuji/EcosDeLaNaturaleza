using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    private Text objectText; // Referencia al componente Text del objeto interactuable

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Mantener el GameObject al cambiar de escena
        objectText = GetComponentInChildren<Text>(); // Obtener el componente Text
    }

    // M�todo para actualizar el texto del objeto interactuable
    public void UpdateObjectText(string newText)
    {
        // Verificar si el componente Text a�n existe antes de intentar actualizar el texto
        if (objectText != null)
        {
            objectText.text = newText; // Actualizar el texto del objeto interactuable
        }
        else
        {
            Debug.LogWarning("El componente Text del objeto interactuable no se encontr�.");
        }
    }
}
