using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Player : MonoBehaviour
{
    public Mejoras Upgrates;
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 moveDir;
    public CapsuleCollider2D col;
    public MenuController controller;
    public Transform lifeUI;
    public bool isdamage = false;
    public SpriteRenderer paint;
    public TextMeshProUGUI textLvUI;
    public List<GameObject> drones;


    public float velocity = 5, life = 100, lifeTotal = 100;

    public int lv = 0, coins = 0, upLv = 20;
    public float experience = 0;
    public Image experienceUI;
    void Start()
    {
        experienceUI.fillAmount = experience / 100;
        paint = lifeUI.GetComponent<SpriteRenderer>();
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
        }
        if (col == null)
        {
            col = GetComponent<CapsuleCollider2D>();
            col.isTrigger = true;
            lifeTotal = life;
        }
        controller = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        inputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void inputManagement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDir = new Vector2 (moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }


    public void TakeExperience(float ex)
    {
        experience += ex;
        experienceUI.fillAmount = experience/upLv;
        if (experience >= upLv)
        {
            experience = 0;
            lv++;
            textLvUI.text = "Lv " + lv + ":";
            upLv *= 2;
            experienceUI.fillAmount = experience / upLv;
            controller.MenuLevelUp();
        }
    }
    public void TakeCoin()
    {
        coins++; 
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
    public void TakeDamage(float damage)
    {
        isdamage = true;
        life -= damage;
        lifeUI.localScale = new Vector3(1*(life/lifeTotal),0.2f,1);
        if (life<=0)
        {
            Destroy(gameObject);
        }
    }
    public void ActivarDron()
    {
        foreach (var item in drones)
        {
            if (!item.activeSelf)
            {
                item.SetActive(true);
                break;
            }
        }
    }
    public enum Type
    {
        Sword,
        pistol
    }
    public enum Mejoras
    {
        SwordVelocity,
        dronextra,
        velocitydron,
        damagedron,
        damageSword
    }
}
