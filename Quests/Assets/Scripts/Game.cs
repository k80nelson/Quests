using System;
using System.Collections;
using System.Collections.Generic;
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
        public int numActive;
        public GameObject[] players;
        public Queue activePlayers;
        public Queue playerTurns;
        public DeckController deck;
        public enum gameState { startTurn, Quest, Sponsorship, Event, TourDecision, NextTour, StartEv, EndEv, Tournament, endTurn, Discard};
        public gameState state;
        public Turn turn;
        

        //This will hold the current player
        public GameObject current;

        void Start()
        {
            deck = GameObject.FindWithTag("Deck").GetComponent<DeckController>();

            //runs the init player method with players having a count of 4 in 4pGame


            //Finds preffered # of AI and Humans
            //Globals globals = GameObject.FindObjectOfType<Globals>();
            //numPlayers = globals.numPlayers;
            //numControlled = globals.numStrongAi + globals.numWeakAi; 

            initPlayers();
            state = gameState.startTurn;
            turn = GameObject.FindWithTag("Turn").GetComponent<Turn>();
            playerTurns = new Queue(players);
            current = playerTurns.Dequeue() as GameObject;
            activePlayers = new Queue();
        }

        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                state = Game.gameState.endTurn;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(current.name);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("Tournament state");
                activePlayers = new Queue();
                activePlayers.Enqueue(players[1]);
                activePlayers.Enqueue(players[2]);
                activePlayers.Enqueue(players[3]);
                GameObject peek = (GameObject)activePlayers.Peek();
                Debug.Log(peek.name);
                state = Game.gameState.StartEv;
                turn.store = Game.gameState.Tournament;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Event Test: sets player 2 and player 4 to different rank.");
                Debug.Log("Current card Drawer is: "+ current.name);
                PlayerController p1 = players[1].GetComponent<PlayerController>();
                PlayerController p2 = players[3].GetComponent<PlayerController>();
                p1.addShields(15);
                p2.addShields(5);
                p1.upgradeRank();
                p2.upgradeRank();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                ChivalrousDeed a = new ChivalrousDeed();
                Debug.Log("Player(s) with lowest rank and least amount of shields gains 3 shields");
                a.play();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                QueensFavor b = new QueensFavor();
                Debug.Log("Lowest ranked player(s) immediately recieve 2 Adventure Cards");
                b.play();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                CourtCalled c = new CourtCalled();
                Debug.Log("All Allies in play are discarded");
                c.play();
                Debug.Log("Currently Not implemented");
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                KingRecognition d = new KingRecognition();
                Debug.Log("Kings Recognition not yet implemented...");
                Debug.Log("Highest ranked player(s) must place 1 weapon in the discard");
                d.play();
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                KingsCall e = new KingsCall();
                Debug.Log("Highest ranked player(s) must place 1 weapon in the discard. If unable to do so, 2 foe cards must be discarded");
                e.play();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                Plague f = new Plague();
                Debug.Log("Drawer loses 2 shields, if possible");
                f.play();
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                Pox g = new Pox();
                Debug.Log("All other players lose one shield (if possible), drawer of this card is exempt");
                g.play();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                ProsperityTtR h = new ProsperityTtR();
                Debug.Log("All players can immediately draw 2 Adventure Cards");
                h.play();
            }

                    if (Input.GetKeyDown(KeyCode.E))
            {
                state = Game.gameState.EndEv;
            }
        }

         //Moved this to the chagePLayer.cs file
        public void nextPlayer()
        {
        /*
            current.GetComponent<PlayerController>().view.setViewOff();
            currIndex = ((currIndex + 1) % numPlayers);
            current = players[currIndex];
            current.GetComponent<PlayerController>().view.setViewOn();
            current.GetComponent<PlayerController>().view.adjustHand();
        */
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