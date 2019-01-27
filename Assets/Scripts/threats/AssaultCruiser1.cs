﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultCruiser1 : Card
{

    // Start is called before the first frame update
    void Start()
    {
        title = "Assault Cruiser";
        type = "external";
        MAXHP = 4;
        currentHP = MAXHP;
        activationNums = new int[] {4, 5};
    }

    public override void OnActivation()
    {
        ship.DamageHull(2);
    }
}