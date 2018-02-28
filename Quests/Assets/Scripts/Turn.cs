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

        GameObject[] clicked = GameObject.FindGameObjectsWithTag("Clicked");
        foreach (GameObject card in clicked)
        {
            if (card.GetComponent<WeaponController>() != null)
            {
                card.GetComponent<WeaponController>().reset();
                continue;
            }
            if (card.GetComponent<FoeController>() != null)
            {
                card.GetComponent<FoeController>().reset();
                continue;
            }
            if (card.GetComponent<TestController>() != null)
            {
                card.GetComponent<TestController>().reset();
                continue;
            }
            if (card.GetComponent<AmourController>() != null)
            {
                card.GetComponent<AmourController>().reset();
                continue;
            }
            if (card.GetComponent<AllyController>() != null)
            {
                card.GetComponent<AllyController>().reset();
                continue;
            }
        }
    }

    public void removeCard(Card card)
    {
        cards.Remove(card);
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
