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
        //Debug.Log("Hola mamahuevoi");
    }

    void Update()
    {
        while (!mejora)
        {
            bt.onClick.RemoveAllListeners();
            int i = Random.Range(1, 8);
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
                case 6:
                    upgrade = Player.Mejoras.ball;
                    break;
                case 7:
                    upgrade = Player.Mejoras.area;
                    break;
                default:
                    break;
            }
            mejora = true;

            if (pl.drones[pl.drones.Count - 1].activeSelf && i == 2)
            {
                mejora = false;
            }
            if (General.ballEnergy && i == 6)
            {
                mejora = false;
            }
            if (General.area && i == 7)
            {
                mejora = false;
            }
        }
        switch (upgrade)
        {
            case Player.Mejoras.SwordVelocity:

                if (!lista)
                {
                    text.text = "Armadura nivel " + General.armaduraLvl;
                    bt.onClick.AddListener(ArmorLvlUp);
                    lista = true;
                }

                break;
            case Player.Mejoras.dronextra:

                if (!lista)
                {
                    text.text = "+1 dron";
                    bt.onClick.AddListener(DronExtra);
                    lista = true;
                }

                break;
            case Player.Mejoras.velocitydron:

                if (!lista)
                {
                    text.text = "Regeneracion nivel " + General.regenLvl;
                    bt.onClick.AddListener(regenLvlUp);
                    lista = true;
                }

                break;
            case Player.Mejoras.damagedron:

                if (!lista)
                {
                    text.text = "velocidad nivel " + General.speedLvl;
                    bt.onClick.AddListener(SpeedLvlUp);
                    lista = true;

                }
                break;
            case Player.Mejoras.damageSword:
                if (!lista)
                {
                    text.text = "criticos nivel " + General.criticosLvl;
                    bt.onClick.AddListener(CriticosLvlUp);
                    lista = true;
                }
                break;
            case Player.Mejoras.ball:
                if (!lista)
                {
                    text.text = "bola de energia ";
                    bt.onClick.AddListener(ball);
                    lista = true;
                }
                break;
            case Player.Mejoras.area:
                if (!lista)
                {
                    text.text = "area da�ina ";
                    bt.onClick.AddListener(Area);
                    lista = true;
                }
                break;
            default:
                text.text = "error inesperado";
                break;
        }
    }
    public void CriticosLvlUp()
    {
        General.criticos = General.criticos + 10;
        General.criticosLvl++;
        bt.onClick.RemoveListener(CriticosLvlUp);

    }
    public void ArmorLvlUp()
    {
        //Debug.Log("curioso: " + General.swordvelocity * 0.05f);
        General.armadura += General.armadura + 15;
        General.armaduraLvl++;
        bt.onClick.RemoveListener(ArmorLvlUp);
    }
    public void SpeedLvlUp()
    {
        General.speed = General.speed + 25;
        General.speedLvl++;
        pl.AplicChange();
        bt.onClick.RemoveListener(SpeedLvlUp);
    }
    public void regenLvlUp()
    {
        General.regen = General.regen + 50;
        General.regenLvl++;
        bt.onClick.RemoveListener(regenLvlUp);
    }
    public void DronExtra()
    {
        pl.ActivarDron();
        //Debug.Log("el dron esta aqui");
        bt.onClick.RemoveListener(DronExtra);
    }
    public void ball()
    {
        General.ballEnergy = true;
        //Debug.Log("el dron esta aqui");
        bt.onClick.RemoveListener(ball);
    }
    public void Area()
    {
        General.area = true;
        pl.area.SetActive(true);
        bt.onClick.RemoveListener(Area);
    }
}