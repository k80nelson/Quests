using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestModel : GameElement
{
    public QuestController controller;
    public QuestCard currQuest;

    public List<int> playerIds;
    public List<PlayerModel> players;
    public int activePlayer;
    public int numPlayers;
    public int numStages;
    public SetupModel sponsorship;
    
    public enum stageType { COMBAT, TEST };
    public stageType currStageType;
    public int currStageId;
    public StageModel currStage;

    public void initialize()
    {
        findCurrentQuest();
        players = new List<PlayerModel>();
        numStages = currQuest.stages;
        activePlayer = -1;
        currStageId = -1;
        controller = gameObject.GetComponent<QuestController>();
    }

    /* finds by the currStory tag */
    void findCurrentQuest()
    {
        currQuest = GameObject.FindGameObjectWithTag("CurrStory").GetComponent<QuestCard>();
        Debug.Log("[QuestController.cs:findCurrentQuest] Current quest is " + currQuest.Name);
    }

    /* adds the players & populates our playerModel array */
    public void addPlayers(List<int> players)
    {
        playerIds = players;
        numPlayers = players.Count;
        initializePlayers();
    }

    /* populates the plyerModel array & empties the cardsPlayed4Quest player object */
    void initializePlayers()
    {
        Debug.Log("[QuestModel.cs:initializePlayers] Preparing players for quest");
        foreach (int i in playerIds)
        {
            PlayerModel tmp = game.players[i].GetComponent<PlayerModel>();
            tmp.cardsPlayed4Quest.Empty();
            players.Add(tmp);
        }
    }

    /* gives each player in the quest 1 adventure card*/
    public void giveAdventureCards()
    {
        foreach (int player in playerIds)
        {
            game.addCardsToPlayer(player, 1);
        }

        Debug.Log("[Quest.cs:giveAdventureCards] added 1 adventure card to each player in Quest");
    }

    /* initializes all the data needed */
    public void nextStage()
    {
        activePlayer = -1;
        currStageId += 1;
        if (currStageId < numStages)
        {
            currStage = sponsorship.getStage(currStageId);
            currStageType = (currStage.isCombat()) ? stageType.COMBAT : stageType.TEST;
        }
    }

    public void nextActivePlayer()
    {
        activePlayer = (activePlayer + 1) % numPlayers;
    }

    public void removePlayer(PlayerModel player)
    {
        players.Remove(player);
        playerIds.Remove(player.index);
        player.addAllies(player.cardsPlayed4Quest.cardsPlayed);
        player.cardsPlayed4Quest.discardWeaponsNAmours();
        numPlayers -= 1;
    }

    public void discardSponsor()
    {
        if (sponsorship != null) sponsorship.discardAll();
    }

}
