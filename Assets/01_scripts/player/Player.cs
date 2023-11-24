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

    public float lv = 0, coins = 0, upLv = 20;
    public float experience = 0;
    public Image experienceUI, lifeUIMini, swordImage, dronimage, ballImage, areaImage;

    public float velocityBase = 5;

    public float  experienceTotal = 0, timeSecont, timeMinute, timeball = 0, timeballbtw = 1;
    public GameObject energyball, sword, area;

    public TextMeshProUGUI lifeTxt, cointxt, expTxt, timeTxt;

    public AudioClip areasonido, subirinvel, agarrarmoneda, agarrarexperencia;
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
            Regeneracion();
        }
            
    }
    public void acticararea()
    {
        GameManager.instance.playsfxloop(areasonido);
        areaImage.gameObject.SetActive(true);
    }
    public void Regeneracion()
    {
        if (life<100)
        {
            life += (Time.deltaTime / 1.7f) + ((Time.deltaTime / 1.7f) * (General.regen / 100));
            //Debug.Log(((Time.deltaTime/ 1.7f) * (General.regen / 100)));
        }
        
    }
    public void AplicChange()
    {
        Debug.Log((velocityBase * General.speed));
        moveSpeed = velocityBase + (velocityBase * General.speed);
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
        GameManager.instance.playsfx(agarrarexperencia);
        if (experience >= upLv)
        {
            experience = 0;
            lv++;
            textLvUI.text = "Lv " + lv + ":";
            upLv *= 1.15f;
            experienceUI.fillAmount = experience / upLv;
            GameManager.instance.playsfx(subirinvel);
            controller.MenuLevelUp();
        }
    }
    public void TakeCoin(int cant)
    {
        if(cant>0)
            GameManager.instance.playsfx(agarrarmoneda);
        coins +=cant;
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
        if (!Cancelacion.iscancel)
        {
            isdamage = true;
            life -= damage - (damage * (General.armadura / 100));
            //Debug.Log(damage * (General.armadura / 100));
            lifeUI.localScale = new Vector3(1 * (life / lifeTotal), 0.2f, 1);
            if (life <= 0)
            {
                General.experience = experience;
                General.time = (timeMinute*60)+timeSecont;
                SceneManager.LoadScene("GameOver");
            }
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
        armadura,
        dronextra,
        ball,
        area,
        regeneracion,
        velocidad,
        criticos
    }
}
