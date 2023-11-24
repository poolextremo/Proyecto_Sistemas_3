using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ButtomItem : MonoBehaviour
{
    public items item;
    public TextMeshProUGUI texto;
    public Button bt;
    public Player pl;
    public float costo;

    public AudioClip sonidomejora;
    void Start()
    {
        costo = 5;
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        switch (item)
        {
            case items.Sword:
                    bt.onClick.AddListener(Sword);
                break;
            case items.Drone:
                    bt.onClick.AddListener(Drone);
                    bt.enabled = false;
                break;
            case items.BallEnergy:
                    bt.onClick.AddListener(BallEnergy);
                    bt.enabled = false;
                break;
            case items.Area:
                    bt.onClick.AddListener(Area);
                    bt.enabled = false;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Cancelacion.iscancel)
        {
            switch (item)
            {
                case items.Sword:
                    if (General.sword)
                    {
                        texto.text = "espada: " + (int)costo;
                        if (!bt.enabled)
                            bt.enabled = true;
                    }
                         
                    break;
                case items.Drone:
                    if (General.drone)
                    {
                        texto.text = "Drone: " + (int)costo;
                        if (!bt.enabled)
                        {
                            bt.enabled = true;
                        }
                           
                    }
                        
                    break;
                case items.BallEnergy:
                    if (General.ballEnergy)
                    {
                        texto.text = "bola de energia: " + (int)costo;
                        if (!bt.enabled)
                            bt.enabled = true;
                    }
                        
                    break;
                case items.Area:
                    if (General.area)
                    {
                        texto.text = "area de efuego: " + (int)costo;
                        if (!bt.enabled)
                            bt.enabled = true;
                    }
                    break;
                default:
                    break;
            }
        }
       
    }
    public void Sword()
    {
        if ((int)pl.coins>=(int)costo)
        {
            GameManager.instance.playsfx(sonidomejora);
            pl.TakeCoin(-(int)costo);
            costo *= 1.5f;
            General.swordvelocity *= 1.2f;
            General.sworddamage *= 1.2f;
        }
    }
    public void Drone()
    {
        Debug.Log("entro dron");
        if ((int)pl.coins >= (int)costo)
        {
            GameManager.instance.playsfx(sonidomejora);
            pl.TakeCoin(-(int)costo);
            costo *= 1.5f;
            General.dronvelocity /= 1.5f;
            General.dronDamage *= 1.5f;
        }
            
    }
    public void BallEnergy()
    {
        if ((int)pl.coins >= (int)costo)
        {
            GameManager.instance.playsfx(sonidomejora);
            pl.TakeCoin(-(int)costo);
            costo *= 1.5f;
            //General.ballDamage /= 1.5f;
            General.ballDamage *= 1.2f;
        }
    }
    public void Area()
    {
        if ((int)pl.coins >= (int)costo)
        {
            GameManager.instance.playsfx(sonidomejora);
            pl.TakeCoin(-(int)costo);
            costo *= 1.5f;
            //General.ballDamage /= 1.5f;
            General.areaDamage *= 1.5f;
        }
    }
    public enum items
    {
        Sword,
        Drone,
        BallEnergy,
        Area
    }
}
