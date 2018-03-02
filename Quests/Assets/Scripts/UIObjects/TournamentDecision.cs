using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestOTRT;

public class TournamentDecision : GameElement {
    
    public int skipped;
    public int joined;
    public Button joinBtn;
    public Button skipBtn;
    List<GameObject> players;

    void Start()
    {
        skipped = 0;
        joined = 0;
        players = new List<GameObject>();
    }

    public void join()
    {
        joined += 1;
        if(game.state == Game.gameState.TourDecision)
        {
            players.Insert(players.Count, game.current);
            joinBtn.interactable = false;
            skipBtn.interactable = false;
            game.state = Game.gameState.NextTour;
        }
        if (joined+skipped == game.numPlayers)
        {
            doneChoices();
        }
    }

    public void skip()
    {
        if (game.state == Game.gameState.TourDecision)
        {
            joinBtn.interactable = false;
            skipBtn.interactable = false;
            game.state = Game.gameState.NextTour;
        }
        skipped += 1;
        if (joined+skipped == game.numPlayers)
        {
            doneChoices();
        }
    }

    public void doneChoices()
    {
        Debug.Log(joined);
        if (joined == 0)
        {
            game.turn.noTournament();
        }
        else if (joined == 1)
        {
            game.turn.OneTournament(players[0], 1);
        }
        else
        {
            game.turn.StartTournament(players);
        }
    }

    public void reset()
    {
        skipped = 0;
        joined = 0;
        enableBtns();
    }

    public void init()
    {
        skipped = 0;
        joined = 0;
        enableBtns();
        game.numActive = 0;
        game.activePlayers.Clear();
    }

    public void enableBtns()
    {
        joinBtn.interactable = true;
        skipBtn.interactable = true;
    }
}
