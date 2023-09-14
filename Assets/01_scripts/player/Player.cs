using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public CapsuleCollider2D col;
    public MenuController controller;

    public float velocity = 5, life = 100;

    public int lv = 0, coins = 0, upLv = 100;
    public float experience = 0;
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
        }
        if (col == null)
        {
            col = GetComponent<CapsuleCollider2D>();
            col.isTrigger = true;
        }
        controller = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Cancelacion.iscancel)
        {
            float y = Input.GetAxis("Vertical");
            float x = Input.GetAxis("Horizontal");

            rb.velocity = new Vector3(x * velocity, y * velocity, 0);
        }
        else
        {
            rb.velocity = new Vector3(0,0,0);
        }
    }
    public void TakeExperience(float ex)
    {
        experience += ex;
        controller.MenuLevelUp();
        if (experience >= upLv)
        {
            lv++;
            upLv *= 2;
            controller.MenuLevelUp();
        }
    }
    public void TakeCoin()
    {
        coins++; 
    }
    public void TakeDamage()
    {

    }
    public enum Type
    {
        Sword,
        pistol
    }
}
