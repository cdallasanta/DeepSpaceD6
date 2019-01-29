using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    private Ship ship;
    private GameObject target;
    private SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        ship = gameObject.GetComponentInParent<Ship>();
        target = null;

        spriteR = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if(ship.game.currentStage == 4 &&
            ship.selectedDice != null &&
            ship.selectedDice.Face() == "Weapons")
        {
            ActivateWeapons();
        }
        
        ship.selectedDice.MoveArea("Returned Area");
        ship.selectedDice.spriteR.color = Color.white;
        ship.selectedDice = null;
    }

    private void ActivateWeapons()
    {
        spriteR.color = new Color(.9f, .26f, .22f, .5f);
        if (ship.weaponsUsed)
        {
            StartCoroutine(DealDamage(2));
        }
        else
        {
            StartCoroutine(DealDamage(1));
            ship.weaponsUsed = true;
        }
    }

    private void PostActivationCleanup()
    {
        spriteR.color = Color.white;
    }

    private IEnumerator DealDamage(int times)
    {
        while (times > 0 && 
            GameObject.Find("External Threats").GetComponentInChildren<Card>() != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Card" &&
                        hit.collider.gameObject.GetComponent<Card>().type == "external")
                    {
                        target = hit.collider.gameObject;
                    }
                }

                if (target != null)
                {
                    Card targetCard = target.GetComponent<Card>();

                    targetCard.ReduceHealth();
                    target = null;
                    times--;
                }
            }
            yield return null;
        }
        if (times == 0 || GameObject.Find("External Threats").GetComponentInChildren<Card>() == null)
        {
            PostActivationCleanup();
        }
    }
}
