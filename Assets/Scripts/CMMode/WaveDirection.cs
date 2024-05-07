using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDirection : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la onda expansiva

    private Vector2 direction; // Dirección en la que se desplaza la onda expansiva

    void Start()
    {
        // Calcular la dirección en la que se dispara la onda expansiva
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;

        // Calcular el ángulo de rotación de la onda expansiva basado en la dirección de movimiento
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Update()
    {
        // Mover la onda expansiva en su dirección
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
