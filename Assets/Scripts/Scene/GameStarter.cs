using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject player;

    public void StartGame()
    {
        
        player.SetActive(true);
        
    }

    void Start()
    {
        
        player.SetActive(false);
    }

    

    
}
