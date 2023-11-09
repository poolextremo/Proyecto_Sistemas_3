using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawn : MonoBehaviour
{
    [System.Serializable]
    public class EnemyData
    {
        public GameObject enemyPrefab;
    }

    [System.Serializable]
    public class Wave
    {
        public EnemyData[] enemies;
        public float duration; // Duración de la oleada en segundos
    }

    public Wave[] waves;
    public float timeBetweenWaves = 5f;

    private int currentWave = 0;
    private bool spawning = false;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave < waves.Length)
        {
            Debug.Log("entro 1");
            if (!Cancelacion.iscancel)
            {
                Debug.Log("entro 2");
                Wave currentWaveData = waves[currentWave];
                float elapsedTime = 0f;

                while (elapsedTime < currentWaveData.duration)
                {
                    foreach (EnemyData enemyData in currentWaveData.enemies)
                    {
                        SpawnEnemy(enemyData.enemyPrefab);
                        yield return new WaitForSeconds(1f); // Ajusta según sea necesario
                    }

                    elapsedTime += 1f * currentWaveData.enemies.Length; // Se asume que cada enemigo toma 1 segundo
                }

                currentWave++;
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}

