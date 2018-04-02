using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : GameElement
{
    public Transform cardArea;
    public QuestModel currQuest;
    public QuestController controller;
    
    public CombatView view;

    int counter;

   
    public void initiate()
    {
        Debug.Log("[CombatController.cs:OnEnable] Initializing Combat");
        view.setEncounterText(currQuest.currStageId + 1);
        counter = 0;
    }

    public bool validate(AdventureCard card)
    {
        if (currQuest.players[currQuest.activePlayer].overMax())
        {
            game.view.promptUser("You are holding too many cards.");
            return false;
        }

        if (card.type == AdventureCard.Type.FOE || card.type == AdventureCard.Type.TEST) return false;

        List<AdventureCard> cardsPlayed = new List<AdventureCard>(cardArea.GetComponentsInChildren<AdventureCard>());
        if (card.type == AdventureCard.Type.AMOUR)
        {
            if (currQuest.players[currQuest.activePlayer].cardsPlayed4Quest.containsAmour()) return false;
            if (cardsPlayed.Find(i => i.type == AdventureCard.Type.AMOUR) != null) return false;
        }

        if (card.type == AdventureCard.Type.WEAPON)
        {

            if (cardsPlayed.Find(i => i.Name == card.Name) != null) return false;
        }

        return true;
    }

    public void playCards()
    {
        List<AdventureCard> cardsPlayed = new List<AdventureCard>(cardArea.GetComponentsInChildren<AdventureCard>());
        PlayerController currPlayerCtrl = game.players[game.activePlayer].GetComponent<PlayerController>();

        // hide each card in the player
        foreach (AdventureCard card in cardsPlayed)
        {
            currPlayerCtrl.hideCard(card.gameObject);
        }
        game.players[game.activePlayer].GetComponent<PlayerModel>().cardsPlayed4Quest.addList(cardsPlayed);
        currPlayerCtrl.removeCards(cardsPlayed);

        counter += 1;
        if (counter >= currQuest.numPlayers)
        {
            findPassingPlayers();
        }
        else controller.nextPlayer();
    }

    bool compareBP(StageModel sponsor, PlayerModel player)
    {
        int playerBP = player.getBP() + player.cardsPlayed4Quest.totalBP() + player.calculateAllyBP();
        if (playerBP >= sponsor.totalBP()) return true;
        return false;
    }

    void findPassingPlayers()
    {
        List<PlayerModel> models = new List<PlayerModel>(currQuest.players);
        foreach (PlayerModel player in models)
        {
            PlayerController ctrl = player.GetComponent<PlayerController>();
            Debug.Log(currQuest.currStage);
            Debug.Log(player);
            if (compareBP(currQuest.currStage, player))
            {
                Debug.Log("[CombatController.cs:findPassingPlayers] player " + (player.index + 1) + " passed stage " + (currQuest.currStageId + 1));
                player.cardsPlayed4Quest.discardWeapons();
            }
            else
            {
                Debug.Log("[CombatController.cs:findPassingPlayers] player " + (player.index + 1) + " failed stage " + (currQuest.currStageId + 1));
                game.view.promptUser("Player " + (player.index + 1) + " has failed stage " + (currQuest.currStageId + 1));
                currQuest.removePlayer(player);
                player.cardsPlayed4Quest.discardWeaponsNAmours();
                player.cardsPlayed4Quest.Empty();
            }
            ctrl.saveHiddenAllies();
            ctrl.clearHiddenCards();
        }

        if (currQuest.numPlayers == 0) controller.endFail();
        else controller.nextStage();
    }
}
