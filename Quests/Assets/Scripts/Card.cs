using System;

namespace QuestOTRT
{

    //OUR CARDS NEED TO HAVE THE EXACT NAMES AS THE EVENT CLASS NAMES

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