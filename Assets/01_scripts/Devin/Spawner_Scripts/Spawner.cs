using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public List<GameObject> enemigos;

    public float time = 0, timebtw = 1;

    public int cant, enemy;

    public Transform pos1, pos2;
    void Start()
    {
        enemy = 0;
        cant = Random.Range(20,40);
    }
    private void Update()
    {
        if (!Cancelacion.iscancel)
        {
            time += Time.deltaTime;
            if (time > timebtw)
            {
                time = 0;
                cant--;
                if (Random.Range(0,2) == 1)
                {
                    if (Random.Range(0, 2) == 1)
                        Instantiate(enemigos[enemy], new Vector2(pos1.position.x, Random.Range(pos2.position.y, pos1.position.y)), transform.rotation);
                    else
                        Instantiate(enemigos[enemy], new Vector2(pos2.position.x, Random.Range(pos2.position.y, pos1.position.y)), transform.rotation);
                }
                else
                {
                    if (Random.Range(0, 2) == 1)
                        Instantiate(enemigos[enemy], new Vector2(Random.Range(pos2.position.x, pos1.position.x), pos1.position.y), transform.rotation);
                    else
                        Instantiate(enemigos[enemy], new Vector2(Random.Range(pos2.position.x, pos1.position.x), pos2.position.y), transform.rotation);
                }
                if (cant == 0)
                {
                    enemy++;
                    if (enemy == enemigos.Count)
                        enemy = 0;
                    cant = Random.Range(20, 40);
                }
            }
        }
       
    }
}
