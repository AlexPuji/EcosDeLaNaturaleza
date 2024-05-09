using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentCharacter : MonoBehaviour
{
    private void Awake()
    {
        // Marca este objeto como persistente
        DontDestroyOnLoad(gameObject);
    }
}
