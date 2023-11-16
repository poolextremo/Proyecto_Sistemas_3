using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource sfxAS, sfxASloop;
    public static GameManager instance;
    public float textoVeocidad = 1, textoescritura = 0;
    public bool gameOver = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void playsfx(AudioClip sfx)
    {
        sfxAS.PlayOneShot(sfx);
    }
    public void playsfxloop(AudioClip sfx)
    {
        sfxAS.PlayOneShot(sfx);
    }
}
