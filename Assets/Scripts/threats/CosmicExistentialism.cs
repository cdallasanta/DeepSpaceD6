using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicExistentialism : Card
{
    
    public override void WhenPlayed()
    {
        ship.cosmicExistentialismInPlay = true;
    }

    public override void OnDestruction()
    {
        ship.cosmicExistentialismInPlay = false;
    }
}
