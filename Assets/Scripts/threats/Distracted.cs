using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distracted : Card
{
    public override void WhenPlayed()
    {
        /* checks each area: returned, hand, internal, and external threats for a dice,
         * grabs the dice and puts it on this card.
         * if it came from a threat, add it back on to that card's alternate cost
         */
        if (GameObject.Find("Returned Area").GetComponentInChildren<Dice>() != null)
        {
            GameObject.Find("Returned Area").GetComponentInChildren<Dice>().MoveArea("Distracted Dice");
        }
        else if (GameObject.Find("Hand Area").GetComponentInChildren<Dice>() != null)
        {
            GameObject.Find("Hand Area").GetComponentInChildren<Dice>().MoveArea("Distracted Dice");
        }
        else if (GameObject.Find("Internal Threats").GetComponentInChildren<Dice>() != null)
        {
            Dice dice = GameObject.Find("Internal Threats").GetComponentInChildren<Dice>();
            dice.transform.parent.GetComponent<Card>().alternateCost.Add(dice.face);
            dice.MoveArea("Distracted Dice");
        }
        else if (GameObject.Find("External Threats").GetComponentInChildren<Dice>() != null)
        {
            Dice dice = GameObject.Find("External Threats").GetComponentInChildren<Dice>();
            dice.transform.parent.GetComponent<Card>().alternateCost.Add(dice.face);
            dice.MoveArea("Distracted Dice");
        }

        Dice distractedDice = GameObject.Find("Distracted Dice").GetComponentInChildren<Dice>();
        distractedDice.distracted = true;
    }

    public override void OnActivation()
    {
        DestroySelf();
    }

    public override void OnDestruction()
    {
        foreach(Dice dice in gameObject.GetComponentsInChildren<Dice>())
        {
            dice.MoveArea("Returned Area");
            dice.distracted = false;
        }
    }
}
