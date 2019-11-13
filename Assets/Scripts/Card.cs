using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string title;
    public string type;
    public int MAXHP;
    public int currentHP;
    public int[] activationNums;
    public Deck deck;
    public Ship ship;
    public List<string> alternateCost;
    public bool disabled;
    public SpriteRenderer spriteR;

    public virtual void WhenPlayed() { }

    public virtual void OnActivation() { }

    public virtual void OnDestruction() { }

    public virtual void OnMouseDown()
    {   /* 
         * check that the game is accepting player input
         * there is a selected dice,
         * and that the card accepts the dice as an alternate cost
         */
        if (ship.game.currentStage == 4 &&
            ship.selectedDice != null &&
            alternateCost.Count > 0 &&
            alternateCost.Contains(ship.selectedDice.face))
        {
            //checks for the case of Cosmic Existentialism in play, the dice is Science, and they are targeting something else
            //or Panel Explosion for engineering
            if (!(ship.selectedDice.face == "Science" && ship.cosmicExistentialismInPlay && GameObject.Find("Cosmic Existentialism").GetComponent<Card>() != this) ||
                !(ship.selectedDice.face == "Engineering" && GameObject.Find("Internal Threats").GetComponent<Card>() != null))
            {
                alternateCost.Remove(ship.selectedDice.face);
                ship.selectedDice.MoveAreaByCardName(this.name);
                ship.selectedDice.spriteR.color = Color.white;
                ship.selectedDice = null;

                AlternateCostCheck();
            }
        }
    }

    private void AlternateCostCheck()
    {
        if (alternateCost.Count == 0)
        {
            Dice[] diceHere = GetComponentsInChildren<Dice>();
            foreach (Dice dice in diceHere)
            {
                dice.MoveArea("Returned Area");
            }

            DestroySelf();
        }
    }

    public virtual void ReduceHealth()
    {
        currentHP -= 1;

        if (currentHP <= 0)
        {
            DestroySelf();
        } else
        {
            PlaceOnBoard();
        }
    }

    public void DestroySelf()
    {
        OnDestruction();
        GetComponent<SpriteRenderer>().enabled = false;
        
        Transform newParent = GameObject.Find("Graveyard").transform;
        gameObject.transform.SetParent(newParent, false);
    }

    public void HealByOne()
    {
        currentHP = Mathf.Min(MAXHP, currentHP + 1);
        PlaceOnBoard();
    }

    public void PlaceOnBoard()
    {
        if (type == "external")
        {
            Transform newParent = GameObject.Find($"{currentHP} Health").transform;
            gameObject.transform.SetParent(newParent, false);
        } else
        {
            Transform newParent = GameObject.Find("Internal Threats").transform;
            gameObject.transform.SetParent(newParent, false);
        }
    }
}
