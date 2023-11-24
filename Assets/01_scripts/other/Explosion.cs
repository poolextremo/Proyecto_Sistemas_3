using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float growthRate = 0.1f;
    public float maxSize = 20.0f;

    private void Update()
    {
        // Scale the object up over time
        transform.localScale += Vector3.one * growthRate * Time.deltaTime;

        // Check if the object has reached the desired size
        if (transform.localScale.x >= maxSize)
        {
            // Destroy the object
            Destroy(gameObject);
        }
    }
}
