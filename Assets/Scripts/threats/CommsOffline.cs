using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommsOffline : Card
{
    public override void WhenPlayed()
    {
        ship.commanderDisabled = true;
    }

    public override void OnDestruction()
    {
        ship.commanderDisabled = false;
    }
}
