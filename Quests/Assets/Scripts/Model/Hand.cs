using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class Hand : MonoBehaviour 
    {
        private int maxSize;
        public int numCards;
        private List<AdventureCard> cards;
        public List<AdventureCard> Cards
        {
            get
            {
                return cards;
            }
        }

        public List<Ally> getAllies()
        {
            return cards.OfType<Ally>().ToList();
        }

        public List<Amour> getAmours()
        {
            return cards.OfType<Amour>().ToList();
        }

        public List<Foe> getFoes()
        {
            return cards.OfType<Foe>().ToList();
        }

        public List<Test> getTests()
        {
            return cards.OfType<Test>().ToList();
        }

        public List<Weapon> getWeapons()
        {
            return cards.OfType<Weapon>().ToList();
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
            cards.Add(card);
            numCards++;
        }

        public void addMany(List<AdventureCard> cards)
        {
            foreach(AdventureCard card in cards)
            {
                add(card);
            }
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