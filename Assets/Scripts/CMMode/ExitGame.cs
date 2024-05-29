using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit(); // Cierra la aplicación (solo funciona en compilación)
    }
}
