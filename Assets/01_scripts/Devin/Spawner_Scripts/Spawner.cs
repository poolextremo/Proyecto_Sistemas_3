using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyInfo
{
    public GameObject enemyPrefab;
    public float spawnTime;
}

public class Spawner : MonoBehaviour
{
    public EnemyInfo[] enemies; 

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        foreach (var enemyInfo in enemies)
        {
            while (true)
            {
                Instantiate(enemyInfo.enemyPrefab, transform.position, Quaternion.identity);

                yield return new WaitForSeconds(enemyInfo.spawnTime);
            }
        }
    }
}
