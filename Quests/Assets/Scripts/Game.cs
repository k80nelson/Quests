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
            initPlayers();
        }

        void Update()
        {

        }

        void initPlayers()
        {
            PlayerController ctrl;
            foreach (GameObject player in players)
            {
                ctrl = player.GetComponent<PlayerController>();
                ctrl.addCards(deck.DrawAdventureCards(12));
            }

            Debug.Log(deck.numAdvCards());
        }

        //Late Update runs whatever is inside it at the end of the loop, it updates last, so anythign that needs to be done at the end should be done here
        void LateUpdate()
        {

        }
    }
}