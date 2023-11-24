using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class cargadopuntos : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    void Start()
    {
        puntos.text = "Obtuviste " + (int)(General.kills*10 + General.time * 10 + General.experience) + " puntos";
    }

}
