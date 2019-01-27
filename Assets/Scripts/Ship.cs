using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private int hull;
    public int shields;
    private int scannersMax;
    private bool shieldsDisabled;
    private bool commanderDisabled;
    private GameObject scanners;
    public Game game;

    //TODO move to a function
    public Dice selectedDice;

    //TODO move these to the stations
    public bool weaponsUsed;
    public bool engineeringUsed;


    // Start is called before the first frame update
    void Start()
    {
        scanners = GameObject.Find("Scanners");
        scannersMax = 3;
        shieldsDisabled = false;
        commanderDisabled = false;
        game = gameObject.GetComponentInParent<Game>();
        weaponsUsed = false;
        engineeringUsed = false;
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

    public void ToggleShields()
    {
        shieldsDisabled = !shieldsDisabled;
    }

    public void ToggleCommander()
    {
        commanderDisabled = !commanderDisabled;
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

        if(hull <= 0)
        {
            game.GameOver();
        }
    }

    public void DirectDamage(int dmg)
    {
        hull -= dmg;

        if (hull <= 0)
        {
            game.GameOver();
        }
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
        weaponsUsed = false;
        engineeringUsed = false;
    }
}
