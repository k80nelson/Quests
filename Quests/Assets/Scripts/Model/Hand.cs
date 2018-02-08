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

        public Hand()
        {
            this.maxSize = 20;
            /*changed max size to 20 --> I dont know if u want to do it this way or have another variable.
            You can have more than 12 cards in your hand but u will have to 
            select all cards > 12 and remove the ones you dont want.

            ex if I have 15 cards in hand. I can remove the 3 cards I dont want so that I can get back to 12 cards.
            */
            this.numCards = 0;
            this.cards = new List<AdventureCard>();
        }

        public Hand(int maxSize, List<AdventureCard> cards)
        {
            this.maxSize = maxSize;
            this.numCards = cards.Count;
            this.cards = new List<AdventureCard>(cards);
        }
        
        public bool add(AdventureCard card)
        {
            // Returns true when you've gone over max capacity 
            cards.Add(card);
            numCards++;
            return (numCards > maxSize);
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