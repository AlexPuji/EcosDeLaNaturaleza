using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    
    private static CharacterManager instance;

    
    public static CharacterManager Instance
    {
        get
        {
            
            if (instance == null)
            {
                instance = FindObjectOfType<CharacterManager>();

                
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
       
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //mantenir el gameobject del personatge a l'anar a una altra scena 
        }
    }
}
