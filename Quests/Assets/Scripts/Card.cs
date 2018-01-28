using System;

namespace QuestOTRT
{

    public abstract class Card
    {
        protected string name;

        protected Card(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
    }
}





