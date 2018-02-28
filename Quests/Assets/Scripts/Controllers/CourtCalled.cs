using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    //All Allies in play are discarded
    public class CourtCalled : GameElement
    {
        void Start()
        {
            play();
        }

        void play()
        {
            //Creates a new list of players to be filled 
            List<Player> players = new List<Player>();

            //Loops through each game object 
            foreach (GameObject player in this.game.players)
            {
                players.Add(player.GetComponent<PlayerController>().player);
            }

           
            //loops through all allies and find their allies
            for (int i = 0; i < players.Count; ++i)
            {
                players[i].removeAllies();
            }

        }
    }
}