using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Sprite itemSprite; // Sprite del objeto en el inventario
    public GameObject useButtonPrefab; // Prefab del botón "Use"
    private GameObject useButtonInstance; // Instancia del botón "Use"

    // Método para inicializar el objeto en el inventario
    public void Initialize(Sprite sprite)
    {
        itemSprite = sprite;
        GetComponent<Image>().sprite = sprite;
    }

    // Método para crear y mostrar el botón "Use"
    public void ShowUseButton()
    {
        if (useButtonPrefab != null && useButtonInstance == null)
        {
            useButtonInstance = Instantiate(useButtonPrefab, transform);
            useButtonInstance.GetComponent<Button>().onClick.AddListener(UseItem);
        }
    }

    // Método para usar el objeto
    public void UseItem()
    {
        // Aquí puedes agregar la lógica para usar la poción
        Debug.Log("Poción utilizada");
        Destroy(gameObject); // Elimina la poción del inventario después de usarla
        Destroy(useButtonInstance); // Elimina el botón "Use"
    }
}
