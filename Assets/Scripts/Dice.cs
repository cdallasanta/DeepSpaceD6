using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Sprite[] allSides = new Sprite[6];
    private string face;
    public Ship ship;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
        face = gameObject.GetComponent<SpriteRenderer>().sprite.name;
    }

    void OnMouseDown()
    {
        if (ship.game.currentStage == 3)
        {
            ship.selectedDice = this;
        }
    }

    public void LockScanner()
    {
        if (Face() == "scanners")
        {
            MoveArea("Scanners");
        }
    }

    public void MoveArea(string newArea)
    {
        Transform newParent = GameObject.Find(newArea).transform;
        gameObject.transform.SetParent(newParent, false);
    }

    /* these methods are for the threat cards
    public void TestMoveUp()
    {
        Transform newParent = GameObject.Find("4 Health").transform;
        gameObject.transform.SetParent(newParent, false);
        parent = gameObject.transform.parent.gameObject;
    }

    public void TestMoveDown()
    {
        Transform newParent = GameObject.Find("3 Health").transform;
        gameObject.transform.SetParent(newParent, false);
        parent = gameObject.transform.parent.gameObject;
    }
    */
}
