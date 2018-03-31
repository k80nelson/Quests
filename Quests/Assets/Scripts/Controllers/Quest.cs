using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quest : GameElement
{

    public GameObject amourPrefab;
    
    public Transform StoryCardTransform;
    public QuestCard currQuest;
    public Transform cardArea;
    public GameObject combat;
    public GameObject bidding;
    public Transform testCard;
    public Transform inPlayTransform;

    //Test variables
    public Transform biddingCards;
    private int highestBid;

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
    public Text stageTextFoe;
    public Text stageTextTest;

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
        activePlayer = -1;
        Debug.Log("[Quest.cs:setNextStage] Initializing stage " + (currStageId + 2));
        currStageId += 1;
        if (currStageId >= numStages)
        {
            endSuccess();
            return;
        }
        currStage = sponsorship.getStage(currStageId);
        if (currStage.containsFoe())
        {
            counter = 0;
            bidding.SetActive(false);
            Debug.Log("[Quest.cs:setNextStage] Stage " + (currStageId + 1)+" contains a Foe");
            currStageType = stageType.FOE;
            stageTextFoe.text = "Stage " + (currStageId + 1);
            combat.SetActive(true);
        }
        else
        {
            combat.SetActive(false);
            Debug.Log("[Quest.cs:setNextStage] Stage " + (currStageId + 1) + " contains a Test");
            currStageType = stageType.TEST;
            stageTextTest.text = "Stage " + (currStageId + 1);
            stageObjects[currStageId].GetChild(0).SetParent(testCard);
            testCard.GetChild(0).localScale = new Vector3(1, 1, 1);
            testCard.GetChild(0).localPosition = new Vector3(1, 1, 1);
            highestBid = testCard.GetChild(0).GetComponent<AdventureCard>().getMinimumBid();
            bidding.SetActive(true);
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

        if (numPlayers == 0) endFail();
        activePlayer = (activePlayer + 1) % numPlayers;
        Debug.Log("[Quest.cs:setNextPlayer] Setting active player to player " + (playerIds[activePlayer] + 1) +" in stage " + (currStageId+1));
        game.setActivePlayer(playerIds[activePlayer]);

        string tmp = "";
        foreach (AdventureCard card in game.players[game.activePlayer].GetComponent<PlayerModel>().cardsPlayed4Quest.cardsPlayed)
        {
            tmp += card.Name;
        }

        Debug.Log("[QUEST NEXT PLAYER] Player " + (game.activePlayer + 1) + " HAS CARDS " + tmp);
        Debug.Log("CONTAINS AMOUR?: " + game.players[game.activePlayer].GetComponent<PlayerModel>().cardsPlayed4Quest.containsAmour());
        if (currStageType == stageType.FOE)
        {
            foreach (Transform child in inPlayTransform)
            {
                Destroy(child.gameObject);
            }
            List<GameObject> allies = game.players[game.activePlayer].GetComponent<PlayerController>().getAllies();
            foreach (GameObject ally in allies)
            {
                Debug.Log("[Quest.cs:setNextPlayer] Player "+ (playerIds[activePlayer]+1)+" has allie(s) in play");
                GameObject objtmp = Instantiate(ally, inPlayTransform);
                objtmp.GetComponent<Draggable>().draggable = false;
            }
            if (game.players[game.activePlayer].GetComponent<PlayerModel>().cardsPlayed4Quest.containsAmour())
            {
                Debug.Log("[Quest.cs:setNextPlayer] Player " + (playerIds[activePlayer] + 1) + " has amour in play");
                GameObject objtmp = Instantiate(amourPrefab, inPlayTransform);
                objtmp.GetComponent<Draggable>().draggable = false;
               
            } 
        }
        
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
    public bool compareBP(StageModel sponsor, PlayerModel player)
    {
        int playerBP = player.getBP() + player.cardsPlayed4Quest.totalBP();

        if (playerBP >= sponsor.totalBP()) return true;
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

        List<AdventureCard> cardsPlayed = new List<AdventureCard>(cardArea.GetComponentsInChildren<AdventureCard>());
        if (card.type == AdventureCard.Type.AMOUR)
        {
            if (players[activePlayer].cardsPlayed4Quest.containsAmour()) return false;
            if (cardsPlayed.Find(i => i.type == AdventureCard.Type.AMOUR) != null) return false;
        }
        
        if (card.type == AdventureCard.Type.WEAPON)
        {
            
            if (cardsPlayed.Find(i => i.Name == card.Name) != null) return false;
        }

        return true;
    }

    //Validity function for Test
    public bool biddingValidity(AdventureCard card)
    {
        if (players[activePlayer].overMax())
        {
            promptUser("You are holding too many cards.");
            return false;
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
        PlayerController currPlayerCtrl = players[activePlayer].GetComponent<PlayerController>();
        List<AdventureCard> cardsPlayed = new List<AdventureCard>(cardArea.GetComponentsInChildren<AdventureCard>());

        Debug.Log("[Quest.cs:playCards] Player " + (game.activePlayer + 1) + " played " + cardsPlayed.Count + " cards in stage " + (currStageId + 1));

        foreach (AdventureCard card in cardsPlayed)
        {
            currPlayerCtrl.hideCard(card.gameObject);
        }
        game.players[game.activePlayer].GetComponent<PlayerModel>().cardsPlayed4Quest.addList(cardsPlayed);
        currPlayerCtrl.removeCards(cardsPlayed);

        string tmp = "";
        foreach (AdventureCard card in game.players[game.activePlayer].GetComponent<PlayerModel>().cardsPlayed4Quest.cardsPlayed)
        {
            tmp += card.Name;
        }

        Debug.Log("[QUEST PLAY CARDS] Player " + (game.activePlayer + 1) + " HAS CARDS " + tmp);

        counter += 1;
        if (counter == numPlayers)
        {
            endCombat();

        }
        else setNextPlayer();
    }

    public void continueTest()
    {
        int currentBid = players[activePlayer].cardsPlayed4Quest.totalBids();

        foreach (AdventureCard card in players[game.activePlayer].cardsPlayed4Quest.cardsPlayed)
        {
            currentBid += card.getBids();
        }

        if (currentBid < highestBid)
        {
            promptUser("Not enough bids played. Current highest bid is " + highestBid + ". Your bid is " + currentBid + ".");
        }
        else
        {

        }
    }

    public void findPassingPlayers()
    {
        List<PlayerModel> models = new List<PlayerModel>(players);
        foreach(PlayerModel player in models)
        {
            PlayerController ctrl = player.GetComponent<PlayerController>();
            if (compareBP(currStage, player))
            {
                Debug.Log("[Quest.cs:findPassingPlayers] player " + (player.index + 1) + " passed stage " + (currStageId + 1));
                player.cardsPlayed4Quest.discardWeapons();
                string tmp = "";
                foreach (AdventureCard card in player.GetComponent<PlayerModel>().cardsPlayed4Quest.cardsPlayed)
                {
                    tmp += card.Name;
                }

                Debug.Log("[QUEST PASSING PLAYERS] Player " + (player.index + 1) + " HAS CARDS " + tmp);
            }
            else
            {
                Debug.Log("[Quest.cs:findPassingPlayers] player " + (player.index + 1) + " failed stage " + (currStageId + 1));
                promptUser("Player " + (player.index + 1) + " has failed stage " + (currStageId + 1));
                players.Remove(player);
                playerIds.Remove(player.index);
                numPlayers -= 1;
                player.cardsPlayed4Quest.discardWeaponsNAmours();
                player.cardsPlayed4Quest.Empty();
            }
            ctrl.saveHiddenAllies();
            ctrl.clearHiddenCards();
        }

        if (numPlayers == 0) endFail();
    }

    public void endCombat()
    {
        findPassingPlayers();
        setNextStage();
        if (currStageId < numStages)
        {
            giveAdventureCards();
            setNextPlayer();
        }
    }

    public void endStage()
    {
        Debug.Log("[Quest.cs:endStage] Stage " + (currStageId + 1) + " complete");
        
    }

    public void discardSponsor()
    {
        sponsorship.discardAll();
        foreach(Transform obj in stageObjects)
        {
            foreach(Transform child in obj)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void endFail()
    {
        Debug.Log("[Quest.cs:endFail] All players have failed the Quest");
        promptUser("All players have failed the Quest");
        end();
    }

    public void endSuccess()
    {
        Debug.Log("[Quest.cs:endSuccess] Quest completed successfully");

        foreach(PlayerModel player in players)
        {
            player.addShields(numStages);
            player.cardsPlayed4Quest.discardWeaponsNAmours();
            player.cardsPlayed4Quest.Empty();
        }
        end();
    }

    void end()
    {
        game.EndQuest(numStages, sponsorship.totalNumCards());
        discardSponsor();
        game.view.EndQuest();
    }

    

}


