using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Transform player;

    void Start()
    {
        //player = FindObjectOfType<PlayerMovement>().transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);
    }
}
