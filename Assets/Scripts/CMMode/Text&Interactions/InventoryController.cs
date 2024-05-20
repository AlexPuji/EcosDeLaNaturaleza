using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel; 
    public GameObject coinCounter; 
    public PlayerObjectCollector playerObjectCollector; 

    
    public void ToggleInventoryPanel()
    {
        
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);

        
        coinCounter.SetActive(inventoryPanel.activeSelf);

        
        if (inventoryPanel.activeSelf)
        {
            UpdateObjectCountText();
        }
    }

    
    private void UpdateObjectCountText()
    {
        
        if (playerObjectCollector != null && playerObjectCollector.objectCountText != null)
        {
            
            Text objectCountText = playerObjectCollector.objectCountText;

            
            objectCountText.text = "x " + playerObjectCollector.objectCount.ToString();
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventoryPanel();
        }
    }
}
