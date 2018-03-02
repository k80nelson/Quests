using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class QuestController : GameElement
    {
        public Quest card;
        public CardView view;

        void Start()
        {
            view = gameObject.GetComponent<CardView>();
        }

        public void initialize(Quest newCard)
        {
            if (card == null)
            {
                card = newCard;
            }
        }
        public void OnClick()
        {
            if (this.game.state == Game.gameState.Sponsorship)
            {
                this.game.state = Game.gameState.startTurn;
                Destroy(gameObject);
            }
        }
    }
}
