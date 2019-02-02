using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarWinds : Card
{
    public override void OnActivation()
    {
        ship.DamageHull(5);
        DestroySelf();
    }

    //this makes Solar Winds undamagable
    public override void ReduceHealth()
    {
    }
}
