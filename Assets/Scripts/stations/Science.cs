using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Science : MonoBehaviour
{
    private Ship ship;
    private SpriteRenderer spriteR;
    private SpriteRenderer scienceSprite;

    // Start is called before the first frame update
    void Start()
    {
        ship = gameObject.GetComponentInParent<Ship>();
        spriteR = GetComponent<SpriteRenderer>();
        scienceSprite = GameObject.Find("Shield Sprite").GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        //checking to make sure Cosmic Existentialism isn't in play
        if (ship.game.currentStage == 4 &&
            ship.selectedDice != null &&
            ship.selectedDice.face == "Science" &&
            GameObject.Find("Internal Threats").GetComponentInChildren<CosmicExistentialism>() == null)
        {
            spriteR.color = new Color(.55f, .74f, .22f, .5f);
            ActivateScience();
        }
    }


    private void ActivateScience()
    {
        Card[] externalThreats = GameObject.Find("External Threats").GetComponentsInChildren<Card>();

        foreach (Card card in externalThreats)
        {
            if (!card.disabled)
            {
                card.spriteR.color = new Color(.62f, .79f, .46f, 1f);
            }
        }

        Card[] internalThreats = GameObject.Find("Internal Threats").GetComponentsInChildren<Card>();

        foreach (Card card in internalThreats)
        {
            if (!card.disabled)
            {
                card.spriteR.color = new Color(.62f, .79f, .46f, 1f);
            }
        }

        scienceSprite.color = new Color(.62f, 1f, 0f);

        if (externalThreats.Length != 0 || internalThreats.Length != 0 || ship.shields < 4)
        {
            StartCoroutine(ScienceChoice());
        }
        else
        {
            PostActivationCleanup();
        }

        ship.selectedDice.MoveArea("Returned Area");
        ship.selectedDice.spriteR.color = Color.white;
        ship.selectedDice = null;
    }

    IEnumerator ScienceChoice()
    {
        ship.waitingForChoice = true;
        while (ship.waitingForChoice)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.transform.name == "Shield Sprite")
                    {
                        RefillShields();
                        ship.waitingForChoice = false;
                    }
                    else if (hit.collider.gameObject.GetComponent<Card>() != null)
                    {
                        Stasis(hit.collider.gameObject.GetComponent<Card>());
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
        scienceSprite.color = Color.white;

        Card[] allCards = GameObject.Find("Game").GetComponentsInChildren<Card>();
        foreach (Card card in allCards)
        {
            if (!card.disabled)
            {
                card.spriteR.color = Color.white;
            }
        }
    }

    private void RefillShields()
    {
        ship.RefillShields();
    }

    private void Stasis(Card target)
    {
        target.disabled = true;
        target.spriteR.color = new Color(.65f, .65f, 1f, 1f);
    }
}
