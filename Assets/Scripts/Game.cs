using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Ship ship;
    private Dice[] allDice = new Dice[6];
    private GameObject threatDeck;
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
        threatDeck = GameObject.Find("Threat Deck");
        currentStage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            RollDice();
        }
    }

    private void RollDice()
    {
        Dice[] diceInHand = GameObject.Find("Hand Area").GetComponentsInChildren<Dice>();
        
        foreach (Dice dice in diceInHand)
        {
            dice.RollTheDice();
            dice.LockScanner();
            ship.CheckScanners();
        }
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
