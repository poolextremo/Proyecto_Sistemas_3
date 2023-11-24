using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapc4 : MonoBehaviour
{
    public List<GameObject> mapTilePrefabs;
    public int mapSize = 15;

    private Transform player;
    private Vector2Int currentPlayerTile;
    private Dictionary<Vector2Int, GameObject> mapTiles = new Dictionary<Vector2Int, GameObject>();

    private void Start()
    {
        player = transform;
        currentPlayerTile = WorldToTilePosition(player.position);
        SpawnMapTileAroundPosition(currentPlayerTile);
    }

    private void Update()
    {
        Vector2Int newPlayerTile = WorldToTilePosition(player.position);

        if (newPlayerTile != currentPlayerTile)
        {
            currentPlayerTile = newPlayerTile;
            SpawnMapTileAroundPosition(currentPlayerTile);
            RemoveDistantMapTiles(currentPlayerTile);
        }
    }

    private Vector2Int WorldToTilePosition(Vector3 worldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt(worldPosition.x / mapSize), Mathf.FloorToInt(worldPosition.y / mapSize));
    }

    private void SpawnMapTileAroundPosition(Vector2Int centerTile)
    {
        foreach (Vector2Int offset in GetRandomTileOffsets())
        {
            Vector2Int tilePos = centerTile + offset;

            if (!mapTiles.ContainsKey(tilePos))
            {
                Vector3 spawnPosition = new Vector3(tilePos.x * mapSize, tilePos.y * mapSize, 10);

                GameObject randomMapTilePrefab = mapTilePrefabs[Random.Range(0, mapTilePrefabs.Count)];

                GameObject newTile = Instantiate(randomMapTilePrefab, spawnPosition, Quaternion.identity);
                mapTiles.Add(tilePos, newTile);
            }
        }
    }

    private List<Vector2Int> GetRandomTileOffsets()
    {
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

        ShuffleList(offsets);

        return offsets;
    }

    private void RemoveDistantMapTiles(Vector2Int centerTile)
    {
        List<Vector2Int> tilesToRemove = new List<Vector2Int>();

        foreach (var tilePos in mapTiles.Keys)
        {
            float distance = Vector2Int.Distance(centerTile, tilePos);
            float distanceThreshold = 10.0f;

            if (distance > distanceThreshold)
            {
                tilesToRemove.Add(tilePos);
            }
        }

        foreach (var tilePos in tilesToRemove)
        {
            Destroy(mapTiles[tilePos]);
            mapTiles.Remove(tilePos);
        }
    }

    private void ShuffleList<T>(List<T> list)
    {
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
