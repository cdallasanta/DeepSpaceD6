using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{
    private Ship ship;
    private SpriteRenderer spriteR;
    private bool waitingForSubChoice;

    // Start is called before the first frame update
    void Start()
    {
        ship = gameObject.GetComponentInParent<Ship>();
        spriteR = GetComponent<SpriteRenderer>();
        waitingForSubChoice = false;
    }

    void OnMouseDown()
    {
        if (ship.game.currentStage == 4 &&
            ship.selectedDice != null &&
            ship.selectedDice.face == "Commander")
        {
            spriteR.color = new Color(.7f, .65f, .99f, 1f);
            ActivateCommander();
        }
    }


    private void ActivateCommander()
    {
        ship.selectedDice.MoveArea("Returned Area");
        ship.selectedDice.spriteR.color = Color.white;
        ship.selectedDice = null;

        Dice[] diceInHand = GameObject.Find("Hand Area").GetComponentsInChildren<Dice>();

        foreach (Dice dice in diceInHand)
        {
            dice.spriteR.color = new Color(.7f, .65f, .99f, 1f);
        }

        if (diceInHand.Length != 0)
        {
            StartCoroutine(CommanderChoice());
        }
        else
        {
            PostActivationCleanup();
        }
    }

    IEnumerator CommanderChoice()
    {
        ship.waitingForChoice = true;
        while (ship.waitingForChoice)
        {
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.transform.parent.name == "Hand Area")
                    {
                        Dice dice = hit.collider.gameObject.GetComponent<Dice>();
                        dice.SetMiniDice();
                        dice.ShowMiniDice();

                        yield return StartCoroutine(ChangeDice(dice));
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

    IEnumerator ChangeDice(Dice dice)
    {
        bool waitingForChoice = true;
        while (waitingForChoice)
        {
            if (Input.GetMouseButtonUp(0) && !waitingForSubChoice)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider.gameObject.transform.tag == "Minidice")
                {
                    Sprite newFace = hit.collider.gameObject.GetComponent<Minidice>().spriteR.sprite;
                    dice.spriteR.sprite = newFace;
                    dice.face = dice.spriteR.sprite.name;

                    waitingForChoice = false;
                    waitingForSubChoice = false;

                    dice.HideMiniDice();
                }
            }
            yield return null;
        }
    }

    private void PostActivationCleanup()
    {
        spriteR.color = Color.white;

        Dice[] diceInHand = GameObject.Find("Hand Area").GetComponentsInChildren<Dice>();

        foreach (Dice dice in diceInHand)
        {
            dice.spriteR.color = Color.white;
        }
    }
}
