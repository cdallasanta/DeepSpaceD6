using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelExplosion : Card
{
    public override void WhenPlayed()
    {
        ship.engineeringDisabled = true;
    }

    public override void OnDestruction()
    {
        ship.engineeringDisabled = false;
    }
}
