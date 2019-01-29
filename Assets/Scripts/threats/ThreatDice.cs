using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatDice : MonoBehaviour
{
    public Sprite[] allSides = new Sprite[6];
    public int face;

    public void RollDice()
    {
        //set sprite to a random sprite
        int rand = Random.Range(0, 6);
        gameObject.GetComponent<SpriteRenderer>().sprite = allSides[rand];

        face = rand + 1;
    }
}
