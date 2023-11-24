using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject prefabObjeto; // El prefab del objeto que se generar�
    public int cantidadObjetos = 3; // N�mero de objetos a generar
    public float radioOrbita = 5f; // Radio de la �rbita de los objetos
    public float velocidadRotacion = 50f; // Velocidad de rotaci�n de los objetos

    void Start()
    {
        GenerarObjetosGiratorios();
    }

    void GenerarObjetosGiratorios()
    {
        for (int i = 0; i < cantidadObjetos; i++)
        {
            float angulo = i * 360f / cantidadObjetos; // �ngulo en grados
            Vector3 posicion = Quaternion.Euler(0, angulo, 0) * Vector3.forward * radioOrbita;

            GameObject objetoInstanciado = Instantiate(prefabObjeto, transform.position + posicion, Quaternion.identity);
            objetoInstanciado.transform.parent = transform; // Hacer que el jugador sea el padre para que siga al jugador
        }
    }

    void Update()
    {
        RotarObjetosGiratorios();
    }

    void RotarObjetosGiratorios()
    {
        foreach (Transform hijo in transform)
        {
            // Obtener la direcci�n desde el objeto hijo hacia el jugador
            Vector3 direccionAlJugador = (transform.position - hijo.position).normalized;

            // Calcular la posici�n a lo largo de la �rbita del jugador
            Vector3 posicionOrbita = transform.position + direccionAlJugador * radioOrbita;

            // Rotar el objeto hijo alrededor del jugador
            hijo.RotateAround(posicionOrbita, Vector3.up, velocidadRotacion * Time.deltaTime);
        }
    }

}
