using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raiders2 : Card
{
    public override void OnActivation()
    {
        ship.DirectDamage(2);
    }
}
