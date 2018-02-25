using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{

    public abstract class Card : GameElement, IEquatable<Card>, IEquatable<string>
    {
        protected new string name;

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

    public class CardComparer<T> : IEqualityComparer<T> where T: Card
    {
        public bool Equals(T c1, T c2)
        {
            if (c1 == null && c2 == null) return true;
            else if (c1 == null | c2 == null) return false;
            return c1.Name == c2.Name;
        }
        public int GetHashCode(T card)
        {
            if (card == null) return 0;
            int code = card.Name.GetHashCode();
            return code;
        }
    }
}