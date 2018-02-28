using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public abstract class CardController<T> : GameElement where T : Card
    {

        public T card = null;
        public int index;
        public Vector3 firstScale;
        public Vector3 bigScale;
        private bool clicked;
        private bool scaled;

        public void initialize(T newCard)
        {
            if (card == null) card = newCard;
            index = gameObject.transform.GetSiblingIndex();
            clicked = false;
            scaled = false;
        }

        public void OnMouseExit()
        {
            if (!scaled)
            {
                firstScale = transform.localScale;
                bigScale = firstScale + new Vector3(0.1f, 0.1f, 0.1f);
                scaled = true;
            }
            if (!clicked)
            {
                index = gameObject.transform.GetSiblingIndex();
                transform.localScale = firstScale;
                transform.SetSiblingIndex(index);
            }
            
        }

        public void OnMouseEnter()
        {
            if (!scaled)
            {
                firstScale = transform.localScale;
                bigScale = firstScale + new Vector3(0.1f, 0.1f, 0.1f);
                scaled = true;
            }
            index = gameObject.transform.GetSiblingIndex();
            transform.localScale = bigScale;
            transform.SetAsLastSibling();
        }

        public virtual void OnClick()
        {
            if(this.game.state == Game.gameState.Quest || this.game.state == Game.gameState.Tournament)
            {
                this.game.turn.addCard(card);
                this.game.turn.ListAll();
                clicked = true;
            }
        }
    }
}
