using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBoots : MonoBehaviour
{
    public Text bootText; // Referencia al texto de las botas

    // Método para actualizar el texto de las botas en la UI
    public void UpdateBootText(int collected, int total)
    {
        bootText.text = "Remaining Boots: " + collected + "/" + total;
    }
}
