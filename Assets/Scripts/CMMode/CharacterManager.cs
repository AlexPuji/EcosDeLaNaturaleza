using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // Variable estática para almacenar la única instancia del CharacterManager
    private static CharacterManager instance;

    // Método estático para acceder a la única instancia del CharacterManager
    public static CharacterManager Instance
    {
        get
        {
            // Si no hay una instancia, busca en la escena y la crea si es necesario
            if (instance == null)
            {
                instance = FindObjectOfType<CharacterManager>();

                // Si no se encontró en la escena, crea un nuevo GameObject y añade el script
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(CharacterManager).Name);
                    instance = singletonObject.AddComponent<CharacterManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Asegúrate de que solo haya una instancia en ejecución
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantén el GameObject y su script al cambiar de escena
        }
    }
}
