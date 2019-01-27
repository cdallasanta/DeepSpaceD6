using System.Collections;
using System.Collections.Generic;
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
        deck.DrawCard();
    }

    public void Step5()
    {
        threatDiceSprite.enabled = true;
        threatDice.RollDice();
        //TODO resolve threats
    }

    public void Step6()
    {
        CheckForWin();

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
        }
    }

    public void GameOver()
    {
        EditorUtility.DisplayDialog("Game Over", "You blew up! Oh no!", "Shoot dang!", "Yeah, I saw that coming.");
    }

    private void GameWon()
    {
        EditorUtility.DisplayDialog("You won!", "You defeated all the things! Way to go!", "You know I did!", "Ain't no thang.");
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

    private void CheckForLoss()
    {
        if (GameObject.Find("External Threats").GetComponentsInChildren<Dice>().Length == 0)
        {
            GameOver();
        }
    }
}
