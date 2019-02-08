using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pandemic : Card
{
    public override void OnActivation()
    {
        ship.SendDiceToInfirmary();
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if(alternateCost.Count <= 1)
        {
            Dice[] diceHere = GetComponentsInChildren<Dice>();
            foreach (Dice dice in diceHere)
            {
                dice.MoveArea("Returned Area");
            }
            DestroySelf();
        }
    }
}
