using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestOTRT;


public class TournamentGameplay : GameElement {

    Dictionary<GameObject, Move> moves;
    public Button btn;
    int numMoves;
    bool firstRound;
    int joined;

	void Start ()
    {
        numMoves = 0;
        moves = new Dictionary<GameObject, Move>();
        firstRound = true;
	}
	
	void Update ()
    {
		
	}

    int calcBP(GameObject player)
    {
        Debug.Log(player.name + " BP: " + player.GetComponent<PlayerController>().player.BP);
        Debug.Log(player.name + " Added: " + moves[player].total);
        Debug.Log(player.name + " Total: " + (player.GetComponent<PlayerController>().player.BP + moves[player].total));
        return player.GetComponent<PlayerController>().player.BP + moves[player].total;
    }

    void endTourn()
    {
        bool tie = false;
        List<GameObject> ties = new List<GameObject>();

        GameObject highest = game.current;
        int highBP = -2;

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
            else if (player.name != highest.name && curr == highBP)
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
                firstRound = false;
                game.numActive = ties.Count;
                numMoves = 0;
                game.activePlayers = ties;
                foreach (GameObject player in ties)
                {
                    moves[player].discardWeapons();
                }
                game.tie = true;
            }
            else
            {
                foreach (GameObject player in moves.Keys)
                {
                    player.GetComponent<PlayerController>().playMove(moves[player].move);
                }
                game.turn.EndTournament(ties, joined);
            }
        }
        else
        {
            foreach(GameObject player in moves.Keys)
            {
                player.GetComponent<PlayerController>().playMove(moves[player].move);
            }
            game.turn.EndTournament(highest, game.numActive);
        }
    }

    public void addMove()
    {
        numMoves += 1;
        Move tmp = game.current.GetComponent<Move>();
        tmp.totalBP();
        moves[game.current] = tmp;
        btn.interactable = false;
    }

    public void enableBtn()
    {
        btn.interactable = true;
    }

    public void checkWin()
    {
        if (numMoves == game.numActive) endTourn();
    }

    public void init()
    {
        numMoves = 0;
        joined = game.numActive;
        firstRound = true;
        enableBtn();
        moves = new Dictionary<GameObject, Move>();
    }

    public void reset()
    {
        numMoves = 0;
        joined = game.numActive;
        firstRound = true;
        enableBtn();
        moves = new Dictionary<GameObject, Move>(); 
    }
}
