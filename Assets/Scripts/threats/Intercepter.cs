using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercepter : Card
{
    public override void OnActivation()
    {
        ship.DamageHull(1);
    }
}
