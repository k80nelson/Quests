using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace QuestOTRT
{
    public abstract class Deck
    {
        protected static System.Random rnd = new System.Random();
        protected Dictionary<QuestOTRT.Card, int> DeckList;
        protected List<QuestOTRT.Card> ValidCards;
        protected int currCards;
        public int Count
        {
            get
            {
                return currCards;
            }
        }

        public abstract void initialize();
        
        
        public virtual QuestOTRT.Card draw()
        {
            /* Returns null when deck is empty */
            if (currCards == 0) return null;

            // Weighted randomness -> swords return more often than merlins, for example
            int rand = rnd.Next(0, currCards);
            QuestOTRT.Card selected = null;
            foreach(QuestOTRT.Card card in ValidCards)
            {
                if (rand < DeckList[card])
                {
                    selected = card;
                    break;
                }
                rand -= DeckList[card];
            }

            if(!adjust(selected)) throw new Exception("Something went wrong while removing from the deck");
            return selected;
        }

        public virtual QuestOTRT.Card draw(string name)
        {
            if (currCards == 0) return null;

            // Checks that we can actually return that card
            if (!ValidCards.Exists(i => i.Name == name)) return null;
            QuestOTRT.Card card = ValidCards.Find(i => i.Name == name);
            adjust(card);
            return card;
        }

        public virtual bool adjust(string name)
        {
            // finds the card and uses the already-established function below
            QuestOTRT.Card card = DeckList.Keys.ToList().Find(i => i.Name == name);
            return adjust(card);
        }

        public virtual bool adjust(QuestOTRT.Card card)
        {
            // Shouldn't ever get here
            if (DeckList[card] <= 0) return false;

            // Last card, remove it from the list of valid cards
            if (DeckList[card] == 1) ValidCards.Remove(card);
            DeckList[card] -= 1;
            currCards -= 1;
            return true;
        }

        public override string ToString()
        {
            // convenience function for debugging
            string tmp = "";
            foreach (QuestOTRT.Card card in ValidCards)
            {
                tmp += card.Name + " " + DeckList[card] + ",  ";
            }
            return tmp;
        }
    }
}
