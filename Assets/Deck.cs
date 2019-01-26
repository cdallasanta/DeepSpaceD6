using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Threat> cards = new List<Threat>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShuffleDeck()
    {

    }

    public void DrawCard()
    {

    }

    /*
    public void ActivateCard(card)
    {
        if (card.GetType().GetMethod("OnActivation") != null)
        {
            card.OnActivation();
        }
    }
    */
}
