using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondEnemyAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootInterval = 1.0f; 
    public float projectileLifetime = 3.0f;  

    private float nextShootTime;

    void Start()
    {
        nextShootTime = Time.time + shootInterval;
    }

    void Update()
    {
        if (Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootInterval;
        }
    }

    void Shoot()
    {
        int numDirections = 12; // Reducir el número de direcciones
        float angleSpacing = 360f / numDirections;

        for (int i = 0; i < numDirections; i++)
        {
            float angle = i * angleSpacing;
            Quaternion rotation = Quaternion.Euler(360f, 0f, angle);

            GameObject newProjectile = Instantiate(projectilePrefab, transform.position, rotation);

            Destroy(newProjectile, projectileLifetime);
        }
    }
}
