using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyFire : Card
{
    public override void OnActivation()
    {
        //go through all dice, and if they are on weapons, send to infirmary
        foreach(Dice dice in GameObject.Find("Game").GetComponentsInChildren<Dice>())
        {
            if (dice.face == "Weapons")
            {
                dice.MoveArea("Infirmary");
            }
        }

        DestroySelf();
    }
}
