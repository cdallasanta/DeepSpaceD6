using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Sprite[] allSides = new Sprite[6];
    private string face;
    public Ship ship;
    public SpriteRenderer spriteR;

    private void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }

    //used by Game to access the face variable when locking in scanners
    public string Face()
    {
        return face;
    }

    //this method is called by Game to roll each dice and set it's face value to the name of its face
    public void RollTheDice()
    {
        //set sprite to a random sprite
        int rand = Random.Range(0, 6);
        gameObject.GetComponent<SpriteRenderer>().sprite = allSides[rand];

        //set face as it's current side so it can be called elsewhere
        face = spriteR.sprite.name;
    }

    void OnMouseDown()
    {
        if (ship.game.currentStage == 4)
        {
            if (ship.selectedDice != null)
            {
                ship.selectedDice.spriteR.color = Color.white;
            }
            ship.selectedDice = this;
            spriteR.color = new Color(.55f, .74f, .22f, .5f);
        }
    }

    public void LockScanner()
    {
        if (Face() == "Scanners")
        {
            MoveArea("Scanners");
        }
    }

    public void MoveArea(string newArea)
    {
        Transform newParent = GameObject.Find(newArea).transform;
        gameObject.transform.SetParent(newParent, false);
    }
}
