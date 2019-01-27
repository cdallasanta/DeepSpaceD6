using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatDice : MonoBehaviour
{
    public Sprite[] allSides = new Sprite[6];
    public int value;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void RollDice()
    {
        //set sprite to a random sprite
        int rand = Random.Range(0, 6);
        value = rand;
        gameObject.GetComponent<SpriteRenderer>().sprite = allSides[rand];
    }
}
