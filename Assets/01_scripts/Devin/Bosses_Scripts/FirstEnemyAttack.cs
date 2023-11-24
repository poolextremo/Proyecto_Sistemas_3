using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FirstEnemyAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 2f;
    public int projectileCount = 3;
    public float spreadAngle = 30f; 
    public float projectileSpeed = 5f;
    public Transform firePoint; 

    private float nextFireTime;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            FireShotgun();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void FireShotgun()
    {
        for (int i = 0; i < projectileCount; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float spread = Random.Range(-spreadAngle, spreadAngle);
                projectile.transform.Rotate(Vector3.forward, spread);
                Vector2 shotDirection = projectile.transform.right;
                rb.velocity = shotDirection * projectileSpeed;
            }

            Destroy(projectile, 2f);
        }
    }


}
