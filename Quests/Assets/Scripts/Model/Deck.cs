using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace QuestOTRT
{
    
    public abstract class Deck
    {
        System.Random rnd = new System.Random();
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
            if (currCards == 0) return null;
            QuestOTRT.Card card = ValidCards[rnd.Next(0, ValidCards.Count)];
            adjust(card);
            return card;
        }

        public virtual QuestOTRT.Card draw(string name)
        {
            if (currCards == 0) return null;
            if (!ValidCards.Exists(i => i.Name == name)) return null;
            QuestOTRT.Card card = ValidCards.Find(i => i.Name == name);
            adjust(card);
            return card;
        }

        public virtual bool adjust(string name)
        {
            QuestOTRT.Card card = DeckList.Keys.ToList().Find(i => i.Name == name);
            return adjust(card);
        }

        public virtual bool adjust(QuestOTRT.Card card)
        {
            if (DeckList[card] <= 0) return false;
            if (DeckList[card] == 1) ValidCards.Remove(card);
            DeckList[card] -= 1;
            currCards -= 1;
            return true;
        }

        public override string ToString()
        {
            string tmp = "";
            foreach (QuestOTRT.Card card in ValidCards)
            {
                tmp += card.Name + " " + DeckList[card] + ",  ";
            }
            return tmp;
        }
    }
}
