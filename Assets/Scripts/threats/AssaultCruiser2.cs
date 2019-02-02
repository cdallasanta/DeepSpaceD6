using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultCruiser2 : Card
{
    public override void OnActivation()
    {
        ship.DamageHull(2);
    }
}
