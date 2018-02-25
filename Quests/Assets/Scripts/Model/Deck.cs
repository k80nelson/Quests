using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace QuestOTRT
{
    public abstract class Deck<T> where T : Card
    {
        protected static System.Random rnd = new System.Random();
        protected Dictionary<T, int> DeckList;
        protected List<T> ValidCards;
        protected int currCards;
        public int Count
        {
            get
            {
                return currCards;
            }
        }

        public abstract void initialize();
        
        public virtual T draw()
        {
            /* Returns null when deck is empty */
            if (currCards == 0) return null;

            // Weighted randomness -> swords return more often than merlins, for example
            int rand = rnd.Next(0, currCards);
            T selected = null;
            foreach(T card in ValidCards)
            {
                if (rand < DeckList[card])
                {
                    selected = card;
                    break;
                }
                rand -= DeckList[card];
            }

            adjust(selected);
            return selected;
        }

        public virtual List<T> draw(int numToDraw)
        {
            List<T> ret = new List<T>();
            for(int i=0; i<numToDraw; i++)
            {
                ret.Add(draw());
            }
            return ret;
        }

        public virtual T draw(string name)
        {
            if (currCards == 0) return null;

            // Checks that we can actually return that card
            if (!ValidCards.Exists(i => i.Name == name)) return null;
            T card = ValidCards.Find(i => i.Name == name);
            adjust(card);
            return card;
        }

        public virtual List<T> drawAll()
        {
            List<T> tmp = new List<T>();
            while (currCards > 0)
            {
                tmp.Add(draw());
            }
            return tmp;
        }

        public virtual bool adjust(string name)
        {
            // finds the card and uses the already-established function below
            T card = DeckList.Keys.ToList().Find(i => i.Name == name);
            return adjust(card);
        }

        public virtual bool adjust(T card)
        {
            // Shouldn't ever get here
            if (DeckList[card] <= 0) return false;

            // Last card, remove it from the list of valid cards
            if (DeckList[card] == 1) ValidCards.Remove(card);
            DeckList[card] -= 1;
            currCards -= 1;
            return true;
        }


        public virtual int getNumCard(string name)
        {
            // returns the number of that specific card in the deck //
            T card = DeckList.Keys.ToList().Find(i => i.Name == name);
            return DeckList[card];
        }

        public bool AddCards(List<T> cards)
        {
            // adds a collection of cards by list //
            if (!cards.TrueForAll(i => DeckList.ContainsKey(i))) return false;
            else cards.ForEach(i => add(i, 1));
            return true;
        }

        public bool AddCards(Dictionary<T, int> cards)
        {
            // adds a collection of cards by dict //
            List<T> temp = cards.Keys.ToList();
            if (! temp.TrueForAll(i => DeckList.ContainsKey(i))) return false;
            else temp.ForEach(i => add(i, cards[i]));
            return true;
        }

        protected void add(T card, int num)
        {
            // adds num cards to deck //
            DeckList[card] += num;
            currCards += num;
            if (!ValidCards.Contains(card)) ValidCards.Add(card);
        }

        
    }
}
