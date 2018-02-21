using System.Collections;
using System.Collections.Generic;

namespace QuestOTRT
{
    public class Player
    {
        private int shields;
        private int bp;
        private int rank;
        private Hand hand;
        private List<Ally> allies;

        public int Shields
        {
            get
            {
                return shields;
            }
        }

        public int BP
        {
            get
            {
                return bp;
            }
        }

        public int NumCards
        {
            get
            {
                return hand.numCards;
            }
        }

        public List<AdventureCard> Cards {
            get
            {
                return hand.Cards;
            }
        }

        public Player()
        {
            this.shields = 0;
            this.bp = 5;
            this.rank = 0;
            this.hand = new Hand();
            this.allies = new List<Ally>();
        }

        public Player(int shields, int bp, int rank, Hand hand, List<Ally> allies)
        {
            this.shields = shields;
            this.bp = bp;
            this.rank = rank;
            this.hand = hand;
            this.allies = allies;
        }

        public List<AdventureCard> getCards()
        {
            return new List<AdventureCard>(hand.Cards);
        }

        public List<Ally> getAllies()
        {
            return new List<Ally>(allies);
        }

        public void addShields(int numToAdd)
        {
            this.shields += numToAdd;
        }

        //Specifically for events where a shield or shields need to be removed
        public void removeShields(int numToAdd)
        {
            this.shields -= numToAdd;
            if (this.shields < 0)
            {
                shields = 0;
            }
        }

        public void addCard(AdventureCard card)
        {
            // returns true when hand gone over max capacity
            this.hand.add(card);
        }

        public void addCards(List<AdventureCard> cards)
        {
            this.hand.addMany(cards);
        }

        public void removeCard(AdventureCard card)
        {
            this.hand.remove(card);
        }

        public void removeCard(string card)
        {
            this.hand.remove(card);
        }

        public bool rankUp()
        {
            switch (this.rank)
            {
                case 0:
                    if (shields >= 5)
                    {
                        shields -= 5;
                        rank++;
                        bp += 5;
                        return true;
                    }
                    return false;
                case 1:
                    if (shields >= 7)
                    {
                        shields -= 7;
                        rank++;
                        bp += 5;
                        return true;
                    }
                    return false;
                default:
                    throw new System.Exception("Trying to rank up past the end game");
            }
        }

        public Rank getRank()
        {
            return (Rank)this.rank;
        }

        public void addAlly(Ally ally)
        {
            allies.Add(ally);
        }

        public void removeAlly(string name)
        {
            // this works as you can only ever have one 
            // ally with the name 'name'
            allies.RemoveAll(ally => ally.Name == name);
        }

        public void removeAlly(Ally toRemove)
        {
            allies.Remove(toRemove);
        }
        
        
    }
}