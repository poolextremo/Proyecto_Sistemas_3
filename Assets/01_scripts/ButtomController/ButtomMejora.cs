using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtomMejora : MonoBehaviour
{
    public Player pl;
    public TextMeshProUGUI text;
    public Player.Mejoras upgrade;
    public Button bt;
    public bool mejora;
    public bool lista;
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        upgrade = Player.Mejoras.damagedron;
        Debug.Log("Hola mamahuevoi");
    }

    // Update is called once per frame
    void Update()
    {
        while (!mejora)
        {
            int i = Random.Range(1, 6);
            switch (i)
            {
                case 1:
                    upgrade = Player.Mejoras.SwordVelocity;
                    break;
                case 2:
                    upgrade = Player.Mejoras.dronextra;
                    break;
                case 3:
                    upgrade = Player.Mejoras.velocitydron;
                    break;
                case 4:
                    upgrade = Player.Mejoras.damagedron;
                    break;
                case 5:
                    upgrade = Player.Mejoras.damageSword;
                    break;
                default:
                    break;
            }
            mejora = true;
            if (pl.drones[pl.drones.Count - 1].activeSelf && i == 2)
            {
                mejora = false;
            }
        }
        switch (upgrade)
        {
            case Player.Mejoras.SwordVelocity:
                text.text = "velocidad de la espada +5%";
                if (!lista)
                {
                    bt.onClick.AddListener(SwordVelocity);
                    lista = true;
                }
                    
                break;
            case Player.Mejoras.dronextra:
                text.text = "+1 dron";
                if (!lista)
                {
                    bt.onClick.AddListener(DronExtra);
                    lista = true;
                }
                    
                break;
            case Player.Mejoras.velocitydron:
                text.text = "velocidad del dron +10%";
                if (!lista)
                {
                    bt.onClick.AddListener(VelocityDron);
                    lista = true;
                }
                    
                break;
            case Player.Mejoras.damagedron:
                text.text = "daño de los drones +15%";
                if (!lista)
                {
                    bt.onClick.AddListener(DamageDron);
                    lista = true;

                }
                break;
            case Player.Mejoras.damageSword:
                text.text = "daño de la espada +10%";
                if (!lista)
                {
                    bt.onClick.AddListener(Sworddamage);
                    lista = true;
                }
                    
                break;
            default:
                text.text = "error inesperado";
                break;
        }
    }
    public void Sworddamage()
    {
        General.sworddamage += General.sworddamage * 0.1f;
        bt.onClick.RemoveListener(Sworddamage);
    }
    public void SwordVelocity()
    {
        //Debug.Log("curioso: " + General.swordvelocity * 0.05f);
        General.swordvelocity = (General.swordvelocity+General.swordvelocity*0.05f);
        bt.onClick.RemoveListener(SwordVelocity);
    }
    public void DamageDron()
    {
        General.dronDamage += General.dronDamage * 0.15f;
        bt.onClick.RemoveListener(DamageDron);
    }
    public void VelocityDron()
    {
        General.dronvelocity += General.dronvelocity * 0.1f;
        bt.onClick.RemoveListener(VelocityDron);
    }
    public void DronExtra()
    {
        pl.ActivarDron();
        bt.onClick.RemoveListener(DronExtra);
    }
}
