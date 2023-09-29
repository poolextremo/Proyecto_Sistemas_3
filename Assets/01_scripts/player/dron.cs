using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dron : MonoBehaviour
{
    public Transform enemy, firePoint;

    public GameObject bullet;
    public float time, timebtw = 1;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Cancelacion.iscancel)
        {
            try
            {
                enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();
            }
            catch
            {
                enemy = null;
            }
            finally
            {
                if (enemy != null)
                {
                    Rotation();
                    Shoot();
                }
            }
        }
    }
    public void Rotation()
    {
        Vector3 dir = gameObject.transform.position - enemy.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + 90;
        gameObject.transform.rotation = Quaternion.Euler(0,0,-angle);
    }
    public void Shoot()
    {
        time += Time.deltaTime;
        if (time>timebtw)
        {
            time = 0;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}
