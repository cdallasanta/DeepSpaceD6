using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommsOffline : Card
{
    public override void WhenPlayed()
    {
        //TODO make this do something. it's not checked anywhere
        ship.commanderDisabled = true;
    }

    public override void OnDestruction()
    {
        ship.commanderDisabled = false;
    }
}
