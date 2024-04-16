using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform Player;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            Player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró un objeto con el tag 'Player'");
        }

    }
    void Update()
    {
        if(Player != null)
        {
            Vector3 positionPlayer = Player.position;

            positionPlayer.z = transform.position.z;

            transform.position = positionPlayer;
        }
    }
}
