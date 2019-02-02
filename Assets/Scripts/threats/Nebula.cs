using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nebula : Card
{
    public override void WhenPlayed()
    {
        ship.shields = 0;
        ship.shieldsDisabled = true;
    }

    public override void OnActivation()
    {
        ship.DamageHull(1);
    }

    public override void OnDestruction()
    {
        ship.shieldsDisabled = false;
    }
}
