using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController playerController = collision.collider.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.TakeDamage(damage);
        }
    }
}
