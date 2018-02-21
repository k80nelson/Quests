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
        public GameObject[] Players;
        public DeckController Deck;

        void Start()
        {
            Deck = GameObject.FindWithTag("Deck").GetComponent<DeckController>();
            initPlayers();
        }

        void Update()
        {

        }

        void initPlayers()
        {
            PlayerController ctrl;
            foreach (GameObject player in Players)
            {
                ctrl = player.GetComponent<PlayerController>();
                ctrl.addCards(Deck.DrawAdventureCards(12));
            }

            Debug.Log(Deck.numAdvCards());
        }

        //Late Update runs whatever is inside it at the end of the loop, it updates last, so anythign that needs to be done at the end should be done here
        void LateUpdate()
        {

        }
    }
}