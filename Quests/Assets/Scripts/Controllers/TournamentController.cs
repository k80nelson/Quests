using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class TournamentController : GameElement
    {
        public Tournament card;
        public CardView view;

        void Start()
        {
            view = gameObject.GetComponent<CardView>();
        }

        public void initialize(Tournament newCard)
        {
            if (card == null)
            {
                card = newCard;
            }
        }

        public void OnClick()
        {
            if (this.game.state == Game.gameState.TourDecision)
            {
                this.game.state = Game.gameState.startTurn;
                Destroy(gameObject);
            }
        }

        public int getShields()
        {
            return card.Shields;
        }
    }
}
