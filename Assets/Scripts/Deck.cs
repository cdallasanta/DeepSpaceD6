using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(Card card in gameObject.GetComponentsInChildren<Card>())
        {
            cards.Add(card);
        }
        ShuffleDeck();
    }

    public void ShuffleDeck()
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
    }

    public void DrawCard()
    {
        if (cards.Count > 0)
        {
            Card cardToPlay = cards[cards.Count - 1];
            cards.Remove(cardToPlay);
            cardToPlay.PlaceOnBoard();
            cardToPlay.WhenPlayed();

            if (cards.Count == 0)
            {
                GameObject.Find("Card Back").GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
