using System.Collections;
using System.Collections.Generic;

namespace QuestOTRT
{
    public class Hand
    {
        private int maxSize;
        private int numCards;
        private List<AdventureCard> cards;
        public List<AdventureCard> Cards
        {
            get
            {
                return cards;
            }
        }

        public bool overMax()
        {
            return numCards > maxSize;
        }

        public Hand()
        {
            this.maxSize = 12;
            this.numCards = 0;
            this.cards = new List<AdventureCard>();
        }

        public Hand(int maxSize, List<AdventureCard> cards)
        {
            this.maxSize = maxSize;
            this.numCards = cards.Count;
            this.cards = new List<AdventureCard>(cards);
        }
        
        public void add(AdventureCard card)
        {
            // Returns true when you've gone over max capacity 
            cards.Add(card);
            numCards++;
        }

        public void remove(AdventureCard card)
        {
            cards.Remove(card);
        }

        public void remove(string card)
        {
            cards.RemoveAt(cards.FindIndex(i => i.Equals(card)));
        }
    }
}