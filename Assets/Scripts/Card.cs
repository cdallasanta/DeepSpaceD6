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

    private void Start()
    {
        
    }

    public virtual void OnActivation() { }

    public virtual void OnDestruction() { }

    private void OnMouseDown()
    {
        if (ship.game.currentStage == 4 &&
            ship.selectedDice != null &&
            alternateCost.Count > 0 &&
            alternateCost.Contains(ship.selectedDice.face))
        {
            alternateCost.Remove(ship.selectedDice.face);

            ship.selectedDice.MoveArea(this.name);
            ship.selectedDice.spriteR.color = Color.white;
            ship.selectedDice = null;
            
            if (alternateCost.Count == 0)
            {
                Dice[] diceHere = GetComponentsInChildren<Dice>();
                foreach(Dice dice in diceHere)
                {
                    dice.MoveArea("Returned Area");
                }

                DestroySelf();
            }
        }
    }

    public void ReduceHealth()
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

        ship.game.CheckForWin();
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
