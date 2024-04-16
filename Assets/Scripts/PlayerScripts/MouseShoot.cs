using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public AmmoText ammoText;
    public float shootInterval = 0.5f; // Intervalo de tiempo entre disparos en segundos
    private float lastShootTime; // Tiempo del último disparo

    void Update()
    {
        // Verificar si el jugador está manteniendo presionado el botón del ratón y tiene munición
        if (Input.GetMouseButton(0) && ammoText.currentAmmo > 0 && Time.time > lastShootTime + shootInterval)
        {
            Shoot();
            DecreaseAmmo();
            lastShootTime = Time.time; // Actualizar el tiempo del último disparo
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
        StartCoroutine(DestroyBulletAfterTime(bullet));
    }

    IEnumerator DestroyBulletAfterTime(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        Destroy(bullet);
    }

    void DecreaseAmmo()
    {
        ammoText.DecreaseAmmo();
    }
}
