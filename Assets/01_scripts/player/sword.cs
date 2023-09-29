using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{


    Vector2 mousePos;
    public Animator anim;
    public void Update()
    {
        if (!Cancelacion.iscancel)
        {
            Rotate();
            anim.speed = 1;
        }
        else
        {
            anim.speed = 0;
        }
        
    }
    public void Rotate()
    {
        Vector3 lookDir = Input.mousePosition - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
