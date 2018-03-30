using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quest : GameElement
{
   
    public Transform StoryCardTransform;
    public QuestCard currQuest;
    public Transform cardArea;

    private List<int> playerIds;
    private List<PlayerModel> players;
    private int activePlayer;
    private int numPlayers;
    private int counter;

    int numStages;
    public SetupModel sponsorship;
    public Transform[] stageObjects;
    
    public enum stageType { FOE, TEST };
    public stageType currStageType;
    int currStageId;
    public StageModel currStage;
    public Text encounterText;

    public GameObject prompt;
    public Text promptMessage;

    private void OnEnable()
    {
        Debug.Log("[Quest.cs:OnEnable] Initializing Quest");
        currQuest = StoryCardTransform.GetComponentInChildren<QuestCard>();
        players = new List<PlayerModel>();
        numStages = currQuest.stages;
        activePlayer = -1;
        currStageId = -1;
    }

    public void addStages(SetupModel sponsorCards)
    {
        Debug.Log("[Quest.cs:addStages] Adding sponsored cards to Quest");
        sponsorship = sponsorCards;
    }
    
    public void addPlayers(List<int> players)
    {
        Debug.Log("[Quest.cs:addPlayers] Adding joined players to Quest");
        this.playerIds = players;
        this.numPlayers = players.Count;
    }

    public void startQuest()
    {
        setUpPlayers();
        giveAdventureCards();
        setNextStage();
        setNextPlayer();
        Debug.Log("[Quest.cs:startQuest] Initialization complete");
    }

    private void setUpPlayers()
    {
        Debug.Log("[Quest.cs:setUpPlayers] Preparing players for quest");
        foreach(int i in playerIds)
        {
            PlayerModel tmp = game.players[i].GetComponent<PlayerModel>();
            tmp.cardsPlayed4Quest.Empty();
            players.Add(tmp);
        }
    }

    public void setNextStage()
    {
        Debug.Log("[Quest.cs:setNextStage] Initializing stage " + (currStageId + 2));
        currStageId += 1;
        if (currStageId >= numStages) end();
        currStage = sponsorship.getStage(currStageId);
        if (currStage.containsFoe())
        {
            Debug.Log("[Quest.cs:setNextStage] Stage " + (currStageId + 1)+" contains a Foe");
            currStageType = stageType.FOE;
            encounterText.text = "A Foe is encountered!";
        }
        else
        {
            Debug.Log("[Quest.cs:setNextStage] Stage " + (currStageId + 1) + " contains a Test");
            currStageType = stageType.TEST;
            encounterText.text = "A Test is encountered!";
        }
    }

    private void giveAdventureCards()
    {
        foreach(int player in playerIds)
        {
            game.addCardsToPlayer(player, 1);
        }

        Debug.Log("[Quest.cs:giveAdventureCards] added 1 adventure card to each player in Quest");
    }

    private void setNextPlayer()
    {
        activePlayer = (activePlayer + 1) % numPlayers;
        Debug.Log("[Quest.cs:setNextPlayer] Setting active player to player " + (playerIds[activePlayer] + 1));
        game.setActivePlayer(playerIds[activePlayer]);
    }

    //Will clear the players Stage variable and move their allies to the variable in the player class
    //ONLY TO BE USED UPON QUESTS COMPLETION
    public void clearPlayers()
    {
        Debug.Log("[Quest.cs:clearPlayers] Clearing players cards for end of Quest");
        for (int i = 0; i < players.Count; i++)
        {
            players[i].cardsPlayed4Quest.Empty();
        }
    }
    

    //Returns true for passing the stage, false for failing the stage
    public bool compareBP(StageModel sponsor, StageModel player)
    {
        if (player.totalBP() >= sponsor.totalBP()) return true;
        return false;
    }

    public bool validateCard(AdventureCard card)
    {

        if (players[activePlayer].overMax())
        {
            promptUser("You are holding too many cards.");
            return false;
        }

        if (card.type == AdventureCard.Type.FOE || card.type == AdventureCard.Type.TEST) return false;

        if (card.type == AdventureCard.Type.AMOUR && players[activePlayer].cardsPlayed4Quest.containsAmour()) return false;
        
        if (card.type == AdventureCard.Type.WEAPON)
        {
            List<AdventureCard> cardsPlayed = new List<AdventureCard>(cardArea.GetComponentsInChildren<AdventureCard>());
            if (cardsPlayed.Find(i => i.Name == card.Name) != null) return false;
        }

        return true;
    }

    public void promptUser(string message)
    {
        promptMessage.text = message;
        prompt.SetActive(true);
    }
    
    public void playCards()
    {
        counter += 1;
        if (counter == numPlayers)
        {
            endStage();
        }
        PlayerController currPlayerCtrl = players[activePlayer].GetComponent<PlayerController>();
        List<AdventureCard> cardsPlayed = new List<AdventureCard>(cardArea.GetComponentsInChildren<AdventureCard>());

        Debug.Log("[Quest.cs:playCards] Player " + (game.activePlayer + 1) + " played " + cardsPlayed.Count + " cards in stage " + (currStageId + 1));

        foreach (AdventureCard card in cardsPlayed)
        {
            currPlayerCtrl.hideCard(card.gameObject);
        }
        players[activePlayer].cardsPlayed4Quest.addList(cardsPlayed);
        players[activePlayer].addAllies(cardsPlayed.FindAll(i => i.type == AdventureCard.Type.ALLY));
        currPlayerCtrl.removeCards(cardsPlayed);
        setNextPlayer();
    }

    public void endStage()
    {
        Debug.Log("[Quest.cs:endStage] Stage " + (currStageId + 1) + " complete");
    }

    public void end()
    {
        Debug.Log("[Quest.cs:end] Quest Completed");
        game.view.EndQuest();
    }
    
}
