using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{

    public class ChangePlayer : GameElement
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void onClick()
        {
            this.game.current.GetComponent<PlayerController>().view.setViewOff();
            this.game.currIndex = ((this.game.currIndex + 1) % this.game.numPlayers);
            this.game.current = this.game.players[this.game.currIndex];
            this.game.current.GetComponent<PlayerController>().view.setViewOn();
            this.game.current.GetComponent<PlayerController>().view.adjustHand();
        }
    }
}