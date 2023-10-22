using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType type = EnemyType.FirstEnemy;

    [Header("Enemy Stats")]
    public float speed = 2;
    public float life = 100;

    [Header("Enemy Tracking Stats")]
    Transform target;
    public Rigidbody rb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        switch (type)
        {
            case EnemyType.FirstEnemy:
                SearchTarget();
                NormalMovement();
                RotateToTarget();
                life = 100;
                break;
            case EnemyType.SecondEnemy:
                SearchTarget();
                NormalMovement();
                RotateToTarget();
                life = life + 50;
                break;
            case EnemyType.ThirdEnemy:
                SearchTarget();
                NormalMovement();
                RotateToTarget();
                life = life + 60;
                break;
            case EnemyType.FourthEnemy:
                SearchTarget();
                NormalMovement();
                RotateToTarget();
                life = life + 70;
                break;
            case EnemyType.FifthEnemy:
                SearchTarget();
                NormalMovement();
                RotateToTarget();
                life = life + 80;
            break;
        }
    }

    void NormalMovement()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void SearchTarget()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
        }
    }

    void RotateToTarget()
    {
        Vector3 dir = target.position - transform.position;
        float angleY = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + 0;
        transform.rotation = Quaternion.Euler(0, angleY, 0);
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

public enum EnemyType
{
    FirstEnemy,
    SecondEnemy,
    ThirdEnemy,
    FourthEnemy,
    FifthEnemy
}
