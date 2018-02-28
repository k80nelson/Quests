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
        public enum gameState { startTurn, Quest, Event, Tournment, endTurn};
        public gameState state;

        void Start()
        {
            deck = GameObject.FindWithTag("Deck").GetComponent<DeckController>();

            //runs the init player method with players having a count of 4 in 4pGame
            initPlayers();
            }

        void Update()
        {
           if (state == gameState.startTurn)
           {

           }
           else if(state == gameState.Quest)
           {

           }
           else if (state == gameState.Event)
           {

           }
           else if (state == gameState.Tournment)
           {

           }
           else if (state == gameState.endTurn)
           {

           }
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