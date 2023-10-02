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
    public EnemyInfo[] enemies; // Array para almacenar los enemigos y sus tiempos de spawn.

    void Start()
    {
        // Llama a la funci�n SpawnEnemies repetidamente.
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        foreach (var enemyInfo in enemies)
        {
            while (true)
            {
                // Instancia el enemigo en la posici�n del Spawner.
                Instantiate(enemyInfo.enemyPrefab, transform.position, Quaternion.identity);

                // Espera el tiempo espec�fico para este enemigo antes de intentar spawnear otro.
                yield return new WaitForSeconds(enemyInfo.spawnTime);
            }
        }
    }
}
