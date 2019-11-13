using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone1 : Card
{
    public override void OnActivation()
    {
        ship.DamageHull(1);
    }
}
