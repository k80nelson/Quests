using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public PlayerView view;
    public PlayerModel model;
    public Transform cardTransform;

    private void Start()
    {
        view = gameObject.GetComponent<PlayerView>();
        model = gameObject.GetComponent<PlayerModel>();
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

    public void discardCard(GameObject card)
    {
        model.removeCard(card.GetComponent<AdventureCard>());
        Debug.Log("[PlayerController.cs:removeCard] " + card.name + " discarded from player " + (model.index + 1));
        Destroy(card);
    }

    public void removeCard(AdventureCard card)
    {
        model.removeCard(card);
        Debug.Log("[PlayerController.cs:removeCard] " + card.name + " discarded from player " + (model.index + 1));
    }

    public void hideCard(GameObject card)
    {
        view.holdCard(card);
        Debug.Log("[PlayerController.cs:hideCard] " + card.name + " hidden in player " + (model.index + 1));
    }

    public void removeCards(List<AdventureCard> cards)
    {
        if (cards == null) return;
        Debug.Log("[PlayerController:removeCards] Removing " + cards.Count + " cards from player " + (model.index + 1));
        foreach (AdventureCard card in cards) removeCard(card);
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
