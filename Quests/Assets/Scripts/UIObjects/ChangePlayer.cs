using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuestOTRT
{   /*
    public class ChangePlayer : GameElement
    {
        public Button btn;
        public Text text;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void deactivateCurrent()
        {
            this.game.current.GetComponent<PlayerController>().view.setViewOff();
        }
        

        void setUpTurn()
        {
            this.game.turn.next();
            this.game.current.GetComponent<PlayerController>().view.setViewOn();
            this.game.current.GetComponent<PlayerController>().view.adjustHand();
            if (game.state == Game.gameState.startTurn) btn.interactable = true;
        }
        
        public void onClick()
        { 
            deactivateCurrent();
            game.current = game.nextPlayer();
            game.setIndeces();
            text.text = "Waiting on " + game.current.name + "... ";
            setUpTurn();
        }
    }*/
}