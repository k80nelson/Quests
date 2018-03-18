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

        //Adds one adventure card to the list
        public void Add(AdventureCard card)
        {
            if (cardsPlayed == null) cardsPlayed = new List<AdventureCard>();
            cardsPlayed.Add(card);
        }

        //Adds a list of adventure cards to the list
        public void add(List<AdventureCard> cards)
        {
            if (cards == null) cards = new List<AdventureCard>();
            this.cardsPlayed.AddRange(cards);
        }

        //Remove one adventure card from the list, this can be used to remove the amour card at the end of the quest. So we can keep the other cards
        public void Remove(AdventureCard card)
        {
            if (cardsPlayed == null) return;
            cardsPlayed.Remove(card);
        }
        
        //Will remove all weapons cards from the list, this can be used for removing the weapons at the end of each stage
        public void RemoveWeapons()
        {
            if (cardsPlayed == null) return;

            for(int i = 0; i < cardsPlayed.Count; i++)
            {
                if(cardsPlayed[i].type == AdventureCard.Type.WEAPON)
                {
                    cardsPlayed.Remove(cardsPlayed[i]);
                }
            }
                
        }
    }
}