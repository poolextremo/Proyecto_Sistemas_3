using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapGenerator mp;
    public GameObject targetMap;
    void Start()
    {
        mp = FindObjectOfType<MapGenerator>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            mp.currentChunk = targetMap;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (mp.currentChunk == targetMap)
            {
                mp.currentChunk = null;
            }
        }
    }
}
