using System.Collections;
using System.Collections.Generic;

namespace QuestOTRT
{
    public abstract class Deck
    {
        protected Dictionary<int, QuestOTRT.Card> DeckList;
        protected Dictionary<int, int> DeckAmount;

        public abstract void initialize();

        public abstract QuestOTRT.Card draw();

        public abstract bool adjust(string name);
    }
}
