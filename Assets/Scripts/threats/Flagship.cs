using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flagship : Card
{
    public override void OnActivation()
    {
        ship.DamageHull(3);
    }
}
