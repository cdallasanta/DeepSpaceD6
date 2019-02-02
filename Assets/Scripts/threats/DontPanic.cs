using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontPanic : Card
{
    public override void OnActivation()
    {
        DestroySelf();
    }
}
