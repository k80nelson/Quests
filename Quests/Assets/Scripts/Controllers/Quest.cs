using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest : MonoBehaviour  
{
    int stages;
    public Transform StoryCardTransform;
    public QuestCard currQuest;
    public SetupModel sponsorship;

    public Transform[] stageObjects;


    private void OnEnable()
    {
        currQuest = StoryCardTransform.GetComponentInChildren<QuestCard>();
        stages = currQuest.stages;
    }

    public void addStages(SetupModel sponsorCards)
    {
        Debug.Log(stages + " stages were added to the Quest.");
        sponsorship = sponsorCards;
    }

    //Will clear the players Stage variable and move their allies to the variable in the player class
    //ONLY TO BE USED UPON QUESTS COMPLETION
    public void clearPlayers(PlayerModel[] players)
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].cardsPlayed4Quest.RemoveWeapons();
            //players[i].cardsPlayed4Quest.Remove(AdventureCard Amour); This will remove the amour card played if they played one
            players[i].addAllies(players[i].cardsPlayed4Quest.cardsPlayed); //At this point all that should be left in the list are allies
            players[i].cardsPlayed4Quest.Empty();
        }
    }

    //Returns true for passing the stage, false for failing the stage
    public bool compareBP(StageModel sponsor, StageModel player)
    {
        if (player.totalBP() >= sponsor.totalBP()) return true;
        return false;
    }


}
