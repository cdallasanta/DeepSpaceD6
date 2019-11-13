using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePirates1 : Card
{
    public override void OnActivation()
    {
        ship.DamageHull(2);
    }
}
