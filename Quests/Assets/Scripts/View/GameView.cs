using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour {

    public GameObject Game;
    public GameObject JoinSponsor;
    public GameObject Sponsor;
    public GameObject JoinQuest;
    public GameObject quest;
    public GameObject JoinTournament;
    public GameObject Tournament;
    public GameObject PlayerOverlay;
    public GameObject Menu;
    public Text PlayerOverlayText;

    public GameObject prompt;
    public Text promptText;


    public void promptUser(string message)
    {
        promptText.text = message;
        prompt.SetActive(true);
    }

    void unSetMainGame()
    {
        Debug.Log("HERE");
        Game.tag = "Game";
    }

    void setMainGame()
    {
        Game.tag = "ActiveArea";
    }

    public void toggleMenu()
    {
        Menu.SetActive(!Menu.activeInHierarchy);
    }

    public void LoadJoinSponsor()
    {
        unSetMainGame();
        JoinSponsor.SetActive(true);
        JoinSponsor.tag = "ActiveArea";
    }

    public void LoadJoinTournament()
    {
        unSetMainGame();
        JoinTournament.SetActive(true);
        JoinTournament.tag = "ActiveArea";
    }

    public void LoadJoinQuest()
    {
        unSetMainGame();
        JoinQuest.SetActive(true);
        JoinQuest.tag = "ActiveArea";
    }

    public void LoadQuest()
    {
        Debug.Log("ALMOST");
        unSetMainGame();
        quest.SetActive(true);
        quest.tag = "ActiveArea";
    }

    public void LoadSponsor()
    {
        unSetMainGame();
        Sponsor.SetActive(true);
        Sponsor.tag = "ActiveArea";
    }

    public void removeSponsor()
    {
        quest.GetComponent<QuestController>().destroySponsor();
    }

    public void EndSponsor()
    {
        setMainGame();
        Sponsor.tag = "Untagged";
        Sponsor.SetActive(false);
    }

    public void EndJoinSponsor()
    {
        setMainGame();
        JoinSponsor.tag = "Untagged";
        JoinSponsor.SetActive(false);
    }

    public void EndJoinTournament()
    {
        setMainGame();
        JoinTournament.tag = "Untagged";
        JoinTournament.SetActive(false);
    }

    public void EndJoinQuest()
    {
        setMainGame();
        JoinQuest.tag = "Untagged";
        JoinQuest.SetActive(false);
    }

    public void EndQuest()
    {
        setMainGame();
        quest.tag = "Untagged";
        quest.SetActive(false);
    }

    public void ShowPlayerOverlay(int player)
    {
        PlayerOverlayText.text = "Waiting on Player " + (player) + "... ";
        PlayerOverlay.SetActive(true);
    }

}
