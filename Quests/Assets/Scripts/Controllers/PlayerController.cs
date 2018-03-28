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
    }

    public void discardCard(GameObject card)
    {
        model.removeCard(card.GetComponent<AdventureCard>());
        Destroy(card);
    }

    public void removeCard(AdventureCard card)
    {
        model.removeCard(card);
    }

    public void removeCards(List<AdventureCard> cards)
    {
        foreach (AdventureCard card in cards) removeCard(card);
    }

    public void addManyCards(List<GameObject> cards)
    {
        foreach(GameObject prefab in cards)
        {
            addCard(prefab);
        }
    }
}
