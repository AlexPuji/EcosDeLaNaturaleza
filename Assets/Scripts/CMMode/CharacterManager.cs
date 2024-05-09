using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // Variable est�tica para almacenar la �nica instancia del CharacterManager
    private static CharacterManager instance;

    // M�todo est�tico para acceder a la �nica instancia del CharacterManager
    public static CharacterManager Instance
    {
        get
        {
            // Si no hay una instancia, busca en la escena y la crea si es necesario
            if (instance == null)
            {
                instance = FindObjectOfType<CharacterManager>();

                // Si no se encontr� en la escena, crea un nuevo GameObject y a�ade el script
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
        // Aseg�rate de que solo haya una instancia en ejecuci�n
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mant�n el GameObject y su script al cambiar de escena
        }
    }
}
