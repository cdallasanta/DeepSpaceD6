using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardingShip : Card
{
    // Start is called before the first frame update
    void Start()
    {
        alternateCost.Add("Weapons");
    }

    public override void OnActivation()
    {
        ship.DamageHull(2);
    }

    public override void OnDestruction()
    {
        Debug.Log("onDestruction");
        if (alternateCost.Count == 0)
        {
            Dice dice = GameObject.Find("Returned Area").GetComponentInChildren<Dice>();
            dice.MoveArea("Infirmary Area");
        }
    }
}
