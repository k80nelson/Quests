﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : GameElement {

    public QuestModel model;
    public QuestView view;
    public Transform[] stages;

    public CombatController combat;
    public BiddingController bidding;

    /* On Enable - called every time a quest is initialized */
    private void OnEnable()
    {
        Debug.Log("[QuestController.cs:OnEnable] Initializing Quest");
        model.initialize();
    }

    public void startQuest(List<int> players)
    {
        model.addPlayers(players); 
        nextStage();
    }

    public void nextStage()
    {
        model.nextStage();
        if (model.currStageId >= model.numStages)
        {
            // end successfully
        }
        if(model.numPlayers == 0)
        {
            // end fail
        }
        model.giveAdventureCards();
        if (model.currStageType == QuestModel.stageType.COMBAT)
        {
            Debug.Log("[QuestController.cs:nextStage] Initializing stage " + (model.currStageId + 1) + " with combat");
            initializeCombat();
        }
        else
        {
            Debug.Log("[QuestController.cs:nextStage] Initializing stage " + (model.currStageId + 1) + " with bidding");
            initializeTest();
        }
        nextPlayer();
    }

    void initializeCombat()
    {
        // also ends up calling the CombatController.OnEnable() function
        view.showCombat();
    }

    void initializeTest()
    {
        // also ends up calling the BiddingController.OnEnable() function
        view.showTest();
        bidding.giveCard(stages[model.currStageId].GetChild(0));
    }

    public void nextPlayer()
    {
        if (model.numPlayers == 0) { } // end fail
        model.nextActivePlayer();
        if (model.currStageType == QuestModel.stageType.TEST && bidding.testWin()) endBid();
        else
        {
            game.setActivePlayer(model.playerIds[model.activePlayer]);
            view.showCards();
            // restore the cards to the card area if you're in a test
            if (model.currStageType == QuestModel.stageType.TEST) bidding.restoreCards();
        }
    }

    void endBid()
    {
        PlayerController ctrl = model.players[model.activePlayer].GetComponent<PlayerController>();
        List<Transform> cards = ctrl.getHiddenCards();
        foreach (Transform card in cards)
        {
            ctrl.discardCard(card.gameObject);
        }
        nextStage();
    }

    public void endFail()
    {
        Debug.Log("[Quest.cs:endFail] All players have failed the Quest");
        game.view.promptUser("All players have failed the Quest");
        end();
    }
    
    public void endSuccess()
    {
        Debug.Log("[Quest.cs:endSuccess] Quest completed successfully");

        foreach (PlayerModel player in model.players)
        {
            player.addShields(model.numStages);
            player.cardsPlayed4Quest.discardWeaponsNAmours();
            player.cardsPlayed4Quest.Empty();
        }
        end();
    }

    public void destroySponsor()
    {
        foreach (Transform obj in stages)
        {
            foreach (Transform child in obj)
            {
                Destroy(child.gameObject);
            }
        }
    }

    void end()
    {
        game.EndQuest(model.numStages, model.sponsorship.totalNumCards());
        model.discardSponsor();
        game.view.EndQuest();
    }
}
