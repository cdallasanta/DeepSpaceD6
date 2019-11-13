using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : Card
{
    public override void OnActivation()
    {
        ship.SendDiceToInfirmary();
    }
}
