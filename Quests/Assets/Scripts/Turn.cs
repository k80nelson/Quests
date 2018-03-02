using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class Turn : GameElement
    {
        public void init()
        {
            switch (game.state)
            {
                case (Game.gameState.Sponsorship):
                    break;
                case (Game.gameState.Tournament):
                    break;
                case (Game.gameState.Event):
                    break;
                default: break;
            }
        }
    }
}




/*
public class Turn : GameElement {
    public GameObject SponsorPrefab;
    public GameObject CombatPrefab;
    public GameObject BiddingPrefab;

    public GameObject SponsorOverlay;
    public GameObject CombatOverlay;


    public List<Card> cards;
    public GameObject overlay;

    public void init()
    {
        if (game.state == Game.gameState.Sponsorship)
        {
            SponsorOverlay.SetActive(true);
        }

        if (game.state == Game.gameState.Quest || game.state == Game.gameState.Tournament)
        {
            overlay.SetActive(true);
        }

    }

    public void startSponsor()
    {
        GameObject temp = Instantiate(SponsorPrefab);
        temp.transform.parent = game.current.transform.parent.transform;
        SponsorOverlay.SetActive(false);
    }

    public void noSponsor()
    {
        this.game.nextPlayer();
        this.game.state = Game.gameState.startTurn;
        GameObject.Destroy(GameObject.FindGameObjectWithTag("CurrStory"));
        SponsorOverlay.SetActive(false);
    }

    void Start()
    {
        cards = new List<Card>();
    }

    public void addCard(Card card)
    {
        cards.Add(card);
    }

    public void removeClicked()
    {
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

    public void removeAll()
    {
        cards.Clear();

        removeClicked();

        if (!(game.state == Game.gameState.Quest || game.state == Game.gameState.Quest))
        {
            overlay.SetActive(false);
        }

        if(!(game.state == Game.gameState.Sponsorship))
        {
            SponsorOverlay.SetActive(false);
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
        foreach(Card card in cards)
        {
            game.current.GetComponent<PlayerController>().removeCard(card as AdventureCard);
        }
        removeAll();
        this.game.nextPlayer();
    }


}
*/
