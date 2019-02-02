using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarp : Card
{
    public override void OnActivation()
    {
        Card[] externalThreats = GameObject.Find("External Threats").GetComponentsInChildren<Card>();
        foreach (Card card in externalThreats)
        {
            card.HealByOne();
        }
    }
}
