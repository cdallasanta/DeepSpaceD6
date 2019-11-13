using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hijackers : Card
{
    public override void OnActivation()
    {
        ship.DamageHull(2);
    }
}
