using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Image experienceUI, lifeUIMini, swordImage, dronimage, ballImage, areaImage;

    public float velocitybase = 5;

    public float  experienceTotal = 0, timeSecont, timeMinute, timeball = 0, timeballbtw = 1;
    public GameObject energyball, sword, area;

    public TextMeshProUGUI lifeTxt, cointxt, expTxt, timeTxt;

    public GameObject objetoHijo;
    private Animator animatorObjetoHijo;
    private SpriteRenderer spriteRendererHijo;
    void Start()
    {
        animatorObjetoHijo = objetoHijo.GetComponent<Animator>();
        spriteRendererHijo = objetoHijo.GetComponent<SpriteRenderer>();
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
        if (!Cancelacion.iscancel)
        {
            inputManagement();
        }
        else
        {
            moveDir = new Vector2(0,0);
            rb.velocity = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow))
        {
            animatorObjetoHijo.SetBool("IsWalking", true);
        }
        else
        {
            animatorObjetoHijo.SetBool("IsWalking", false);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            spriteRendererHijo.flipX = false;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRendererHijo.flipX = true;
        }

    }

    void FixedUpdate()
    {
        if (!Cancelacion.iscancel)
        {
            timeSecont += Time.deltaTime;
            General.tiempo += Time.deltaTime/30;
            if (timeSecont > 60)
            {
                timeSecont = 0;
                timeMinute++;
            }
            timeTxt.text = (int)timeMinute + ":" + (int)timeSecont;
            if (General.ballEnergy)
                BallEnergy();
            //if (General.area)
            General.life = life;
            General.lifetotal = lifeTotal;

            lifeUIMini.fillAmount = (General.life/General.lifetotal);

            lifeTxt.text = (int)General.life + "/" + (int)General.lifetotal;

            Move();
            LifeUI();
        }
            
    }
    public void AplicChange()
    {
        velocity = velocity + velocitybase * (General.speed / 100);
    }
    public void BallEnergy()
    {
        if (General.ballEnergy)
        {
            timeball+=Time.deltaTime;
            if (timeball> timeballbtw)
            {
                timeball = 0;
                Instantiate(energyball, transform.position, sword.transform.rotation);
            }
        }
    }
    void inputManagement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
        moveDir = new Vector2 (moveX, moveY).normalized;
    }

    void Move()
    {
        //Debug.Log(moveDir.x);
        //Debug.Log(moveDir.y);
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }


    public void TakeExperience(float ex)
    {
        experienceTotal += ex;
        expTxt.text = "Experiencia: " + experienceTotal;
        experience += ex;
        experienceUI.fillAmount = experience / upLv;
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
    public void TakeCoin(int cant)
    {
        //Debug.Log("agarro una moneda");
        coins+=cant;
        cointxt.text = "Monedas: " + coins;
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
            General.ValuesDefault();
            SceneManager.LoadScene("MainMenu");
            //Destroy(gameObject);
        }
    }
    public void ActivarDron()
    {
        if (!General.drone)
        {
            General.drone = true;
            dronimage.gameObject.SetActive(true);
        }
            
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
        ball,
        area,
        velocitydron,
        damagedron,
        damageSword
    }
}
