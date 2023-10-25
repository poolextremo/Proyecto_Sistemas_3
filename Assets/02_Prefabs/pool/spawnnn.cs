using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnnn : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnInfo
    {
        public GameObject enemyPrefab;
        public float spawnTime;
        public float spawnDuration;
    }

    public EnemySpawnInfo[] enemies;  // Array para almacenar información de spawn de cada tipo de enemigo

    private void Start()
    {
        // Comienza la generación de enemigos
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        foreach (var enemyInfo in enemies)
        {
            float elapsedTime = 0f;

            while (elapsedTime < enemyInfo.spawnDuration)
            {
                // Instancia el enemigo
                Instantiate(enemyInfo.enemyPrefab, transform.position, Quaternion.identity);

                // Espera el tiempo de spawn antes de instanciar el siguiente enemigo
                yield return new WaitForSeconds(enemyInfo.spawnTime);

                // Actualiza el tiempo transcurrido
                elapsedTime += enemyInfo.spawnTime;
            }
        }

        // Realiza alguna acción después de generar todos los tipos de enemigos
        Debug.Log("Generación completa de enemigos");
    }
}
