using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class SponsorQuestBtn : GameElement {

    private int numSkips;

    public void Start()
    {
        numSkips = 0;
    }

    public void sponsor()
    {
        numSkips = 0;
        game.turn.startSponsor();
    }

    public void skip()
    {
        numSkips += 1;
        Debug.Log(numSkips);
        if (numSkips == game.numPlayers)
        {
            game.turn.noSponsor();
            numSkips = 0;
        }
        game.nextPlayer();
    }
}
