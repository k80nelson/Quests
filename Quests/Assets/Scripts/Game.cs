using System;
using UnityEngine;

namespace QuestOTRT
{
    public class GameElement : MonoBehaviour
    {
        public Game game { get { return GameObject.FindObjectOfType<Game>(); } }
    }

    public class Game : MonoBehaviour
    {
        public int numPlayers;
        public int numControlled;
        public GameObject[] players;
        public DeckController deck;
        public enum gameState { startTurn, Quest, Sponsorship, Event, Tournament, endTurn};
        public gameState state;
        public Turn turn;

        //This will hold the current player
        public GameObject current;
        public int currIndex;

        void Start()
        {
            deck = GameObject.FindWithTag("Deck").GetComponent<DeckController>();
            //runs the init player method with players having a count of 4 in 4pGame
            initPlayers();
            state = gameState.startTurn;

            current = players[0];

            turn = GameObject.FindWithTag("Turn").GetComponent<Turn>();
            currIndex = 0;
            current = players[currIndex];
        }

        void Update()
        {
            
        }

        public void nextPlayer()
        {
            current.GetComponent<PlayerController>().view.setViewOff();
            currIndex = ((currIndex + 1) % numPlayers);
            current = players[currIndex];
            current.GetComponent<PlayerController>().view.setViewOn();
        }

        void initPlayers()
        {
            PlayerController ctrl;
            foreach (GameObject player in this.players)
            {
                ctrl = player.GetComponent<PlayerController>();
                ctrl.player.addCards(deck.DrawAdventureCards(12));
                ctrl.initCards();
            }
        }

        //Late Update runs whatever is inside it at the end of the loop, it updates last, so anythign that needs to be done at the end should be done here
        void LateUpdate()
        {
           // Debug.Log("Game Late Update");
        }
    }
}