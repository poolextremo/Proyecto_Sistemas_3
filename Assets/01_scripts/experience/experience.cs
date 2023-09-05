using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class experience : MonoBehaviour
{
    public GameObject pl;
    public float velocity = 2;
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //float dis = Mathf.Sqrt(Mathf.Pow(pl.transform.position.x - transform.position.x, 2) + Mathf.Pow(pl.transform.position.y - transform.position.y, 2));
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("a");
        if (collision.CompareTag("area"))
        {
            Vector3 dir = gameObject.transform.position - pl.transform.position;
            float angulo = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + 180;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -angulo);
            transform.Translate(Vector2.up * velocity * Time.deltaTime);
        }
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
