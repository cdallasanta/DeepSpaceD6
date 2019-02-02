using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber2 : Card
{

    // Start is called before the first frame update
    void Start()
    {
    }

    public override void OnActivation()
    {
        ship.DamageHull(2);
        ship.SendDiceToInfirmary();
    }
}
