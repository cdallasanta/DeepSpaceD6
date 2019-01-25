using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int hull = 8;
    public int shields = 4;
    public int scannersMax = 3;
    public bool shieldsDisabled;
    public bool commanderDisabled;
    private GameObject scanners;
    public Game game;
    public Dice selectedDice;

    //move these to the stations
    public bool weaponsUsed;
    public bool engineeringUsed;


    // Start is called before the first frame update
    void Start()
    {
        scanners = GameObject.Find("Scanners");
        shieldsDisabled = false;
        commanderDisabled = false;
        game = gameObject.GetComponentInParent<Game>();
        weaponsUsed = false;
        engineeringUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        //TODO draw threat card

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
            //game.GameOver;
        }
    }

    public void DirectDamage(int dmg)
    {
        hull -= dmg;

        if (hull <= 0)
        {
            //game.GameOver;
        }
    }

    public void NextTurn()
    {
        weaponsUsed = false;
        engineeringUsed = false;
    }
}
