using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//obj: Player(s) with lowest rank and least amount of shields gains 3 shields
public class ChivalrousDeed : GameElement
{
    void Start()
    {
        play();
    }

    public void play()
    {
        //Creates a new list of players to be filled 
        List<PlayerModel> players = new List<PlayerModel>();

        //Loops through each game object and adds them to the list of players
        foreach (GameObject player in this.game.players)
        {
            players.Add(player.GetComponent<PlayerModel>());
        }

        //List of players that are currently the lowest
        List<PlayerModel> lowest = new List<PlayerModel>();

        //Automatically set the lowest player to the first player
        PlayerModel lowestPlayer = players[0];

        //Adds the first player in the list automatically
        lowest.Add(lowestPlayer);

        //find the lowest rank
        for (int cur = 1; cur < players.Count; ++cur)
        {

            //if rank is lower than the current lowest player
            if (players[cur].getRank() < lowestPlayer.getRank())
            {

                //set the new lowest player
                lowestPlayer = players[cur];

                //clear the list and re-add the newest lowest player
                lowest.Clear();
                lowest.Add(lowestPlayer);

            }
            else if (players[cur].getRank() == lowestPlayer.getRank())
            {

                //if the ranks are the same then you have to find out who has the lowest Rank
                if (players[cur].shields < lowestPlayer.shields)
                {

                    //replaces the lowest player with the one with lowest rank and shields
                    lowestPlayer = players[cur];

                    //clear the list and re-add the newest lowest player
                    lowest.Clear();
                    lowest.Add(lowestPlayer);
                }

                //If the shields are also the same then append them to the list 
                else if (players[cur].shields == lowestPlayer.shields)
                {
                    lowest.Add(players[cur]);
                }
            }
        }

        //adds 3 shields to the lowest player
        for (int i = 0; i < lowest.Count; i++)
        {
            lowest[i].addShields(3);
        }
    }
}
