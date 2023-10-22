using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
    public GameObject popUpPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the specific object you want
        if (collision.gameObject.CompareTag("Anvil"))
        {
            // Show the pop-up window
            popUpPanel.SetActive(false);
            Debug.Log("collision");
        }
    }
}
