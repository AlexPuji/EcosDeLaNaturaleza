using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanelController : MonoBehaviour
{
    public GameObject optionsPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool panelActive = !optionsPanel.activeSelf;
            optionsPanel.SetActive(panelActive);

            // Pausar o reanudar el tiempo según el estado del panel de opciones
            if (panelActive)
            {
                Time.timeScale = 0f; // Pausar el tiempo
            }
            else
            {
                Time.timeScale = 1f; // Reanudar el tiempo
            }
        }
    }
}
