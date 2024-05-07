using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDirection : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la onda expansiva

    private Vector2 direction; // Direcci�n en la que se desplaza la onda expansiva

    void Start()
    {
        // Calcular la direcci�n en la que se dispara la onda expansiva
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;

        // Calcular el �ngulo de rotaci�n de la onda expansiva basado en la direcci�n de movimiento
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Update()
    {
        // Mover la onda expansiva en su direcci�n
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
