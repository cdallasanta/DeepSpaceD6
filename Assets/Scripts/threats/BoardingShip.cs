﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardingShip : Card
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void OnActivation()
    {
        ship.DamageHull(2);
    }

    public override void OnDestruction()
    {
        if (alternateCost.Count == 0)
        {
            ship.SendDiceToInfirmary();
        }
    }
}
