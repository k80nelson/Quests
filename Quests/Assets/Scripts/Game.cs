using System;
using UnityEngine;

namespace QuestOTRT
{
    public class GameElement : MonoBehaviour
    {
        public Game gameState { get { return GameObject.FindObjectOfType<Game>(); } }
    }

    public class Game : MonoBehaviour
    {
        public int numPlayers;
        public int numControlled;
        public GameObject[] players;
        public DeckController deck;

        void Start()
        {
            //Deck = GameObject.FindWithTag("Deck").GetComponent<DeckController>();
            deck = new DeckController();
            
            //runs the init player method with players having a count of 4 in 4pGame
            initPlayers();
            }

        void Update()
        {
           // Debug.Log("Game update");
        }

        void initPlayers()
        {
            Debug.Log("Game initPlayer");
            PlayerController ctrl;
            foreach (GameObject player in this.players)
            {
                ctrl = player.GetComponent<PlayerController>();
                ctrl.player.addCards(deck.DrawAdventureCards(12));
            }

            //Debug.Log("The number of cards for " + ctrl.player.name + " is " + ctrl.player.NumCards);
            Debug.Log("after player loop");
            Debug.Log(deck.numAdvCards());
        }

        //Late Update runs whatever is inside it at the end of the loop, it updates last, so anythign that needs to be done at the end should be done here
        void LateUpdate()
        {
           // Debug.Log("Game Late Update");
        }
    }
}