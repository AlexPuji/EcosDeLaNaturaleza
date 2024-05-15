using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text puntosText; 
    private int puntos = 0; 
    public Text missionText;

    
    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarPuntosUI();
    }

    
    private void ActualizarPuntosUI()
    {
        puntosText.text = "Puntos: " + puntos.ToString();
    }
    public void ActualizarMisionUI(int progresoActual, int total)
    {
        missionText.text = "Kill " + total + " Enemies: " + progresoActual + "/" + total;
    }
   
}
