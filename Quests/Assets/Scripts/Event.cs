using System;

namespace QuestOTRT
{
    public class Event : StoryCard
    {      

        //Constructor
        public Event(string name) : base(name){}

        //A switch statement which calls the card that was drawn
        public void play()
        {
            switch (name)
            {
                case "Chivalrous Deed":
                    chivalrousDeed();
            }
        }

        //Functions for all the functionality of our events
        public void chivalrousDeed() { }
    }
}

