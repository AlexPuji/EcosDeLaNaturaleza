using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirectionFM : MonoBehaviour
{
    public float speed = 10f; //velocitat de la onda(AttackMelee)

    private Vector2 direction; //direcció

    void Start()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Update()
    {

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
