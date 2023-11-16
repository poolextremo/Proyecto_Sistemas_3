using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dron : MonoBehaviour
{
    public List<Transform> target;
    public Transform firePoint;

    public GameObject bullet;
    public float time, timebtw = 1;

    public AudioClip audioshot;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Cancelacion.iscancel)
        {
            try
            {
                if (target.Count > 0)
                {
                    if (target[0] == null)
                        target.Remove(target[0]);
                    Rotation();
                    Shoot();
                }
            }
            catch
            {
                Debug.Log("error inesperado");
            }
        }
    }
    public void Rotation()
    {
        Vector3 dir = gameObject.transform.position - target[0].position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + 90;
        gameObject.transform.rotation = Quaternion.Euler(0,0,-angle);
    }
    public void Shoot()
    {
        time += Time.deltaTime;
        if (time>timebtw)
        {
            timebtw = General.dronvelocity;
            time = 0;
            GameManager.instance.playsfx(audioshot);
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}
