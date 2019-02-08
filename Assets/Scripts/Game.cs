using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class Game : MonoBehaviour
{
    private Ship ship;
    private Dice[] allDice = new Dice[6];
    public Deck deck;
    public int currentStage;
    private ThreatDice threatDice;
    private SpriteRenderer threatDiceSprite;

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
        if(ship.selectedDice != null)
        {
            ship.selectedDice.spriteR.color = Color.white;
            ship.selectedDice = null;
        }
        deck.DrawCard();
    }

    public void Step5()
    {
        threatDiceSprite.enabled = true;
        threatDice.RollDice();

        //testing
        int diceNum = threatDice.face;

        Card[] externalCards = GameObject.Find("External Threats").GetComponentsInChildren<Card>();
        foreach (Card card in externalCards)
        {
            if (Array.Exists(card.activationNums, num => num == diceNum) && !card.disabled)
            {
                card.spriteR.color = new Color(.9f, .25f, .22f);
            }
        }

        Card[] internalCards = GameObject.Find("Internal Threats").GetComponentsInChildren<Card>();
        foreach (Card card in internalCards)
        {
            if (Array.Exists(card.activationNums, num => num == diceNum) && !card.disabled)
            {
                card.spriteR.color = new Color(.9f, .25f, .22f);
            }
        }
    }

    public void Step6()
    {
        //this bit of math is in case the scouting ship is in play, which deals 1 damage if damage has happened this round
        int shipInitialHealth = ship.hull + ship.shields;

        ResolveThreats(threatDice.face);
        CheckForWin();

        if(shipInitialHealth > (ship.hull + ship.shields) && GameObject.Find("External Threats").GetComponentInChildren<ScoutingShip>() != null)
        {
            ship.DamageHull(1);
        }
    }

    public void Step7()
    {
        ReturnDice();
        CheckForLoss();

        ship.NextTurn();
        threatDiceSprite.enabled = false;
        ResetStasis();
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

    private void ResetStasis()
    {
        Card[] cardsOnField = GameObject.Find("Game").GetComponentsInChildren<Card>();
        foreach(Card card in cardsOnField)
        {
            card.disabled = false;
            card.spriteR.color = Color.white;
        }
    }

    public void GameOver()
    {
        EditorUtility.DisplayDialog("Game Over", "You blew up! Oh no!", "Shoot dang!", "Bummer.");
    }

    private void GameWon()
    {
        EditorUtility.DisplayDialog("You won!", "You defeated all the things! Way to go!", "You know I did!", "Ain't no thang.");
    }

    public void CheckForWin()
    {
        if (deck.cards.Count == 0 &&
            GameObject.Find("Internal Threats").GetComponentsInChildren<Card>().Length == 0 &&
            GameObject.Find("External Threats").GetComponentsInChildren<Card>().Length == 0)
        {
            GameWon();
        }

    }

    public void CheckForLoss()
    {
        if (GameObject.Find("Hand Area").GetComponentsInChildren<Dice>().Length == 0)
        {
            GameOver();
        }
        if (ship.hull <= 0)
        {
            GameOver();
        }
    }

    public void ResolveThreats(int diceNum)
    {
        bool threatActivated = false;
        Card[] externalCards = GameObject.Find("External Threats").GetComponentsInChildren<Card>();
        foreach(Card card in externalCards)
        {
            if(Array.Exists(card.activationNums, num => num == diceNum) && !card.disabled)
            {
                Debug.Log(card.spriteR.sprite.name);
                threatActivated = true;
                card.OnActivation();
            }
        }

        Card[] internalCards = GameObject.Find("Internal Threats").GetComponentsInChildren<Card>();
        foreach (Card card in internalCards)
        {
            if (Array.Exists(card.activationNums, num => num == diceNum) && !card.disabled)
            {
                Debug.Log(card.spriteR.sprite.name);
                threatActivated = true;
                card.OnActivation();
            }
        }

        //this is for if the mercenary is in play. If no threats were activated, deal damage
        if(!threatActivated && GameObject.Find("External Threats").GetComponentInChildren<Mercenary>() != null)
        {
            ship.DamageHull(2);
        }
    }
}
