using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Sprite itemSprite; // Sprite del objeto en el inventario
    public GameObject useButtonPrefab; // Prefab del bot�n "Use"
    private GameObject useButtonInstance; // Instancia del bot�n "Use"

    // M�todo para inicializar el objeto en el inventario
    public void Initialize(Sprite sprite)
    {
        itemSprite = sprite;
        GetComponent<Image>().sprite = sprite;
    }

    // M�todo para crear y mostrar el bot�n "Use"
    public void ShowUseButton()
    {
        if (useButtonPrefab != null && useButtonInstance == null)
        {
            useButtonInstance = Instantiate(useButtonPrefab, transform);
            useButtonInstance.GetComponent<Button>().onClick.AddListener(UseItem);
        }
    }

    // M�todo para usar el objeto
    public void UseItem()
    {
        // Aqu� puedes agregar la l�gica para usar la poci�n
        Debug.Log("Poci�n utilizada");
        Destroy(gameObject); // Elimina la poci�n del inventario despu�s de usarla
        Destroy(useButtonInstance); // Elimina el bot�n "Use"
    }
}
