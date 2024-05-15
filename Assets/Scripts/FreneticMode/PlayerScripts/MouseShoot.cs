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

    void Update()
    {
        
        if (Input.GetMouseButton(0) && ammoText.currentAmmo > 0 && Time.time > lastShootTime + shootInterval)
        {
            Shoot();
            DecreaseAmmo();
            lastShootTime = Time.time; 
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        Vector2 velocity = direction * bulletSpeed;


        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;

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
