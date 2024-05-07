using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public GameObject meleeAttackPrefab; // Prefab del ataque melee
    public float meleeAttackInterval = 1f; // Intervalo entre ataques melee

    private float lastMeleeAttackTime;

    void Update()
    {
        // Si el jugador presiona el botón del mouse y ya ha pasado el intervalo de tiempo
        if (Input.GetMouseButtonDown(0) && Time.time > lastMeleeAttackTime + meleeAttackInterval)
        {
            // Realizar el ataque
            PerformMeleeAttack();
            // Actualizar el tiempo del último ataque
            lastMeleeAttackTime = Time.time;
        }
    }

    void PerformMeleeAttack()
    {
        // Obtener la posición del mouse en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Calcular la dirección hacia la posición del mouse
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Instanciar el ataque melee en la posición del jugador
        GameObject meleeAttack = Instantiate(meleeAttackPrefab, transform.position, Quaternion.identity);

        // Obtener el componente Rigidbody2D del ataque melee
        Rigidbody2D rb = meleeAttack.GetComponent<Rigidbody2D>();
        // Aplicar una fuerza al ataque melee en la dirección calculada
        rb.velocity = direction * 3f;

        // Destruir el ataque melee después de un tiempo
        Destroy(meleeAttack, 0.3f); // Cambia el valor según lo necesario
    }

}
