using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class General
{
    public static float swordvelocity = 1;
    public static float sworddamage = 5;
    public static float dronvelocity = 1;
    public static float dronDamage = 5;

    public static float ballvelocity = 1;
    public static float ballDamage = 5;

    public static float areavelocity = 1;
    public static float areaDamage = 0.2f;

    public static float tiempo = 1;

    public static bool drone = false, sword = true, ballEnergy = false, area = false;

    public static float life, lifetotal;

    public static int regen = 0, speed = 0, armadura = 0, criticos = 0, regenLvl = 1, speedLvl = 1, armaduraLvl = 1, criticosLvl = 1,kills = 0;

    public static void ValuesDefault()
    {


        swordvelocity = 1;
        sworddamage = 5;
        dronvelocity = 1;
        dronDamage = 5;

        ballvelocity = 1;
        ballDamage = 5;

        areavelocity = 1;
        areaDamage = 0.2f;

        tiempo = 1;

        drone = false;
        sword = true;
        ballEnergy = false;
        area = false;

        life = 0;
        lifetotal = 0;

        regen = 0; 
        speed = 0;
        armadura = 0;
        criticos = 0;
        regenLvl = 1;
        speedLvl = 1;
        armaduraLvl = 1;
        criticosLvl = 1;
        kills = 0;
    }

}
