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

    public void showSponsorship(int cardIndex)
    {
        sponsorship.Init(cardIndex);
    }
}
