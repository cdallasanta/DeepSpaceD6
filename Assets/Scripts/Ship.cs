using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int hull;
    public int shields;
    private int scannersMax;
    public bool shieldsDisabled;
    public bool commanderDisabled;
    public bool engineeringDisabled;
    public bool cosmicExistentialismInPlay;
    private GameObject scanners;
    public Game game;
    public SpriteRenderer diceSpriteR;
    public bool waitingForChoice;
    public Dice selectedDice;


    // Start is called before the first frame update
    void Start()
    {
        scanners = GameObject.Find("Scanners");
        scannersMax = 3;
        shieldsDisabled = false;
        commanderDisabled = false;
        engineeringDisabled = false;
        cosmicExistentialismInPlay = false;
        game = gameObject.GetComponentInParent<Game>();
        hull = 8;
        shields = 4;
    }

    public Game Game()
    {
        return game;
    }

    public void CheckScanners()
    {
        if (ScannersCount() >= scannersMax)
        {
            ResolveScanners();
        }
    }

    private int ScannersCount()
    {
        return scanners.transform.childCount;
    }

    private void ResolveScanners()
    {
        game.deck.DrawCard();

        Dice[] diceInScanners = gameObject.GetComponentsInChildren<Dice>();

        foreach(Dice dice in diceInScanners)
        {
            dice.MoveArea("Returned Area");
        }
    }

    public void DamageHull(int dmg)
    {
        if(shields >= dmg)
        {
            shields -= dmg;
        } else
        {
            dmg -= shields;
            shields = 0;
            hull -= dmg;
        }
    }

    public void DirectDamage(int dmg)
    {
        hull -= dmg;
    }

    public void RepairHull(int amount)
    {
        hull += amount;

        if (hull > 8)
        {
            hull = 8;
        }
    }

    public void RefillShields()
    {
        if (!shieldsDisabled)
        {
            shields = 4;
        }
    }

    public void NextTurn()
    {
        gameObject.GetComponentInChildren<Weapons>().weaponsUsed = false;
        gameObject.GetComponentInChildren<Engineering>().engineeringUsed = false;
    }

    public void SendDiceToInfirmary()
    {
        /* checks each area: returned, hand, internal, and external threats for a dice,
         * grabs the diec and puts it on this card.
         * if it came from a threat, add it back on to that card's alternate cost.
         * Also check if the dice is on the Distracted card, in which case it is unavailable.
         */
        if (GameObject.Find("Returned Area").GetComponentInChildren<Dice>() != null)
        {
            GameObject.Find("Returned Area").GetComponentInChildren<Dice>().MoveArea("Infirmary Area");
        }
        else if (GameObject.Find("Hand Area").GetComponentInChildren<Dice>() != null)
        {
            GameObject.Find("Hand Area").GetComponentInChildren<Dice>().MoveArea("Infirmary Area");
        }
        else if (GameObject.Find("External Threats").GetComponentInChildren<Dice>() != null)
        {
            Dice dice = GameObject.Find("External Threats").GetComponentInChildren<Dice>();
            dice.transform.parent.GetComponent<Card>().alternateCost.Add(dice.face);
            dice.MoveArea("Infirmary Area");
        }
        else if (GameObject.Find("Internal Threats").GetComponentInChildren<Dice>() != null)
        {
            Dice dice = GameObject.Find("Internal Threats").GetComponentInChildren<Dice>();
            if(dice.distracted == false)
            {
                dice.transform.parent.GetComponent<Card>().alternateCost.Add(dice.face);
                dice.MoveArea("Infirmary Area");
            }
        }
        else
        {
            game.GameOver();
        }
    }
}
