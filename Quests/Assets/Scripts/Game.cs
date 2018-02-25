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
            Debug.Log("Game Start");
            //Deck = GameObject.FindWithTag("Deck").GetComponent<DeckController>();
            deck = new DeckController();

            players = GameObject.FindGameObjectsWithTag("Player");
                            
            initPlayers();
            
         
            Debug.Log("Just finished the Game Start");
        }

        void Update()
        {
            Debug.Log("Game update");
        }

        void initPlayers()
        {
            Debug.Log("Game initPlayer");
            PlayerController ctrl;
            Debug.Log("before player loop");
            Debug.Log("There are " + players.Length + " numbers of players");
            foreach (GameObject player in players)
            {
                Debug.Log("Init player loop");
                ctrl = player.GetComponent<PlayerController>();
                ctrl.addCards(deck.DrawAdventureCards(12));
            }
            Debug.Log("after player loop");
            Debug.Log(deck.numAdvCards());
        }

        //Late Update runs whatever is inside it at the end of the loop, it updates last, so anythign that needs to be done at the end should be done here
        void LateUpdate()
        {
            Debug.Log("Game Late Update");
        }
    }
}