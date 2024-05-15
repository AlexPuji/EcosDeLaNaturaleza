using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentCharacter : MonoBehaviour
{
    private void Awake()
    {
        // mante al jugador com viu
        DontDestroyOnLoad(gameObject);
    }
}
