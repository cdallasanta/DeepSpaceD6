using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePirates2 : Card
{
    public override void OnActivation()
    {
        ship.DamageHull(2);
    }
}
