using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyShip : Card
{

    // Start is called before the first frame update
    void Start()
    {
    }

    public override void OnActivation()
    {
        ship.shields = 0;
        ship.DamageHull(1);
    }
}
