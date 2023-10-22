using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FirstEnemyAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    int bulletCount;
    float timer;
    public float attackDelay = 20.0f;
    public float life = 100;

    public float minWaitTime = 3;
    public float maxWaitTime = 7;

    public int minBulletCount = 10;
    public int maxBulletCount = 30;

    public float timeBtwShoot = 1;
    void Start()
    {
        timer = 0;
        bulletCount = Random.Range(minBulletCount, maxBulletCount);
    }

    void Update()
    {
        Shoot();
    }

    public void ShootWithRandomAngle()
    {
        float angle = Random.Range(-45f, 45f);
        GameObject b = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        b.transform.Rotate(0, 0, angle);
    }

    public void Shoot()
    {
        if (timer < timeBtwShoot / 2f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            ShootWithRandomAngle();
            timer = 0;
            bulletCount--;
        }
    }

    public void TakeDamage(float value)
    {
        life -= value;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }


}
