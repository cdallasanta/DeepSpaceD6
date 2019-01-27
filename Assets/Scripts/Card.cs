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
    public string[] alternateCost;
    public bool disabled;

    private void Start()
    {
        disabled = false;
        ship = GameObject.Find("Ship").GetComponent<Ship>();
    }

    public virtual void OnActivation() { }

    public virtual void OnDestruction() { }

    public virtual void AlternateDestruction()
    {
        DestroySelf();
    }

    public void ReduceHealth()
    {
        currentHP -= 1;

        if (currentHP <= 0)
        {
            DestroySelf();
        }

        PlaceOnBoard();
    }

    public void DestroySelf()
    {
        OnDestruction();
        enabled = false;
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
