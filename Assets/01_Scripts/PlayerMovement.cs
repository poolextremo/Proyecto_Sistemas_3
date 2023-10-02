using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4;
    Rigidbody rb;
    public Vector3 moveDir;
    public GameObject popUpPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        // Move the player
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the specific object you want
        if (collision.gameObject.CompareTag("Anvil"))
        {
            // Show the pop-up window
            popUpPanel.SetActive(true);
            Debug.Log("collision");
        }
        else
        {
            popUpPanel.SetActive(false);
        }
    }
}
