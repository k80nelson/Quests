using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{

    public abstract class CardController<T> : GameElement where T : AdventureCard
    {
        public T card;
        public CardView view;
        private bool clicked;
        public Move move;

        void Update()
        {
           
        }

        void Start()
        {
            view = gameObject.GetComponent<CardView>();
            clicked = false;
            card = null;
            move = gameObject.transform.parent.parent.parent.gameObject.GetComponent<Move>();
        }
        
        protected virtual void OnClick()
        {
            if (game.state != Game.gameState.Quest && game.state != Game.gameState.Tournament && game.state != Game.gameState.Discard) return;
            if (clicked)
            {
                this.clicked = false;
                move.Remove(gameObject);
            }
            else
            {
                if (move.isValid(gameObject))
                {
                    this.clicked = true;
                    move.Add(gameObject);
                }
            }
        }

        protected virtual void OnMouseEnter()
        {
            if (game.state != Game.gameState.Quest && game.state != Game.gameState.Tournament && game.state != Game.gameState.Discard) return;
            view.ScaleUp();
        }

        protected virtual void OnMouseExit()
        {
            if (game.state != Game.gameState.Quest && game.state != Game.gameState.Tournament && game.state != Game.gameState.Discard) return;
            if (!clicked) view.ScaleDown();
        }

        public void initialize(T newCard)
        {
            if (card == null)
            {
                card = newCard;
            }
        }

        public void Reset()
        {
            this.clicked = false;

        }
    }
    /*public abstract class CardController<T> : GameElement where T : Card
    {

        public T card = null;
        public int index;
        public Vector3 firstScale;
        public Vector3 bigScale;
        private bool clicked;
        private bool scaled;
        private string oldTag;

        public void initialize(T newCard)
        {
            if (card == null) card = newCard;
            index = gameObject.transform.GetSiblingIndex();
            clicked = false;
            scaled = false;
            oldTag = gameObject.tag;
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
            if (clicked && (this.game.state == Game.gameState.Quest || this.game.state == Game.gameState.Tournament))
            {
                this.game.turn.removeCard(card);
                this.game.turn.ListAll();
                clicked = false;
                gameObject.tag = oldTag;
            }
            else if(this.game.state == Game.gameState.Quest || this.game.state == Game.gameState.Tournament)
            {
                this.game.turn.addCard(card);
                this.game.turn.ListAll();
                clicked = true;
                gameObject.tag = "Clicked";
            }

            if(this.game.state == Game.gameState.Sponsorship)
            {
                GameObject.FindGameObjectWithTag("SPONSOR").GetComponent<Sponsoring>().add(card);
                clicked = true;
                gameObject.tag = "Clicked";
            }
        }

        public void reset()
        {
            clicked = false;
            tag = oldTag;
            transform.localScale = firstScale;
        }
    }*/
}
