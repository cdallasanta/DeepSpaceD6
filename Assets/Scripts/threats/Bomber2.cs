﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber2 : Card
{

    // Start is called before the first frame update
    void Start()
    {
        title = "Bomber";
        type = "external";
        MAXHP = 2;
        currentHP = MAXHP;
        activationNums = new int[] { 2, 4 };
    }

    public override void OnActivation()
    {
        ship.DamageHull(2);
        //send unit to infirmary
    }
}
