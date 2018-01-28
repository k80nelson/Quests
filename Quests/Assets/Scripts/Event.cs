using System;

namespace QuestOTRT
{
    public class Event : StoryCard
    {      

        //Constructor
        public Event(string name) : base(name){}

        /* Need to rework this--breaks both polymorphism and MVC design patterns 
        //A switch statement which calls the card that was drawn, THESE NAMES NEED TO BE EXACTLY WHAT THE CARDS ARE CALLED
        public void play(string name)
        {
            switch (name)
            {
                case "Chivalrous Deed":
                    chivalrousDeed();
                    break;

                case "Court Called to Camelot":
                    courtCalled();
                    break;

                case "King's Call to Arms":
                    kingCall();
                    break;

                case "King's Recognition":
                    kingRecognition();
                    break;

                case "Plague":
                    plague();
                    break;

                case "Pox":
                    pox();
                    break;

                case "Prosperity Throughout the Realm":
                    prosperityTtR();
                    break;

                case "Queen's Favor":
                    queensFavor();
                    break;

                default:
                    break;
            }
        }

        //Functions for all the functionality of our events
        public void chivalrousDeed()
        {
            //Player(s) with lowest rank and least amount of shields gains 3 shields
        }

        public void courtCalled()
        {
            //All Allies in play are discarded
        }

        public void kingCall()
        {
            //Highest ranked player(s) must place 1 weapon in the discard
                //If unable to do so, 2 foe cards must be discarded
        }

        public void kingRecognition()
        {
            //Next player(s) to complete a Quest reicieve 2 extra shields
        }

        public void plague()
        {
            //Drawer loses 2 shields, if possible
        }

        public void pox()
        {
            //All other players lose one shield(if possible), drawer of this card is exempt
        }

        public void prosperityTtR()
        {
            //All players can immediately draw 2 Adventure Cards
        }

        public void queensFavor()
        {
            //Lowest ranked player(s) immediately recieve 2 Adventure Cards
        }*/
    }
}

