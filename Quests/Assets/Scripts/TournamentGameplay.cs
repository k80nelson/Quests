using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestOTRT;


public class TournamentGameplay : GameElement {

    Dictionary<GameObject, Move> moves;
    Button btn;
    int numMoves;
    bool firstRound;
    int joined;

	void Start ()
    {
        numMoves = 0;
        moves = new Dictionary<GameObject, Move>();
	}
	
	void Update ()
    {
		
	}

    int calcBP(GameObject player)
    {
        return player.GetComponent<PlayerController>().player.BP + moves[player].total;
    }

    void endTourn()
    {
        bool tie = false;
        List<GameObject> ties = new List<GameObject>();

        GameObject highest = game.current;
        int highBP = calcBP(highest);

        int curr = 0;
        foreach(GameObject player in moves.Keys)
        {
            curr = calcBP(player);
            if (curr > highBP)
            {
                tie = false;
                ties.Clear();
                highBP = curr;
                highest = player;
            }
            else if (curr == highBP)
            {
                tie = true;
                ties.Add(highest);
                ties.Add(player);
            }
        }
        if (tie)
        {
            Debug.Log("Tournament Tie");
            if (firstRound)
            {
                game.numActive = ties.Count;
                game.activePlayers.Clear();
                foreach (GameObject player in ties)
                {
                    moves[player].discardWeapons();
                    game.activePlayers.Enqueue(player);
                }
            }

            else
            {
                game.turn.EndTournament(ties, joined);
            }
        }
        else
        {
            game.turn.EndTournament(highest, joined);
        }
    }

    public void addMove()
    {
        numMoves += 1;
        Move tmp = game.current.GetComponent<PlayerController>().move;
        tmp.totalBP();
        moves[game.current] = tmp;
        btn.interactable = false;

        if (numMoves == game.numActive) endTourn();
    }

    public void enableBtn()
    {
        btn.interactable = true;
    }

    public void reset()
    {
        numMoves = 0;
        joined = game.numActive;
        firstRound = true;
        enableBtn();
        moves.Clear();
    }
}
