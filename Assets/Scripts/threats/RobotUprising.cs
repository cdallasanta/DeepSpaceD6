using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotUprising : Card
{
    public override void OnActivation()
    {
        ship.SendDiceToInfirmary();
    }
}
