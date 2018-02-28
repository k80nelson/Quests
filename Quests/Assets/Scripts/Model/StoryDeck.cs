using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuestOTRT
{
    public class StoryDeck : Deck<StoryCard>
    {
        //Quests
        public static Quest questSFTHG = new Quest("Search for the Holy Grail", 5);
        public static Quest questTOTGK = new Quest("Test of the Green Knight", 4);
        public static Quest questSFTQB = new Quest("Search for the Questing Beast", 4);
        public static Quest questDTQH = new Quest("Defend the Queen's Honor", 4);
        public static Quest questRTFM = new Quest("Rescue the Fair Maiden", 3);
        public static Quest questJTTEF = new Quest("Journey Through the Enchanted Forest", 3);
        public static Quest questVKAE = new Quest("Vanquish King Arthur's Enemies", 3);
        public static Quest questSTD = new Quest("Slay the Dragon", 3);
        public static Quest questBH = new Quest("Boar Hunt", 2);
        public static Quest questRTSR = new Quest("Repel the Saxon Raiders", 2);

        //Tournament
        public static Tournament tournamentCamelot = new Tournament("Tournament at Camelot", 3);
        public static Tournament tournamentOrkney = new Tournament("Tournament at Orkney", 2);
        public static Tournament tournamentTintagel = new Tournament("Tournament at Tintagel", 1);
        public static Tournament tournamentYork = new Tournament("Tournament at York", 0);

        //Events
        public static Event eventKingRecognition = new Event("Kings Recognition");
        public static Event eventQueensFavor = new Event("Queens Favor");
        public static Event eventCCTC = new Event("Court Called to Camelot");
        public static Event eventPox = new Event("Pox");
        public static Event eventPlague = new Event("Plague");
        public static Event eventChivalrousDeed = new Event("Chivalrous Deed");
        public static Event eventPTTR = new Event("Properity Throughout the Realm");
        public static Event eventKingsCallToArms = new Event("Kings Call to Arms");

        public StoryDeck()
        {

            CardComparer<StoryCard> comparer = new CardComparer<StoryCard>();
            this.DeckList = new Dictionary<StoryCard, int>(comparer);
            this.currCards = 28;
            this.initialize();
            this.ValidCards = DeckList.Keys.ToList();
        }

        public override void emptyDeck()
        {
            initialize();
            this.ValidCards = DeckList.Keys.ToList();
            this.currCards = 28;
        }

        public override void initialize()
        {
            //Quests 
            DeckList[questSFTHG] = 1;
            DeckList[questTOTGK] = 1;
            DeckList[questSFTQB] =1;
            DeckList[questDTQH] = 1;
            DeckList[questRTFM] = 1;
            DeckList[questJTTEF] =  1;
            DeckList[questVKAE] = 2;
            DeckList[questSTD] = 1;
            DeckList[questBH] = 2;
            DeckList[questRTSR] = 2;

            //Tournaments
            DeckList[tournamentCamelot] = 1;
            DeckList[tournamentOrkney] = 1;
            DeckList[tournamentTintagel] = 1;
            DeckList[tournamentYork] = 1;

            //Events
            DeckList[eventKingRecognition] = 2;
            DeckList[eventQueensFavor] = 2;
            DeckList[eventCCTC] = 2;
            DeckList[eventPox] = 1;
            DeckList[eventPlague] = 1;
            DeckList[eventChivalrousDeed] = 1;
            DeckList[eventPTTR] = 1;
            DeckList[eventKingsCallToArms] = 1;
        }
    }
}
