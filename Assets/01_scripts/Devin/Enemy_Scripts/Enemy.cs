using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{

    [Header("Enemy Stats")]
    public float speed = 2;
    public float life = 100;

    [Header("Enemy Tracking Stats")]
    Transform target;
    public Rigidbody rb;

    public float lifeTotal, speedanim;
    public Transform lifeUI;
    public bool isdamage;
    public SpriteRenderer paint;
    public GameObject exp, coin, damageVisual;

    public Animator anim;

    public Spawner spawner;

    public AudioClip sonidomuerte;
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawner>();

        speed *= General.tiempo/2;
        life *= General.tiempo;
        anim.speed *= General.tiempo / 2;
        speedanim = anim.speed;
        lifeTotal = life;
        paint = lifeUI.GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!Cancelacion.iscancel)
        {
            LifeUI();
            SearchTarget();
            NormalMovement();
            RotateToTarget();
            if(anim.speed==0)
                anim.speed= speedanim;
        }
        else
        {
            anim.speed = 0;
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
        if (!Cancelacion.iscancel)
        {
            isdamage = true;
            life -= damage;

            if (life <= 0)
            {
                life = 0;
                lifeUI.localScale = new Vector3(1 * (life / lifeTotal), 0.2f, 1);

                if (Random.Range(0, 2) == 1)
                    Instantiate(exp, transform.position, transform.rotation);

                else if (Random.Range(0, 5) == 4)
                    Instantiate(coin, transform.position, transform.rotation);
                General.kills++;
                GameManager.instance.playsfx(sonidomuerte);
                spawner.cantMax.Remove(gameObject);
                Destroy(gameObject);
            }
            lifeUI.localScale = new Vector3(1 * (life / lifeTotal), 0.2f, 1);
            if (damage > 1)
            {
                GameObject texto = Instantiate(damageVisual, new Vector3(transform.position.x, transform.position.y, -1), damageVisual.transform.rotation);
                texto.GetComponent<TextMeshPro>().text = "" + damage;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("sword"))
        {
            if (Random.Range(1, 101) < General.criticos)
                TakeDamage(General.sworddamage*2);
            else
            {
                TakeDamage(General.sworddamage);
            }
        }
        if (collision.gameObject.CompareTag("energyball"))
        {
            if (Random.Range(1, 101) < General.criticos)
                TakeDamage(General.ballDamage * 2);
            else
                TakeDamage(General.ballDamage);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(0.1f);
        }
        if (collision.gameObject.CompareTag("AreaDamage"))
        {
            TakeDamage(General.areaDamage);
        }
    }
}

