using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class PlayerController : NetworkBehaviour
{
    public PlayerView view;
    public PlayerModel model;
    public Transform cardTransform;

    private void Start()
    {
        view = gameObject.GetComponent<PlayerView>();
        model = gameObject.GetComponent<PlayerModel>();
        this.gameObject.transform.SetParent(GameObject.Find("Gameplay").transform);
        view.changeName("P" + (model.index+1));
    }

    private void Update()
    {
        view.updateRank(((PlayerModel.Rank)(model.rank)).ToString());
        view.updateShields(model.shields);
        view.updateCards(model.numCards);
    }

    public void addCard(GameObject card)
    {
        GameObject newCard = Instantiate(card, cardTransform);
        newCard.name = card.name;
        model.addCard(newCard);
        Debug.Log("[PlayerController.cs:addCard] " + card.name + " added to player " + (model.index + 1));
    }

    public List<GameObject> getAllies()
    {
        return view.getAllies();
    }

    public void discardCard(GameObject card)
    {
        model.removeCard(card.GetComponent<AdventureCard>());
        Debug.Log("[PlayerController.cs:removeCard] " + card.name + " removed from player " + (model.index + 1));
        Destroy(card);
    }

    public void removeCard(AdventureCard card)
    {
        model.removeCard(card);
        Debug.Log("[PlayerController.cs:removeCard] " + card.name + " removed from player " + (model.index + 1));
    }

    public void hideCard(GameObject card)
    {
        view.hideCard(card);
        Debug.Log("[PlayerController.cs:hideCard] " + card.name + " hidden in player " + (model.index + 1));
    }

    public void saveHiddenAllies()
    {
        view.saveHiddenAllies();
    }

    public void clearHiddenCards()
    {
        view.clearHiddenCards();
    }

    public List<Transform> getHiddenCards()
    {
        return view.getHiddenCards();
    }

    public void removeCards(List<AdventureCard> cards)
    {
        if (cards == null) return;
        Debug.Log("[PlayerController:removeCards] Removing " + cards.Count + " cards from player " + (model.index + 1));
        foreach (AdventureCard card in cards) removeCard(card);
    }

    public void AddAlly(GameObject card)
    {
        view.saveAlly(card);
        model.addAlly(card.GetComponent<AdventureCard>());
    }

    public void AddAllies(List<GameObject> cards)
    {
        foreach (GameObject card in cards)
        {
            AddAlly(card);
        }
    }

    public void returnCards(List<Transform> cards)
    {

    }

    public void addManyCards(List<GameObject> cards)
    {
        if (cards == null) return;

        Debug.Log("[PlayerController:addManyCards] Adding " + cards.Count + " cards to player " + (model.index + 1));
        foreach (GameObject prefab in cards)
        {
            addCard(prefab);
        }
    }
}
