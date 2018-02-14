using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuestOTRT
{
    public class StoryDeck : Deck<StoryCard>
    {
        public StoryDeck()
        {
            CardComparer<StoryCard> comparer = new CardComparer<StoryCard>();
            this.DeckList = new Dictionary<StoryCard, int>(comparer);
            this.currCards = 28;
            this.initialize();
            this.ValidCards = DeckList.Keys.ToList();
        }

        public override void initialize()
        {
            //Quests
            Quest questSFTHG = new Quest("Search for the Holy Grail", 5);
            Quest questTOTGK = new Quest("Test of the Green Knight", 4);
            Quest questSFTQB = new Quest("Search for the Questing Beast", 4);
            Quest questDTQH = new Quest("Defend the Queen's Honor", 4);
            Quest questRTFM = new Quest("Rescue the Fair Maiden", 3);
            Quest questJTTEF = new Quest("Journey Through the Enchanted Forest", 3);
            Quest questVKAE = new Quest("Vanquish King Arthur's Enemies", 3);
            Quest questSTD = new Quest("Slay the Dragon", 3);
            Quest questBH = new Quest("Boar Hunt", 2);
            Quest questRTSR = new Quest("Repel the Saxon Raiders", 2);

            //Tournament
            Tournament tournamentCamelot = new Tournament("Tournament at Camelot", 3);
            Tournament tournamentOrkney = new Tournament("Tournament at Orkney", 2);
            Tournament tournamentTintagel = new Tournament("Tournament at Tintagel", 1);
            Tournament tournamentYork = new Tournament("Tournament at York", 0);

            //Events
            Event eventKingRecognition = new Event("King's Recognition");
            Event eventQueensFavor = new Event("Queen's Favor");
            Event eventCCTC = new Event("Court Called to Camelot");
            Event eventPox = new Event("Pox");
            Event eventPlague = new Event("Plague");
            Event eventChivalrousDeed = new Event("Chivalrous Deed");
            Event eventPTTR = new Event("Properity Throughout the Realm");
            Event eventKingsCallToArms = new Event("King's Call to Arms");

            //Quests 
            DeckList.Add(questSFTHG, 1);
            DeckList.Add(questTOTGK, 1);
            DeckList.Add(questSFTQB, 1);
            DeckList.Add(questDTQH, 1);
            DeckList.Add(questRTFM, 1);
            DeckList.Add(questJTTEF, 1);
            DeckList.Add(questVKAE, 2);
            DeckList.Add(questSTD, 1);
            DeckList.Add(questBH, 2);
            DeckList.Add(questRTSR, 2);

            //Tournaments
            DeckList.Add(tournamentCamelot, 1);
            DeckList.Add(tournamentOrkney, 1);
            DeckList.Add(tournamentTintagel, 1);
            DeckList.Add(tournamentYork, 1);

            //Events
            DeckList.Add(eventKingRecognition, 2);
            DeckList.Add(eventQueensFavor, 2);
            DeckList.Add(eventCCTC, 2);
            DeckList.Add(eventPox, 1);
            DeckList.Add(eventPlague, 1);
            DeckList.Add(eventChivalrousDeed, 1);
            DeckList.Add(eventPTTR, 1);
            DeckList.Add(eventKingsCallToArms, 1);
        }
    }
}
