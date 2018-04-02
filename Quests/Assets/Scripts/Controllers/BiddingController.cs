using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiddingController : GameElement {

    public Transform cardArea;
    public QuestModel currQuest;
    public QuestController controller;

    public BiddingModel model;
    public BiddingView view;

    void OnEnable()
    {
        Debug.Log("[BiddingController.cs:OnEnable] Initializing Bidding");
        
        view.setEncounterText(currQuest.currStageId + 1);
        
    }

    public void giveCard(Transform card)
    {
        int minBid = card.GetComponent<AdventureCard>().getMinimumBid();
        view.setEncounterCard(card);
        model.initialize(currQuest.numPlayers, minBid);
    }

    public bool testWin()
    {
        return (currQuest.playerIds[currQuest.activePlayer] == model.highestPlayer);
    }

    public void restoreCards()
    {
        List<Transform> hiddenCards = game.players[game.activePlayer].GetComponent<PlayerController>().getHiddenCards();
        for (int i = 0; i < hiddenCards.Count; i++)
        {
            hiddenCards[i].SetParent(cardArea);
        }
    }

    public bool validate()
    {
        if (currQuest.players[currQuest.activePlayer].overMax())
        {
            game.view.promptUser("You are holding too many cards.");
            return false;
        }

        return true;
    }

    public void bid()
    {
        PlayerController currPlayerCtrl = currQuest.players[currQuest.activePlayer].GetComponent<PlayerController>();
        List<AdventureCard> cardsPlayed = new List<AdventureCard>(cardArea.GetComponentsInChildren<AdventureCard>());
        int currentBid = currQuest.players[currQuest.activePlayer].cardsPlayed4Quest.totalBids();
        
        foreach (AdventureCard card in cardsPlayed)
        {
            currentBid += 1;
        }

        if (currentBid <= model.highestBid)
        {
            game.view.promptUser("Not enough bids played. Current highest bid is " + model.highestBid + ". Your bid is " + currentBid + ".");
        }
        else
        {
            Debug.Log("[BiddingController.cs:bid] Player " + (game.activePlayer + 1) + " played " + cardsPlayed.Count + " cards in stage " + (currStageId + 1));

            foreach (AdventureCard card in cardsPlayed)
            {
                currPlayerCtrl.hideCard(card.gameObject);
            }

            model.highestPlayer = currQuest.playerIds[currQuest.activePlayer];
            model.highestBid = currentBid;

            currPlayerCtrl.removeCards(cardsPlayed);

            controller.nextPlayer();
        }
    }

    public void dropOut()
    {
        PlayerController currPlayerCtrl = currQuest.players[currQuest.activePlayer].GetComponent<PlayerController>();
        PlayerModel player = currQuest.players[currQuest.activePlayer];
        PlayerView view = currQuest.players[currQuest.activePlayer].GetComponent<PlayerView>();


        Debug.Log("[Quest.cs:dropOut] Player " + (game.activePlayer + 1) + " has dropped out of the Test");
        game.view.promptUser("Player " + (game.activePlayer + 1) + " has dropped out at stage " + (currQuest.currStageId + 1));

        if (currQuest.activePlayer > 0) currQuest.activePlayer -= 1;
        currQuest.removePlayer(player);


        foreach (Transform card in view.cardStorage)
        {
            player.addCard(card.gameObject);
        }
        controller.nextPlayer();
    }


}
