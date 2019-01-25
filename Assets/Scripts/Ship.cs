using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int hull = 8;
    public int shields = 4;
    public int scannersMax = 3;
    private bool shieldsDisabled;
    private bool commanderDisabled;
    private GameObject scanners;
    public Game game;
    private bool weaponsUsed;
    private bool engineeringUsed;
    public Dice selectedDice;

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

    private void ActivateShields()
    {
        shields = 4;
    }

    private void ActivateStasis()
    {
        //select target
        //deactivate target
    }

    private void ActivateCommander()
    {
        //select dice
        //select new face
    }

    private void ActivateMedic()
    {
        Dice[] diceInInfirmary = GameObject.Find("Infirmary Area").GetComponentsInChildren<Dice>();

        foreach (Dice dice in diceInInfirmary)
        {
            dice.MoveArea("Returned Area");
        }
    }

    private void ActivateWeapons()
    {
        if (weaponsUsed)
        {
            DealDamage();
            DealDamage();
        } else
        {
            DealDamage();
        }
    }

    private void DealDamage()
    {
        //select target card
        //reduce health by one
    }

    private void ActivateEngineering()
    {
        if (engineeringUsed)
        {
            hull += 2;
        }
        else
        {
            hull += 1;
        }

        if (hull > 8)
        {
            hull = 8;
        }
    }

    private void ReduceScannersByOne()
    {
        Dice dice = GameObject.Find("Scanners").GetComponentInChildren<Dice>();
        dice.MoveArea("Returned Area");
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
