using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour {

    #region Singleton

    public static GameSceneManager instance;

    #endregion

    // ---- ATTRIBUTES ----

    [SerializeField] JoinController joinPrompt;
    [SerializeField] SponsorController sponsorship;
    [SerializeField] QuestController quest;
    [SerializeField] TournamentController tour;

    // ---- INITIALIZATION ----

    private void Awake()
    {
        instance = this;
    }

    // ---- Scene Switching ----

    public void showJoinSponsor(int cardIndex)
    {
        joinPrompt.Init(PlayType.SPONSOR, GameManager.instance.dict.findCard(cardIndex).image);
    }

    public void showJoinTour(int cardIndex)
    {
        joinPrompt.Init(PlayType.TOURNAMENT, GameManager.instance.dict.findCard(cardIndex).image);
    }

    public void showJoinQuest(int cardIndex)
    {
        joinPrompt.Init(PlayType.QUEST, GameManager.instance.dict.findCard(cardIndex).image);
    }

    public void showQuest(int cardIndex)
    {
        quest.Init(cardIndex);
    }

    public void showTour(int cardIndex)
    {
        tour.Init(cardIndex);
    }

    public void startTourTie()
    {
        tour.setTie();
    }

    public void tourWin()
    {
        tour.win();
    }
    public void tourFail()
    {
        tour.fail();
    }

    public void setStageBid(int minBid)
    {
        quest.startBid(minBid);
    }

    public void winBid()
    {
        quest.winBid();
    }

    public void EndQuest()
    {
        quest.end();
        SponsorHandler.instance.SendServerEndQuest();
    }

    public void failQuest()
    {
        quest.fail();
    }

    public void startQuestStage(int stageIndex)
    {
        Debug.Log("Gamestate startin");
        quest.startStage(stageIndex);
    }

    public void showSponsorship(int cardIndex)
    {
        sponsorship.Init(cardIndex);
    }
    
}
