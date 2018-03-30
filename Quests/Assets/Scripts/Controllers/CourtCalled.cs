using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All Allies in play are discarded
public class CourtCalled : GameElement
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

           
        //loops through all allies and find their allies
        for (int i = 0; i < players.Count; ++i)
        {
            players[i].removeAllies();
        }
    }
}
