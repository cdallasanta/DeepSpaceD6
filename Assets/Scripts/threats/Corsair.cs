using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corsair : Card
{
    public override void OnActivation()
    {
        ship.DamageHull(2);
    }
}
