using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class StageModel
    {

        public List<AdventureCard> cardsPlayed;

        public StageModel()
        {
            cardsPlayed = new List<AdventureCard>();
        }

        //Returns the number of cards for that stage
        public int Count
        {
            get
            {
                return cardsPlayed.Count;
            }
        }

        public void Add(AdventureCard card)
        {
            if (cardsPlayed == null) cardsPlayed = new List<AdventureCard>();
            cardsPlayed.Add(card);
        }

        public void add(List<AdventureCard> cards)
        {
            if (cards == null) cards = new List<AdventureCard>();
            this.cardsPlayed.AddRange(cards);
        }
    }
}