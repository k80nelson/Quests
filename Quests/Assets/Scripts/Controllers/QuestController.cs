using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestController : MonoBehaviour
{
    private int sponsorBP;
    private int playerBP;

    public int currentStage;

    //Instantiate the elements to be used for quests later on, these will hold the cards the sponsor plays per stage
    public StageModel sponsorStage1 = new StageModel();
    public StageModel sponsorStage2 = new StageModel();
    public StageModel sponsorStage3 = new StageModel();
    public StageModel sponsorStage4 = new StageModel();
    public StageModel sponsorStage5 = new StageModel();

    //This will hold the stage models above when populated, these will be cleared and added to when needed
    public SetupModel sponsorSetup = new SetupModel();


    //Used to hold the cards the sponsor plays for a quest.
    //FIRST THING CALLED, CALLED REPEATEDLY UNTIL ALL STAGES OF CLASS ARE POPULATED
    public void sponsor(List<AdventureCard> stageLayout, int currentStage)
    {
        switch (currentStage)
        {
            case 0:
                sponsorStage1.addList(stageLayout);
                sponsorSetup.Add(sponsorStage1);
                break;
            case 1:
                sponsorStage2.addList(stageLayout);
                sponsorSetup.Add(sponsorStage2);
                break;
            case 2:
                sponsorStage3.addList(stageLayout);
                sponsorSetup.Add(sponsorStage3);
                break;
            case 3:
                sponsorStage4.addList(stageLayout);
                sponsorSetup.Add(sponsorStage4);
                break;
            case 4:
                sponsorStage5.addList(stageLayout);
                sponsorSetup.Add(sponsorStage5);
                break;
        }
    }

    //Adds the cards played by the player to their Stage variable
    //CALLED REPEATEDLY FOR EACH PLAYER FOR EACH STAGE
    public void stage(PlayerModel player, List<AdventureCard> stageLayout)
    {
        player.cardsPlayed4Quest.addList(stageLayout);
    }

    //Used to empty the lists at the end of a quest
    //ONLY TO BE USED UPON QUESTS COMPLETION
    public void clearSponsor()
    {
        sponsorSetup.Empty();
        sponsorStage1.Empty();
        sponsorStage2.Empty();
        sponsorStage3.Empty();
        sponsorStage4.Empty();
        sponsorStage5.Empty();
    }

    //Will clear the players Stage variable and move their allies to the variable in the player class
    //ONLY TO BE USED UPON QUESTS COMPLETION
    public void clearPlayers(PlayerModel[] players)
    {
        for(int i = 0; i<players.Length; i++)
        {
            players[i].cardsPlayed4Quest.RemoveWeapons();
            //players[i].cardsPlayed4Quest.Remove(AdventureCard Amour); This will remove the amour card played if they played one
            players[i].addAllies(players[i].cardsPlayed4Quest.cardsPlayed); //At this point all that should be left in the list are allies
            players[i].cardsPlayed4Quest.Empty();
        }
    }

    //Used to calculate the BP for the stage, youll pass it the appropriate list of cards. See stage model is passed and not setup model!
    public int calculateBP(StageModel player)
    {
        int BP = 0;

        for (int i = 0; i < player.Count; i++)
        {
            BP += player.cardsPlayed[i].getBP();
        }

        return BP;
    }

    //Returns true for passing the stage, false for failing the stage
    public bool compareBP(int sponsorBP, int playerBP)
    {
        if (playerBP >= sponsorBP) return true;
        return false;
    }

    //Will be the actual brain of the quest
    public void play(QuestCard quest, PlayerModel[] playersOnQuest)
    {

        //This is all garbage, the more i write the more i hate it, will all be changed
        int numStages = quest.stages;
        currentStage = 0;
        int playerIndex = 0;

        int numPlayers = playersOnQuest.Length;
        PlayerModel currentPlayer = playersOnQuest[playerIndex];
            

        for(int i = 0; i < numPlayers; ++i)
        {

        }


        //Used later to actually resolve each stage, garbage, will be changed
        sponsorBP = calculateBP(sponsorSetup.stageSetup[currentStage]);
        playerBP = calculateBP(currentPlayer.cardsPlayed4Quest);
        compareBP(sponsorBP, playerBP);
    }
}