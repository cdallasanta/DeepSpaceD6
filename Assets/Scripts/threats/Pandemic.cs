using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pandemic : Card
{
    public override void OnActivation()
    {
        ship.SendDiceToInfirmary();
    }

    public override void WhenPlayed()
    {
        base.WhenPlayed();
        if(alternateCost.Count <= 1)
        {
            DestroySelf();
        }
    }
}
