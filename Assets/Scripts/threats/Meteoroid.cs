using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoroid : Card
{
    public override void OnActivation()
    {
        ReduceHealth();
    }

    public override void OnDestruction()
    {
        ship.DamageHull(5);
    }
}
