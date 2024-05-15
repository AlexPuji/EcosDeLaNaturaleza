using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform Player;

    private void Awake()// ja no s'utilitza camera en altre script
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

    void LateUpdate()
    {
        if (Player != null)
        {
            transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
        }
    }
}
