using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class Turn : GameElement {
    public List<Card> cards;

    void Start()
    {
        cards = new List<Card>();
    }

    public void addCard(Card card)
    {
        cards.Add(card);
    }

    public void removeAll()
    {
        cards.Clear();
    }

    public void ListAll()
    {
        string ls = "";
        foreach (Card card in cards)
        {
            ls += card.Name + ", ";
        }

        Debug.Log(ls);
    }
}
