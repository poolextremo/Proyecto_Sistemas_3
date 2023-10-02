using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 6;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
