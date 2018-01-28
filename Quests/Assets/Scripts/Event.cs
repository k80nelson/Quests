using System;

namespace QuestOTRT
{
    public class Event : StoryCard
    {
        //Variable to determine which card was drawn
        private string CardName;

        //Constructor
        public Event(string name)
        {
            this.CardName = name;
        }

        //Name Getter
        public string getEventName()
        {
            return CardName;
        }

        //Name Setter
        public void setEventName(string name)
        {
            this.CardName = name;
        }

        //A switch statement which calls the card that was drawn
        public void play()
        {
            switch (CardName)
            {
                case "Chivalrous Deed":
                    chivalrousDeed();
            }
        }

        //Functions for all the functionality of our events
        public void chivalrousDeed() { }
    }
}

