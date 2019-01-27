using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Ship ship;
    private Dice[] allDice = new Dice[6];
    public Deck deck;
    public int currentStage;
    private ThreatDice threatDice;
    private SpriteRenderer threatDiceSprite;
    /* Stages:
     * 1. Roll Dice
     * 2. Lock Threats
     * 3. Assign Crew
     * 4. Draw Threat
     * 5. Roll Threat Dice
     * 6. Return Crew
     */

    // Start is called before the first frame update
    void Start()
    {
        ship = gameObject.GetComponentInChildren<Ship>();
        allDice = gameObject.GetComponentsInChildren<Dice>();
        deck = GameObject.Find("Threat Deck").GetComponent<Deck>();
        threatDice = GameObject.Find("Threat Dice").GetComponent<ThreatDice>();
        threatDiceSprite = GameObject.Find("Threat Dice").GetComponent<SpriteRenderer>();
        currentStage = 1;
    }

    public void Step1()
    {
        Dice[] diceInHand = GameObject.Find("Hand Area").GetComponentsInChildren<Dice>();
        
        foreach (Dice dice in diceInHand)
        {
            dice.RollTheDice();
        }
    }

    public void Step2()
    {
        Dice[] diceInHand = GameObject.Find("Hand Area").GetComponentsInChildren<Dice>();

        foreach (Dice dice in diceInHand)
        {
            dice.LockScanner();
            ship.CheckScanners();
        }
    }

    public void Step4()
    {
        deck.DrawCard();
    }

    public void Step5()
    {
        threatDiceSprite.enabled = true;
        threatDice.RollDice();
        //resolve
    }

    public void Step6()
    {
        CheckForWin();

        threatDiceSprite.enabled = false;
        ReturnDice();
        if(GameObject.Find("External Threats").GetComponentsInChildren<Dice>().Length == 0)
        {
            GameOver();
        }

        ship.NextTurn();
    }

    private void ReturnDice()
    {
        Dice[] diceInReturned = GameObject.Find("Returned Area").GetComponentsInChildren<Dice>();
        Dice[] diceOnThreats = GameObject.Find("External Threats").GetComponentsInChildren<Dice>();

        foreach(Dice dice in diceInReturned)
        {
            dice.MoveArea("Hand Area");
        }
        foreach (Dice dice in diceOnThreats)
        {
            dice.MoveArea("Hand Area");
        }
    }

    public void GameOver()
    {
        //TODO
    }

    private void GameWon()
    {
        //TODO
    }

    private void CheckForWin()
    {
        if(deck.cards.Count == 0 &&
            GameObject.Find("Internal Threats").GetComponentsInChildren<Card>().Length == 0 &&
            GameObject.Find("External Threats").GetComponentsInChildren<Card>().Length == 0)
        {
            GameWon();
        }

    }
}
