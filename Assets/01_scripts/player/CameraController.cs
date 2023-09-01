using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Player pl; 
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pl.transform.position.x > transform.position.x + 5)
        {
            transform.position = new Vector3(pl.transform.position.x - 5 , transform.position.y,-10);
        }
        if (pl.transform.position.x < transform.position.x - 5)
        {
            transform.position = new Vector3(pl.transform.position.x + 5, transform.position.y, -10);
        }
        if (pl.transform.position.y > transform.position.y + 3)
        {
            transform.position = new Vector3(transform.position.x, pl.transform.position.y - 3, -10);
        }
        if (pl.transform.position.y < transform.position.y - 3)
        {
            transform.position = new Vector3(transform.position.x, pl.transform.position.y + 3, -10);
        }
    }
}
