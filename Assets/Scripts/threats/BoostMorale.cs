using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMorale : Card
{

    // Start is called before the first frame update
    void Start()
    {
        title = "Boost Morale";
        type = "internal";
        activationNums = new int[] { 6 };
    }

    public override void OnActivation()
    {
        Dice dice = GameObject.Find("Scanners").GetComponentInChildren<Dice>();
        dice.MoveArea("Returned Area");

        DestroySelf();
    }
}
