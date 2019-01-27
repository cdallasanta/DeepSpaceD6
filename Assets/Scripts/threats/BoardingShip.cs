using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardingShip : Card
{

    // Start is called before the first frame update
    void Start()
    {
        title = "Boarding Ship";
        type = "external";
        MAXHP = 4;
        currentHP = MAXHP;
        activationNums = new int[] {3, 4};
        alternateCost = new string[] {"weapons"};
    }

    public override void OnActivation()
    {
        ship.DamageHull(2);
    }

    public override void AlternateDestruction()
    {
        //TODO send unit to infirmary
    }
}
