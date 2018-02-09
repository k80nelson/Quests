using System.Collections;
using System.Collections.Generic;

namespace QuestOTRT
{
    public class StoryDeck : Deck
    {

        public override string draw()
        {
            int index;
            bool check = true;
            string card;
            System.Random rnd = new System.Random();
            {
                while (check)
                {
                    index = rnd.Next(0, 21);

                    int validity = this.DeckAmount[index];//.ToList()[index];
                    if (validity > 0)
                    {
                        card = this.DeckList[index];//.ToList()[index];
                        check = false;
                        return card;

                    }

                }
                return "";
            }
        }

        public override void initialize()
        {
            //The index is the int, lists the Quests, then Tournaments, then Events
            this.DeckList = new Dictionary<int, string>();

            //Index is the same as the other dictionary, second into represents the number of that kind of cards left
            this.DeckAmount = new Dictionary<int, int>();

            //Quests
            DeckList.Add(0, "Search for the Holy Grail");
            DeckList.Add(1, "Test of the Green Knight");
            DeckList.Add(2, "Search for the Questing Beast");
            DeckList.Add(3, "Defend the Queen's Honor");
            DeckList.Add(4, "Rescue the Fair Maiden");
            DeckList.Add(5, "Journey Through the Enchanted Forest");
            DeckList.Add(6, "Vanquish King Arthur's Enemies");
            DeckList.Add(7, "Slay the Dragon");
            DeckList.Add(8, "Boar Hunt");
            DeckList.Add(9, "Repel the Saxon Raiders");

            //Tournaments
            DeckList.Add(10, "Tournament at Camelot");
            DeckList.Add(11, "Tournament at Orkney");
            DeckList.Add(12, "Tournament at Tintagel");
            DeckList.Add(13, "Tournament at York");

            //Events
            DeckList.Add(14, "King's Recognition");
            DeckList.Add(15, "Queen's Favor");
            DeckList.Add(16, "Court Called to Camelot");
            DeckList.Add(17, "Pox");
            DeckList.Add(18, "Plague");
            DeckList.Add(19, "Chivalrous Deed");
            DeckList.Add(20, "Properity Throughout the Realm");
            DeckList.Add(21, "King's Call to Arms");

            //Adding the amounts of each card to the Dictionary
            //Quests
            DeckAmount.Add(0, 1);
            DeckAmount.Add(1, 1);
            DeckAmount.Add(2, 1);
            DeckAmount.Add(3, 1);
            DeckAmount.Add(4, 1);
            DeckAmount.Add(5, 1);
            DeckAmount.Add(6, 2);
            DeckAmount.Add(7, 1);
            DeckAmount.Add(8, 2);
            DeckAmount.Add(9, 2);

            //Tournaments
            DeckAmount.Add(10, 1);
            DeckAmount.Add(11, 1);
            DeckAmount.Add(12, 1);
            DeckAmount.Add(13, 1);

            //Events
            DeckAmount.Add(14, 2);
            DeckAmount.Add(15, 2);
            DeckAmount.Add(16, 2);
            DeckAmount.Add(17, 1);
            DeckAmount.Add(18, 1);
            DeckAmount.Add(19, 1);
            DeckAmount.Add(20, 1);
            DeckAmount.Add(21, 1);
        }
    }
}
