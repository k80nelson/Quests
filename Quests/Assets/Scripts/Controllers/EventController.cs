using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class EventController : GameElement
    {
        public Event card;
        public CardView view;

        void Start()
        {
            view = gameObject.GetComponent<CardView>();
        }

        public void initialize(Event newCard)
        {
            if (card == null)
            {
                card = newCard;
            }
        }

        public  void OnClick()
        {
            if(this.game.state == Game.gameState.Event)
            {
                this.game.state = Game.gameState.startTurn;
                Destroy(gameObject);
            }
        }
    }
}
