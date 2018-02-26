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
            
            //gets the number of player object from the current gameMode and then create any array with those objects
            players = GameObject.FindGameObjectsWithTag("Player");
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
            int i = 1;
            //loops though the number of players that are playing
            foreach (GameObject player in players)
            {
                Debug.Log("Init player loop");
                GameObject tempPlayer = GameObject.Find("Player "+i);
                //ctrl = player.GetComponent<PlayerController>();
                ctrl = tempPlayer.GetComponent<PlayerController>();
                //game throws error when trying to draw cards
                ctrl.addCards(deck.DrawAdventureCards(12));
                Debug.Log(ctrl.player.NumCards);
                i++;
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