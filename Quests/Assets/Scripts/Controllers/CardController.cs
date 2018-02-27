using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public abstract class CardController<T> : GameElement where T : Card
    {

        public T card = null;


        public void initialize(T ally)
        {
            if (card == null) card = ally;
        }

    }
}
