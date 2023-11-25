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

    public AudioClip sonidomejora;
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        upgrade = Player.Mejoras.velocidad;
    }

    void Update()
    {
        while (!mejora)
        {
            bt.onClick.RemoveAllListeners();
            int i = Random.Range(1, 9);
            switch (i)
            {
                case 1:
                    upgrade = Player.Mejoras.armadura;
                    mejora = true;
                    if (General.armaduraLvl > 5)
                    {
                        mejora = false;
                    }
                    break;
                case 2:
                    upgrade = Player.Mejoras.dronextra;
                    Debug.Log("activar dron");
                    mejora = true;
                    if (pl.drones[pl.drones.Count - 1].activeSelf)
                    {
                        mejora = false;
                    }
                    break;
                case 3:
                    upgrade = Player.Mejoras.regeneracion;
                    mejora = true;
                    if (General.regenLvl > 5)
                    {
                        mejora = false;
                    }
                    break;
                case 4:
                    upgrade = Player.Mejoras.velocidad;
                    mejora = true;
                    if (General.speedLvl > 5)
                    {
                        mejora = false;
                    }
                    break;
                case 5:
                    upgrade = Player.Mejoras.criticos;
                    mejora = true;
                    if (General.criticosLvl > 5)
                    {
                        mejora = false;
                    }
                    break;
                case 6:
                    upgrade = Player.Mejoras.ball;
                    mejora = true;
                    if (General.ballEnergy)
                    {
                        mejora = false;
                    }
                    break;
                case 7:
                    upgrade = Player.Mejoras.area;
                    mejora = true;
                    if (General.area)
                    {
                        mejora = false;
                    }
                    break;
                case 8:
                    upgrade = Player.Mejoras.life;
                    mejora = true;
                    break;
                default:
                    break;
            }
        }
        switch (upgrade)
        {
            case Player.Mejoras.armadura:

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
            case Player.Mejoras.regeneracion:

                if (!lista)
                {
                    text.text = "Regeneracion nivel " + General.regenLvl;
                    bt.onClick.AddListener(regenLvlUp);
                    lista = true;
                }

                break;
            case Player.Mejoras.velocidad:

                if (!lista)
                {
                    text.text = "velocidad nivel " + General.speedLvl;
                    bt.onClick.AddListener(SpeedLvlUp);
                    lista = true;

                }
                break;
            case Player.Mejoras.criticos:
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
                    text.text = "area dañina ";
                    bt.onClick.AddListener(Area);
                    lista = true;
                }
                break;
            case Player.Mejoras.life:
                if (!lista)
                {
                    text.text = "100 de vida";
                    bt.onClick.AddListener(Vida);
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
        GameManager.instance.playsfx(sonidomejora);
        bt.onClick.RemoveListener(CriticosLvlUp);

    }
    public void ArmorLvlUp()
    {
        General.armadura = General.armadura + 15;
        General.armaduraLvl++;
        GameManager.instance.playsfx(sonidomejora);
        bt.onClick.RemoveListener(ArmorLvlUp);
    }
    public void SpeedLvlUp()
    {
        General.speed = General.speed + 0.25f;
        General.speedLvl++;
        pl.AplicChange();
        GameManager.instance.playsfx(sonidomejora);
        bt.onClick.RemoveListener(SpeedLvlUp);
    }
    public void regenLvlUp()
    {
        General.regen = General.regen + 50;
        General.regenLvl++;
        GameManager.instance.playsfx(sonidomejora);
        bt.onClick.RemoveListener(regenLvlUp);
    }
    public void DronExtra()
    {
        pl.ActivarDron();
        //Debug.Log("el dron esta aqui");
        GameManager.instance.playsfx(sonidomejora);
        bt.onClick.RemoveListener(DronExtra);
    }
    public void ball()
    {
        General.ballEnergy = true;
        pl.ballImage.gameObject.SetActive(true);
        GameManager.instance.playsfx(sonidomejora);
        bt.onClick.RemoveListener(ball);
    }
    public void Area()
    {
        General.area = true;
        pl.area.SetActive(true);
        pl.acticararea();
        GameManager.instance.playsfx(sonidomejora);
        bt.onClick.RemoveListener(Area);
    }
    public void Vida()
    {
        pl.life = 100;
        GameManager.instance.playsfx(sonidomejora);
        bt.onClick.RemoveListener(Vida);
    }
}