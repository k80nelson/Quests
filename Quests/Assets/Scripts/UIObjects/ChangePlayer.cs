using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuestOTRT
{

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

        
            
            
            /*
            if (game.state == Game.gameState.Tournament || game.state == Game.gameState.Quest)
            {   
                game.activePlayers.Enqueue(game.current);
                game.tie = false;
                this.game.current = game.activePlayers.Dequeue() as GameObject;
                game.turn.checkWin();
            }
            else if (game.state == Game.gameState.StartEv)
            {
                //game.playerTurns.Enqueue(game.current);
                this.game.current = game.activePlayers.Dequeue() as GameObject;
                game.state = game.turn.store;
                game.turn.DisplayEvent();
            }
            else if (game.state == Game.gameState.EndEv)
            {
                this.game.current = game.playerTurns.Dequeue() as GameObject;
                game.state = Game.gameState.startTurn;
            }
            else if (game.state == Game.gameState.startTurn || game.state == Game.gameState.NextTour)
            {
                game.playerTurns.Enqueue(game.current);
                this.game.current = game.playerTurns.Dequeue() as GameObject;
            }*/


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
    }
}