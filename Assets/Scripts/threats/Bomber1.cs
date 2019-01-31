using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber1 : Card
{

    // Start is called before the first frame update
    void Start()
    {
        title = "Bomber";
        type = "external";
        MAXHP = 3;
        currentHP = MAXHP;
        activationNums = new int[] {3, 4};
    }

    public override void OnActivation()
    {
        ship.DamageHull(2);
        //send unit to infirmary
    }
}
