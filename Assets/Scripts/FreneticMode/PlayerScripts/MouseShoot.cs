using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 30f;
    public AmmoText ammoText;
    public float shootInterval = 0.5f;
    private float lastShootTime;

    // Agrega una referencia al componente ShootSound
    public ShootSound shootSoundComponent;

    private void Update()
    {
        if (Input.GetMouseButton(0) && ammoText.currentAmmo > 0 && Time.time > lastShootTime + shootInterval)
        {
            Shoot();
            DecreaseAmmo();
            lastShootTime = Time.time;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        Vector2 velocity = direction * bulletSpeed;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;

        StartCoroutine(DestroyBulletAfterTime(bullet));

        // Llama al método PlayShootSound del componente ShootSound si está configurado
        if (shootSoundComponent != null)
        {
            shootSoundComponent.PlayShootSound();
        }
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        Destroy(bullet);
    }

    private void DecreaseAmmo()
    {
        ammoText.DecreaseAmmo();
    }
}
