using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform target; // El transform del jugador
    public float smoothSpeed = 0.125f; // Qu� tan r�pido la c�mara sigue al jugador
    public Vector3 offset = new Vector3(0f, 0f, -10f); // El desplazamiento desde la posici�n del jugador

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
