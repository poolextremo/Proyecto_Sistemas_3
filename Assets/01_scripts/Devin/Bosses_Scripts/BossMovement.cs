using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float velocidad = 5f;
    public float distanciaDeSeguimiento = 5f;

    private Transform player;
    private Rigidbody2D rb2d;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("No se encontró el objeto del jugador.");
        }

        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            Vector2 direccion = player.position - transform.position;

            // Verifica si el jugador está dentro de la distancia de seguimiento
            if (direccion.magnitude <= distanciaDeSeguimiento)
            {
                // Normaliza la dirección para mantener una velocidad constante
                direccion.Normalize();

                // Mueve al enemigo hacia el jugador
                rb2d.velocity = direccion * velocidad;

                // Calcula el ángulo de rotación para que el enemigo mire al jugador
                float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
                rb2d.rotation = angulo;
            }
            else
            {
                // Si el jugador está fuera de la distancia de seguimiento, detén al enemigo
                rb2d.velocity = Vector2.zero;
            }
        }
    }
}
