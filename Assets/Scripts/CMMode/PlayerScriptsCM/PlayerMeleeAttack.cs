using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMeleeAttack : MonoBehaviour
{
    public GameObject meleeAttackPrefab;
    public float meleeAttackInterval = 1f; // Intervalo entre cada ataque

    private float lastMeleeAttackTime;
    private PlayerSoundManager soundManager;

    void Start()
    {
        // Obtener el PlayerSoundManager del mismo GameObject
        soundManager = GetComponent<PlayerSoundManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > lastMeleeAttackTime + meleeAttackInterval)
        {
            PerformMeleeAttack();
            lastMeleeAttackTime = Time.time;
        }
    }

    void PerformMeleeAttack()
    {
        // Posición del mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Instanciar el ataque a melee
        GameObject meleeAttack = Instantiate(meleeAttackPrefab, transform.position, Quaternion.identity);

        // Obtener el Rigidbody2D del ataque a melee
        Rigidbody2D rb = meleeAttack.GetComponent<Rigidbody2D>();
        rb.velocity = direction * 3f;

        // Reproducir el sonido de ataque
        if (soundManager != null)
        {
            soundManager.PlayAttackSound();
        }

        // Destruir el ataque a melee después de 0.3 segundos
        Destroy(meleeAttack, 0.3f);
    }
}
