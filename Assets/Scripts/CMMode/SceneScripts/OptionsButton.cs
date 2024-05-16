using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsButton : MonoBehaviour
{
    public void LoadOptions()
    {
        SceneManager.LoadScene("Options"); // Carga la escena de opciones
    }
}
