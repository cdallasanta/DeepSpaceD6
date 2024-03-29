﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic : MonoBehaviour
{
    private Ship ship;
    private SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        ship = gameObject.GetComponentInParent<Ship>();
        spriteR = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (ship.game.currentStage == 4 &&
            ship.selectedDice != null &&
            ship.selectedDice.face == "Medic")
        {
            spriteR.color = new Color(.5f, .23f, .5f, .5f);
            ActivateMedic();
        }
    }


    private void ActivateMedic()
    {
        Dice[] diceInInfirmary = GameObject.Find("Infirmary Area").GetComponentsInChildren<Dice>();

        foreach (Dice dice in diceInInfirmary)
        {
            dice.spriteR.color = new Color(.5f, .23f, .5f, .5f);
        }

        Dice[] diceInScanners = GameObject.Find("Scanners").GetComponentsInChildren<Dice>();

        foreach (Dice dice in diceInScanners)
        {
            dice.spriteR.color = new Color(.5f, .23f, .5f, .5f);
        }
        
        if(diceInScanners.Length != 0 || diceInInfirmary.Length != 0)
        {
            StartCoroutine(MedicChoice());
        }
        else
        {
            PostActivationCleanup();
        }

        ship.selectedDice.MoveArea("Returned Area");
        ship.selectedDice.spriteR.color = Color.white;
        ship.selectedDice = null;
    }

    IEnumerator MedicChoice()
    {
        ship.waitingForChoice = true;
        while (ship.waitingForChoice)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.transform.parent.name == "Scanners")
                    {
                        ReduceScannersByOne();
                        ship.waitingForChoice = false;
                    } else if (hit.collider.gameObject.transform.parent.name == "Infirmary Area")
                    {
                        EmptyInfirmary();
                        ship.waitingForChoice = false;
                    }
                }
            }
            if (!ship.waitingForChoice)
            {
                PostActivationCleanup();
            }

            yield return null;
        }
    }

    private void PostActivationCleanup()
    {
        spriteR.color = Color.white;
        
        Dice[] allDice = GameObject.Find("Game").GetComponentsInChildren<Dice>();
        foreach (Dice dice in allDice)
        {
            dice.spriteR.color = Color.white;
        }
    }

    private void EmptyInfirmary()
    {
        Dice[] diceInInfirmary = GameObject.Find("Infirmary Area").GetComponentsInChildren<Dice>();

        foreach (Dice dice in diceInInfirmary)
        {
            dice.MoveArea("Returned Area");
        }
    }

    private void ReduceScannersByOne()
    {
        Dice[] dice = GameObject.Find("Scanners").GetComponentsInChildren<Dice>();
        dice[0].MoveArea("Returned Area");
    }
}
