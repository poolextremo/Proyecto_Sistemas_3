using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Image menu, menulvup;
    public float timeSwip, timeBtw, velocity = 100;
    public bool cambio = false, isactive = false;
    public List<ButtomMejora> bt;

    public TextMeshProUGUI lifeTxt, atackTxt, spdTxt, armTxt, crtTxt;

    public bool contar;

    public TextMeshProUGUI textKills;
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Image>();
        menulvup = GameObject.FindGameObjectWithTag("MenuUp").GetComponent<Image>();
    }

    void Update()
    {
        if (contar)
            textKills.text = "" + General.kills;
        if (Input.GetKeyDown(KeyCode.T))
            Debug.Log("Pocicion: " + menu.rectTransform.anchoredPosition.y);

        if (!Cancelacion.lvup)
        {
            lifeTxt.text = (int)General.life + "/" + (int)General.lifetotal;
            atackTxt.text = General.regen + "%";
            spdTxt.text = (General.speed*100) + "%";
            armTxt.text = General.armadura + "%";
            crtTxt.text = General.criticos + "%";
            if (Input.GetKeyDown(KeyCode.Q) && !cambio)
            {
                Cancelacion.iscancel = true;
                cambio = true;
            }
            if (cambio)
            {
                Cambio();
            }
        }

    }
    public void Cambio()
    {
        if (!isactive)
        {
            if (menu.rectTransform.anchoredPosition.y > -7)
            {
                menu.rectTransform.anchoredPosition = new Vector3(menu.rectTransform.anchoredPosition.x, menu.rectTransform.anchoredPosition.y - (Time.deltaTime * velocity), 0);
            }
            else
            {
                cambio = false;
                isactive = !isactive;
            }
        }
        else
        {
            if (menu.rectTransform.anchoredPosition.y < 1050)
            {
                menu.rectTransform.anchoredPosition = new Vector3(menu.rectTransform.anchoredPosition.x, menu.rectTransform.anchoredPosition.y + (Time.deltaTime * velocity), 0);
            }
            else
            {
                Cancelacion.iscancel = false;
                isactive = !isactive;
                cambio = false;
            }
        }

    }
    public void MenuLevelUp()
    {
        foreach (var item in bt)
        {
            item.mejora = false;
            item.lista = false;
        }
        menulvup.rectTransform.anchoredPosition = new Vector3(-6, -7, 0);
        Cancelacion.lvup = true;
        Cancelacion.iscancel = true;
    }
    public void MenuLevelUpDown()
    {
        menulvup.rectTransform.anchoredPosition = new Vector3(-6, 1050, 0);
        Cancelacion.lvup = false;
        Cancelacion.iscancel = false;
    }
}
