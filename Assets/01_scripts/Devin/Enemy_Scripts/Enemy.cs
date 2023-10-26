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

    public float lifeTotal;
    public Transform lifeUI;
    public bool isdamage;
    public SpriteRenderer paint;
    public GameObject exp, coin;
    void Start()
    {
        lifeTotal = life;
        paint = lifeUI.GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!Cancelacion.iscancel)
        {
            LifeUI();
            switch (type)
            {
                case EnemyType.FirstEnemy:
                    SearchTarget();
                    NormalMovement();
                    RotateToTarget();
                    //life = 10;
                    break;
                case EnemyType.SecondEnemy:
                    SearchTarget();
                    NormalMovement();
                    RotateToTarget();
                    //life = life + 50;
                    break;
                case EnemyType.ThirdEnemy:
                    SearchTarget();
                    NormalMovement();
                    RotateToTarget();
                    //life = life + 60;
                    break;
                case EnemyType.FourthEnemy:
                    SearchTarget();
                    NormalMovement();
                    RotateToTarget();
                    //life = life + 70;
                    break;
                case EnemyType.FifthEnemy:
                    SearchTarget();
                    NormalMovement();
                    RotateToTarget();
                    //life = life + 80;
                    break;
            }
        }
    }

    void NormalMovement()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    void LifeUI()
    {
        if (isdamage)
        {
            isdamage = false;
            paint.color = new Color(paint.color.r, paint.color.g, paint.color.b, 1);
        }
        else
        {
            if (paint.color.a > 0)
            {
                paint.color = new Color(paint.color.r, paint.color.g, paint.color.b, paint.color.a - Time.deltaTime);
            }
        }
    }
    void SearchTarget()
    {
        if (target != null)
        {
            float distance = Vector2.Distance(transform.position, target.position);
        }
    }

    void RotateToTarget()
    {
        Vector3 dir = target.position - transform.position;
        float angleY = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 0;
        transform.rotation = Quaternion.Euler(0, 0, angleY);
    }

    public void TakeDamage(float damage)
    {
        isdamage = true;
        life -= damage;
        
        if (life <= 0)
        {
            life = 0;
            lifeUI.localScale = new Vector3(1 * (life / lifeTotal), 0.2f, 1);

            if (Random.Range(0,2) == 1)
                Instantiate(exp, transform.position, transform.rotation);
            
            else if (Random.Range(0, 5) == 4)
                Instantiate(coin, transform.position, transform.rotation);
            General.kills++;
            Destroy(gameObject);
        }
        lifeUI.localScale = new Vector3(1 * (life / lifeTotal), 0.2f, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("sword"))
        {
            TakeDamage(General.sworddamage);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(0.1f);
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
