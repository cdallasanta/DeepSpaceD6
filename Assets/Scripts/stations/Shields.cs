using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    private Ship ship;
    private SpriteRenderer spriteR;
    private SpriteRenderer shieldsSprite;

    // Start is called before the first frame update
    void Start()
    {
        ship = gameObject.GetComponentInParent<Ship>();
        spriteR = GetComponent<SpriteRenderer>();
        shieldsSprite = GameObject.Find("Shield Sprite").GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (ship.game.currentStage == 4 &&
            ship.selectedDice != null &&
            ship.selectedDice.Face() == "Shields")
        {
            spriteR.color = new Color(.55f, .74f, .22f, .5f);
            ActivateShields();
        }
    }


    private void ActivateShields()
    {
        Card[] externalThreats = GameObject.Find("External Threats").GetComponentsInChildren<Card>();

        foreach (Card card in externalThreats)
        {
            card.spriteR.color = new Color(.55f, .74f, .22f, .5f);
        }

        Card[] internalThreats = GameObject.Find("Internal Threats").GetComponentsInChildren<Card>();

        foreach (Card card in internalThreats)
        {
            card.spriteR.color = new Color(.55f, .74f, .22f, .5f);
        }

        shieldsSprite.color = new Color(.62f, 1f, 0f);

        if (externalThreats.Length != 0 || internalThreats.Length != 0 || ship.shields < 4)
        {
            StartCoroutine(ShieldsChoice());
        }
        else
        {
            PostActivationCleanup();
        }
    }

    IEnumerator ShieldsChoice()
    {
        bool waitingForChoice = true;
        while (waitingForChoice)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.transform.name == "Shield Sprite")
                    {
                        RefillShields();
                        waitingForChoice = false;
                    }
                    else if (hit.collider.gameObject.GetComponent<Card>() != null)
                    {
                        Stasis(hit.collider.gameObject.GetComponent<Card>());
                        waitingForChoice = false;
                    }
                }
            }
            if (!waitingForChoice)
            {
                PostActivationCleanup();
            }

            yield return null;
        }
    }

    private void PostActivationCleanup()
    {
        spriteR.color = Color.white;
        shieldsSprite.color = Color.white;

        Card[] allCards = GameObject.Find("Game").GetComponentsInChildren<Card>();
        foreach (Card card in allCards)
        {
            if (!card.disabled)
            {
                card.spriteR.color = Color.white;
            }
        }
        //TODO, something's wrong here
        ship.selectedDice.MoveArea("Returned Area");
        ship.selectedDice.spriteR.color = Color.white;
        ship.selectedDice = null;
    }

    private void RefillShields()
    {
        ship.RefillShields();
    }

    private void Stasis(Card target)
    {
        target.disabled = true;
    }
}
