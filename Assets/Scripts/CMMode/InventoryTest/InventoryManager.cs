using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; // Singleton del InventoryManager
    public Image[] potionSlots; // Array de im�genes para los slots de las pociones en el panel
    public Sprite defaultSprite; // Sprite por defecto para los slots vac�os
    private List<Sprite> collectedPotions = new List<Sprite>(); // Lista para almacenar las pociones recolectadas

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Destruye el duplicado del InventoryManager si ya hay uno en la escena
        }
    }

    // M�todo para a�adir una poci�n al inventario
    public void AddPotion(Sprite potionSprite)
    {
        if (collectedPotions.Count < potionSlots.Length)
        {
            collectedPotions.Add(potionSprite);
            UpdateInventoryUI();
        }
        else
        {
            Debug.LogWarning("Inventario lleno. No se puede a�adir m�s pociones.");
        }
    }

    // M�todo para actualizar la interfaz de usuario del inventario
    private void UpdateInventoryUI()
    {
        for (int i = 0; i < collectedPotions.Count; i++)
        {
            // Crear una nueva imagen para mostrar la poci�n
            GameObject potionImageGO = new GameObject("PotionImage");
            Image potionImage = potionImageGO.AddComponent<Image>();
            potionImage.sprite = collectedPotions[i];
            potionImage.transform.SetParent(transform); // Establecer el panel de inventario como padre

            // Ajustar la posici�n del sprite de la poci�n dentro del panel (puedes modificar estos valores seg�n tus necesidades)
            potionImage.rectTransform.localPosition = new Vector3(20f + i * 50f, 20f, 0f);
            potionImage.rectTransform.localScale = Vector3.one; // Escala por defecto
        }
    }
}
