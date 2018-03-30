using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour {

    public Text nameText;
    public Text rankText;
    public Text shieldText;
    public Text cardsText;
    public GameObject highlight;

    public GameObject cardView;
    public Transform cardStorage;
    

    public void changeName(string name)
    {
        if (nameText != null) nameText.text = name;
    }

    public void updateRank(string rank)
    {
        if (rankText != null) rankText.text = "Rank:  " + rank;
    }

    public void updateShields(int shields)
    {
        if (shieldText != null) shieldText.text = "Shields:  " + shields;
    }

    public void updateCards(int cards)
    {
        if (cardsText != null) cardsText.text = "Cards:  " + cards;
    }

    public void holdCard(GameObject card)
    {
        card.transform.SetParent(cardStorage);
    }

    public void turnOn()
    {
        cardView.SetActive(true);
        highlight.SetActive(true);
    }

    public void turnOff()
    {
        cardView.SetActive(false);
        highlight.SetActive(false);
    }
}
