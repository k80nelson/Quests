using System;

namespace QuestOTRT
{

    public abstract class Card : IEquatable<Card>, IEquatable<string>
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

        public bool Equals(Card other)
        {
            return this.Name == other.Name;
        }

        public bool Equals(string name)
        {
            return this.Name == name;
        }
    }
}