using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel; // Referencia al panel de inventario
    public GameObject coinCounter; // Referencia al contador de monedas
    public PlayerObjectCollector playerObjectCollector; // Referencia al script PlayerObjectCollector del jugador

    // Método para abrir o cerrar el panel de inventario
    public void ToggleInventoryPanel()
    {
        // Cambiar el estado activo/desactivo del panel de inventario
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);

        // Cambiar el estado activo/desactivo del contador de monedas
        coinCounter.SetActive(inventoryPanel.activeSelf);

        // Actualizar el texto del contador de objetos dentro del panel de inventario
        if (inventoryPanel.activeSelf)
        {
            UpdateObjectCountText();
        }
    }

    // Método para actualizar el texto del contador de objetos dentro del panel de inventario
    private void UpdateObjectCountText()
    {
        // Verificar si se ha asignado el script PlayerObjectCollector
        if (playerObjectCollector != null && playerObjectCollector.objectCountText != null)
        {
            // Obtener el texto del contador de objetos del script PlayerObjectCollector
            Text objectCountText = playerObjectCollector.objectCountText;

            // Actualizar el texto del contador de objetos
            objectCountText.text = "x " + playerObjectCollector.objectCount.ToString();
        }
    }

    void Update()
    {
        // Si el jugador presiona la tecla "i", alternar la activación del inventario
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventoryPanel();
        }
    }
}
