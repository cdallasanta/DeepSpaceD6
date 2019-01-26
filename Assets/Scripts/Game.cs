using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Ship ship;
    private Dice[] allDice = new Dice[6];
    private Deck threatDeck;
    public int currentStage;
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
        threatDeck = GameObject.Find("Threat Deck").GetComponent<Deck>();
        currentStage = 0;
    }

    private void Step1()
    {
        Dice[] diceInHand = GameObject.Find("Hand Area").GetComponentsInChildren<Dice>();
        
        foreach (Dice dice in diceInHand)
        {
            dice.RollTheDice();
        }
    }

    private void Step2()
    {
        Dice[] diceInHand = GameObject.Find("Hand Area").GetComponentsInChildren<Dice>();

        foreach (Dice dice in diceInHand)
        {
            dice.LockScanner();
            ship.CheckScanners();
        }
    }

    private void Step4()
    {
        threatDeck.DrawCard();
    }

    private void Step5()
    {
        //roll threat die and resolve
    }

    private void Step6()
    {
        ReturnDice();
        //CheckForWin();
        //CheckForLoss();
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
    /*


class Game
  attr_accessor :all_dice, :ship, :game_areas, :all_dice, :threat_deck

  def collect_dice


  #turn order
    #roll dice - done
    #lock threats and resolve - need threat deck to becreated
    #assign crew - how am I doing this?
    #resolve stations
    #draw threat - need threat deck
    #roll threat dice and resolve
    #collect dice

  #check win
end
*/
}
