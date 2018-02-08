using System.Collections;
using System.Collections.Generic;

namespace QuestOTRT
{
    public abstract class Deck
    {
        protected Dictionary<int, string> DeckList;
        protected Dictionary<int, int> DeckAmount;

        public abstract void initialize();
    }
}
