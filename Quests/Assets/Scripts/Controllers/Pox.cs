using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS EVENT STILL NEEDS A LOT OF WORK BEFORE IT IS DONE

namespace QuestOTRT
{
    //All other players lose one shield(if possible), drawer of this card is exempt
    public class Pox : GameElement
    {
        void Start()
        {
            play();
        }

        void play()
        {
            //Get a reference to the current player, remove two shields from them
            for (int i = 0; i < players.Length; ++i)
            {
                //if the player is the one who drew the card then he doesnt lose a sheild
                if (players[i] == p)
                {
                    continue;
                }
                //all other players lose one shield
                else
                {
                    players[i].removeShields(1);
                }
            }

        }
    }
}