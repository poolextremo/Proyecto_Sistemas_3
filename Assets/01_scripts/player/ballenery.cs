using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballenery : MonoBehaviour
{
    public float velocity = 5f;
    public AudioClip audiobola;
    void Start()
    {
        GameManager.instance.playsfx(audiobola);
        Destroy(gameObject,3);
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * velocity);
    }
}
