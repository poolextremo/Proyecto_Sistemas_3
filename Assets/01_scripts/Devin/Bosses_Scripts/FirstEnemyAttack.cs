using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FirstEnemyAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 2f;
    public int projectileCount = 3;
    public float projectileSpeed = 5f;
    public Transform firePoint; // Referencia al transform del firepoint

    private float nextFireTime;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            FireBurst();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void FireBurst()
    {
        for (int i = 0; i < projectileCount; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 randomDirection = Random.insideUnitCircle.normalized;
                rb.velocity = randomDirection * projectileSpeed;
            }

            Destroy(projectile, 2f);
        }
    }


}
