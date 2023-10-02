using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapc4 : MonoBehaviour
{
    public List<GameObject> mapTilePrefabs;  // Lista de prefabricados de mapTiles.
    public int mapSize = 10;                // Tamaño de la cuadrícula del mapa (por ejemplo, 10x10).

    private Transform player;                 // Referencia al Transform del jugador.
    private Vector2Int currentPlayerTile;    // La posición de la cuadrícula actual del jugador.
    private Dictionary<Vector2Int, GameObject> mapTiles = new Dictionary<Vector2Int, GameObject>();

    private void Start()
    {
        player = transform;  // Asigna el Transform del jugador.

        // Inicialmente genera un tile alrededor del jugador.
        currentPlayerTile = WorldToTilePosition(player.position);
        SpawnMapTileAroundPosition(currentPlayerTile);
    }

    private void Update()
    {
        // Verifica la posición de la cuadrícula actual del jugador.
        Vector2Int newPlayerTile = WorldToTilePosition(player.position);

        // Si el jugador se ha movido a una nueva cuadrícula, actualiza la cuadrícula actual.
        if (newPlayerTile != currentPlayerTile)
        {
            currentPlayerTile = newPlayerTile;

            // Genera un nuevo mapTile alrededor de la posición del jugador.
            SpawnMapTileAroundPosition(currentPlayerTile);

            // Elimina los mapTiles antiguos que están lejos del jugador.
            RemoveDistantMapTiles(currentPlayerTile);
        }
    }

    private Vector2Int WorldToTilePosition(Vector3 worldPosition)
    {
        // Convierte la posición del mundo a posición de cuadrícula/tile.
        return new Vector2Int(Mathf.FloorToInt(worldPosition.x / mapSize), Mathf.FloorToInt(worldPosition.z / mapSize));
    }

    private void SpawnMapTileAroundPosition(Vector2Int centerTile)
    {
        foreach (Vector2Int offset in GetRandomTileOffsets())
        {
            Vector2Int tilePos = centerTile + offset;

            // Comprueba si el tile ya existe; si no, instala uno nuevo al azar.
            if (!mapTiles.ContainsKey(tilePos))
            {
                Vector3 spawnPosition = new Vector3(tilePos.x * mapSize, 0, tilePos.y * mapSize);

                // Elige un prefab de mapTile al azar de la lista.
                GameObject randomMapTilePrefab = mapTilePrefabs[Random.Range(0, mapTilePrefabs.Count)];

                GameObject newTile = Instantiate(randomMapTilePrefab, spawnPosition, Quaternion.identity);
                mapTiles.Add(tilePos, newTile);
            }
        }
    }

    private List<Vector2Int> GetRandomTileOffsets()
    {
        // Esta función genera offsets aleatorios para colocar los mapTiles alrededor del jugador.
        List<Vector2Int> offsets = new List<Vector2Int>
        {
            new Vector2Int(-1, -1),
            new Vector2Int(-1, 0),
            new Vector2Int(-1, 1),
            new Vector2Int(0, -1),
            new Vector2Int(0, 0),
            new Vector2Int(0, 1),
            new Vector2Int(1, -1),
            new Vector2Int(1, 0),
            new Vector2Int(1, 1)
        };

        // Baraja la lista de offsets para que los mapTiles aparezcan en posiciones aleatorias.
        ShuffleList(offsets);

        return offsets;
    }

    private void RemoveDistantMapTiles(Vector2Int centerTile)
    {
        List<Vector2Int> tilesToRemove = new List<Vector2Int>();

        foreach (var tilePos in mapTiles.Keys)
        {
            // Calcula la distancia entre el tile actual y el tile del jugador.
            float distance = Vector2Int.Distance(centerTile, tilePos);

            // Define un umbral de distancia para eliminar los tiles distantes.
            float distanceThreshold = 2.0f;

            if (distance > distanceThreshold)
            {
                // Marca el tile para eliminarlo.
                tilesToRemove.Add(tilePos);
            }
        }

        // Elimina los tiles marcados del diccionario y los destruye.
        foreach (var tilePos in tilesToRemove)
        {
            Destroy(mapTiles[tilePos]);
            mapTiles.Remove(tilePos);
        }
    }

    private void ShuffleList<T>(List<T> list)
    {
        // Función para barajar una lista utilizando el algoritmo de Fisher-Yates.
        int n = list.Count;
        for (int i = 0; i < n; i++)
        {
            int randomIndex = Random.Range(i, n);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
