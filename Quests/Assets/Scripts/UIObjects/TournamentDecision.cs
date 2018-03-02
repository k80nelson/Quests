using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class TournamentDecision : GameElement {

    List<PlayerController> players;
    int num;

    void Start()
    {
        players = new List<PlayerController>();
        num = 0;
    }

    public void join()
    {
        players.Add(game.current.GetComponent<PlayerController>());
    }

    public void skip()
    {
        num += 1;
        if (num == game.numPlayers)
        {
            num = 0;
            players.Clear();
            game.turn.noTournament();
        }
    }
}
