using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballenery : MonoBehaviour
{
    public float velocity = 5f;
    void Start()
    {
        Destroy(gameObject,3);
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * velocity);
    }
}
