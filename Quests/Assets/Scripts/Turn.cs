using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class Turn : GameElement {
    public List<Card> cards;
    public GameObject overlay;

    void Start()
    {
        cards = new List<Card>();
    }

    public void addCard(Card card)
    {
        cards.Add(card);
    }

    public void init()
    {
        if (game.state == Game.gameState.Quest || game.state == Game.gameState.Quest)
        {
            overlay.SetActive(true);
        }
            
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

        if (!(game.state == Game.gameState.Quest || game.state == Game.gameState.Quest))
        {
            overlay.SetActive(false);
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

    public void playCards()
    {
        Debug.Log("Played cards.");
        foreach(Card card in cards)
        {
            game.current.GetComponent<PlayerController>().removeCard(card as AdventureCard);
            Debug.Log("Removing" + card.Name);
        }
        removeAll();
    }
}
