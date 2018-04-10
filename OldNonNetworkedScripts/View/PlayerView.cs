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
    public Transform allyStorage;
    public Transform playersCards;
    

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

    public void hideCard(GameObject card)
    {
        card.transform.SetParent(cardStorage);
    }

    public void restoreHiddenCards()
    {
        foreach(Transform child in cardStorage)
        {
            child.SetParent(playersCards);
        }
    }

    public void saveHiddenAllies()
    {
        List<AdventureCard> cards = new List<AdventureCard>(cardStorage.GetComponentsInChildren<AdventureCard>()).FindAll(i => i.type == AdventureCard.Type.ALLY);
        foreach(AdventureCard card in cards)
        {
            card.gameObject.transform.SetParent(allyStorage);
        }
    }
    
    public void clearHiddenCards()
    {
        foreach(Transform child in cardStorage)
        {
            Destroy(child.gameObject);
        }
    }

    public List<Transform> getHiddenCards()
    {
        List<Transform> hide = new List<Transform>();
        foreach (Transform child in cardStorage)
        {
            hide.Add(child);
        }
        return hide;
    }

    public void saveAlly(GameObject card)
    {
        card.transform.SetParent(allyStorage);
    }


    public List<GameObject> getAllies()
    {
        List<GameObject> ret = new List<GameObject>();
        foreach(Transform child in allyStorage)
        {
            ret.Add(child.gameObject);
        }
        return ret;
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
