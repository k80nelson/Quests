using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestOTRT;

public class TournamentDecision : GameElement {
    
    int skipped;
    int joined;
    public Button joinBtn;
    public Button skipBtn;

    void Start()
    {
        skipped = 0;
        joined = 0;
    }

    public void join()
    {
        joined += 1;
        if(game.state == Game.gameState.TourDecision)
        {
            game.activePlayers.Enqueue(game.current);
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
        if (joined == 0) game.turn.noTournament();
        else game.turn.StartTournament(joined);
    }

    public void reset()
    {
        skipped = 0;
        joined = 0;
        enableBtns();
    }

    public void enableBtns()
    {
        joinBtn.interactable = true;
        skipBtn.interactable = true;
    }
}
