using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS EVENT STILL NEEDS A LOT OF WORK BEFORE IT IS DONE

namespace QuestOTRT
{
    //Drawer loses 2 shields, if possible
    public class Plague : GameElement
    {
        void Start()
        {
            play();
        }

        public void play()
        {
            //Get a reference to the current player, remove two shields from them
            Player p = this.game.current.GetComponent<PlayerController>().player;
            p.removeShields(2);
            Debug.Log("plague");
        }
    }
}