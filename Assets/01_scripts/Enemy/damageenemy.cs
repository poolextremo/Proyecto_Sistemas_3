using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageenemy : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * 3,ForceMode2D.Impulse);
        Destroy(gameObject,1);
    }

}
