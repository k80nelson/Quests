using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour {

    public GameObject JoinSponsor;
    public GameObject Sponsor;
    public GameObject JoinQuest;
    public GameObject quest;
    public GameObject JoinTournament;
    public GameObject Tournament;
    public GameObject PlayerOverlay;
    public GameObject Menu;
    public Text PlayerOverlayText;

    void unSetMainGame()
    {
        gameObject.tag = "Untagged";
    }

    void setMainGame()
    {
        gameObject.tag = "Game";
    }

    public void toggleMenu()
    {
        Menu.SetActive(!Menu.activeInHierarchy);
    }

    public void LoadJoinSponsor()
    {
        JoinSponsor.SetActive(true);
    }

    public void LoadJoinTournament()
    {
        JoinTournament.SetActive(true);
    }

    public void LoadJoinQuest()
    {

        JoinQuest.SetActive(true);
    }

    public Quest LoadQuest()
    {
        quest.SetActive(true);
        return quest.GetComponent<Quest>();
    }

    public void LoadSponsor()
    {
        unSetMainGame();
        Sponsor.SetActive(true);
        Sponsor.tag = "Game";
    }

    public void EndSponsor()
    {
        setMainGame();
        Sponsor.tag = "Untagged";
        Sponsor.SetActive(false);
    }

    public void EndJoinSponsor()
    {
        JoinSponsor.SetActive(false);
    }

    public void EndJoinTournament()
    {
        JoinTournament.SetActive(false);
    }

    public void EndJoinQuest()
    {
        JoinQuest.SetActive(false);
    }

    public void ShowPlayerOverlay(int player)
    {
        PlayerOverlayText.text = "Waiting on Player " + (player) + "... ";
        PlayerOverlay.SetActive(true);
    }

}
