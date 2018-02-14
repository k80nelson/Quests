using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuestOTRT
{
    public class StoryDeck : Deck
    {
        System.Random rnd = new System.Random();
        public override bool adjust(string name)
        {
            for (int index = 0; index < this.DeckList.Count; index++)
            {
                var cardCheck = DeckList.ElementAt(index);
                if (name == cardCheck.Value.Name)
                {
                    int cardKey = cardCheck.Key;
                    DeckAmount[cardKey] = DeckAmount[cardKey] - 1;
                    return true;
                }
            }

            return false;
        }

        public override QuestOTRT.Card draw()
        {
            int index;
            QuestOTRT.Card card;
                while (true)
                {
                    index = rnd.Next(0, 21);

                    int validity = this.DeckAmount[index];//.ToList()[index];
                    if (validity > 0)
                    {
                        card = this.DeckList[index];//.ToList()[index];
                        return card;
                    }
                }
        }

        public override void initialize()
        {
            //The index is the int, lists the Quests, then Tournaments, then Events
            this.DeckList = new Dictionary<int, QuestOTRT.Card>();

            //Index is the same as the other dictionary, second into represents the number of that kind of cards left
            this.DeckAmount = new Dictionary<int, int>();
            //Quests
            QuestOTRT.Quest questSFTHG = new QuestOTRT.Quest("Search for the Holy Grail", 5);
            QuestOTRT.Quest questTOTGK = new QuestOTRT.Quest("Test of the Green Knight", 4);
            QuestOTRT.Quest questSFTHG = new QuestOTRT.Quest("Search for the Questing Beast", 4);
            QuestOTRT.Quest questDTQH = new QuestOTRT.Quest("Defend the Queen's Honor", 4);
            QuestOTRT.Quest questRTFM = new QuestOTRT.Quest("Rescue the Fair Maiden", 3);
            QuestOTRT.Quest questJTTEF = new QuestOTRT.Quest("Journey Through the Enchanted Forest", 3);
            QuestOTRT.Quest questVKAE = new QuestOTRT.Quest("Vanquish King Arthur's Enemies", 3);
            QuestOTRT.Quest questSTD = new QuestOTRT.Quest("Slay the Dragon", 3);
            QuestOTRT.Quest questBH = new QuestOTRT.Quest("Boar Hunt", 2);
            QuestOTRT.Quest questRTSR = new QuestOTRT.Quest("Repel the Saxon Raiders", 2);

            //Tournament
            QuestOTRT.Tournament tournamentCamelot = new QuestOTRT.Tournament("Tournament at Camelot", 3);
            QuestOTRT.Tournament tournamentOrkney = new QuestOTRT.Tournament("Tournament at Orkney", 2);
            QuestOTRT.Tournament tournamentTintagel = new QuestOTRT.Tournament("Tournament at Tintagel", 1);
            QuestOTRT.Tournament tournamentYork = new QuestOTRT.Tournament("Tournament at York", 0);

            //Tournament
            QuestOTRT.Event eventKingRecognition = new QuestOTRT.Event("King's Recognition");
            QuestOTRT.Event eventQueensFavor = new QuestOTRT.Event("Queen's Favor");
            QuestOTRT.Event eventCCTC = new QuestOTRT.Event("Court Called to Camelot");
            QuestOTRT.Event eventPox = new QuestOTRT.Event("Pox");
            QuestOTRT.Event eventPlague = new QuestOTRT.Event("Plague");
            QuestOTRT.Event eventChivalrousDeed = new QuestOTRT.Event("Chivalrous Deed");
            QuestOTRT.Event eventPTTR = new QuestOTRT.Event("Properity Throughout the Realm");
            QuestOTRT.Event eventKingsCallToArms = new QuestOTRT.Event("King's Call to Arms");

            //Quests 
            DeckList.Add(0, questSFTHG);
            DeckList.Add(1, questTOTGK);
            DeckList.Add(2, questSFTHG);
            DeckList.Add(3, questDTQH);
            DeckList.Add(4, questRTFM);
            DeckList.Add(5, questJTTEF);
            DeckList.Add(6, questVKAE);
            DeckList.Add(7, questSTD);
            DeckList.Add(8, questBH);
            DeckList.Add(9, questRTSR);

            //Tournaments
            DeckList.Add(10, tournamentCamelot);
            DeckList.Add(11, tournamentOrkney);
            DeckList.Add(12, tournamentTintagel);
            DeckList.Add(13, tournamentYork);

            //Events
            DeckList.Add(14, eventKingRecognition);
            DeckList.Add(15, eventQueensFavor);
            DeckList.Add(16, eventCCTC);
            DeckList.Add(17, eventPox);
            DeckList.Add(18, eventPlague);
            DeckList.Add(19, eventChivalrousDeed);
            DeckList.Add(20, eventPTTR);
            DeckList.Add(21, eventKingsCallToArms);

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
