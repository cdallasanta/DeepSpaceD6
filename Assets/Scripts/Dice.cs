using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Sprite[] allSides = new Sprite[6];
    public string face;
    public Ship ship;
    public SpriteRenderer spriteR;
    public int faceNum;
    public Minidice[] miniDice;
    public bool distracted;

    private void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        miniDice = gameObject.GetComponentsInChildren<Minidice>();
        distracted = false;
    }

    //this method is called by Game to roll each dice and set it's face value to the name of its face
    public void RollTheDice()
    {
        //set sprite to a random sprite
        faceNum = Random.Range(0, 6);
        spriteR.sprite = allSides[faceNum];

        //set face as it's current side so it can be called elsewhere
        face = spriteR.sprite.name;
    }

    public void SetMiniDice()
    {
        for(int i = 0; i < 4; i++)
        {
            int c = i + 1;
            miniDice[i].faceNum = faceNum + c;
            if (faceNum + c >= 5)
            {
                miniDice[i].faceNum -= 5;
            }

            miniDice[i].spriteR.sprite = miniDice[i].allSides[miniDice[i].faceNum];
        }
    }

    public void ShowMiniDice()
    {
        foreach(Minidice dice in miniDice)
        {
            dice.spriteR.enabled = true;
            dice.GetComponent<PolygonCollider2D>().enabled = true;
        }
    }

    public void HideMiniDice()
    {
        foreach (Minidice dice in miniDice)
        {
            dice.spriteR.enabled = false;
            dice.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    void OnMouseDown()
    {
        if (ship.game.currentStage == 4 && !ship.waitingForChoice && transform.parent.name == "Hand Area")
        {
            //checking if comms offline has disabled commander and the dice is a commander
            //or for panel explosion and engineer
            Debug.Log(ship.commanderDisabled);
            Debug.Log(spriteR.sprite.name);
            //Debug.Log(ship.engineeringDisabled && spriteR.name == "Engineer");
            if (!(ship.commanderDisabled && spriteR.sprite.name == "Commander") &&
                !(ship.engineeringDisabled && spriteR.sprite.name == "Engineering"))
            {
                if (ship.selectedDice != null)
                {
                    ship.selectedDice.spriteR.color = Color.white;
                }
                ship.selectedDice = this;
                spriteR.color = new Color(.55f, .74f, .22f, .5f);

                ChangeColor();
            }
        }
    }

    private void ChangeColor()
    {
        switch (face)
        {
            case "Commander":
                spriteR.color = new Color(.7f, .65f, .99f, 1f);
                break;
            case "Science":
                spriteR.color = new Color(.55f, .74f, .22f, .5f);
                break;
            case "Weapons":
                spriteR.color = new Color(.9f, .26f, .22f, .5f);
                break;
            case "Medic":
                spriteR.color = new Color(.5f, .23f, .5f, .5f);
                break;
            case "Engineering":
                spriteR.color = new Color(.95f, .55f, .17f, .5f);
                break;
        }
    }

    public void LockScanner()
    {
        if (face == "Scanners")
        {
            MoveArea("Scanners");
        }
    }

    public void MoveArea(string newArea)
    {
        Transform newParent = GameObject.Find(newArea).transform;
        gameObject.transform.SetParent(newParent, false);
    }

    public void MoveAreaByCardName(string card)
    {
        GameObject newArea = GameObject.Find(card);
        Transform newParent = newArea.transform.Find("Alternate Cost Dice").transform;
        gameObject.transform.SetParent(newParent, false);
    }
}
