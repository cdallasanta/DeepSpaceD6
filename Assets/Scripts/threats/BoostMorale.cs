using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMorale : Card
{

    // Start is called before the first frame update
    void Start()
    {
    }

    public override void OnActivation()
    {
        Dice dice = GameObject.Find("Scanners").GetComponentInChildren<Dice>();
        if (dice != null)
        {
            dice.MoveArea("Returned Area");
        }

        DestroySelf();
    }
}
