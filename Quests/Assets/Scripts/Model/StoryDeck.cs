using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuestOTRT
{
    public class StoryDeck : Deck
    {
        public StoryDeck()
        {
            this.DeckList = new Dictionary<QuestOTRT.Card, int>();
            this.currCards = 28;
            this.initialize();
            this.ValidCards = DeckList.Keys.ToList();
        }
        
        public override void initialize()
        {
            
            //Quests
            QuestOTRT.Quest questSFTHG = new QuestOTRT.Quest("Search for the Holy Grail", 5);
            QuestOTRT.Quest questTOTGK = new QuestOTRT.Quest("Test of the Green Knight", 4);
            QuestOTRT.Quest questSFTQB = new QuestOTRT.Quest("Search for the Questing Beast", 4);
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

            //Events
            QuestOTRT.Event eventKingRecognition = new QuestOTRT.Event("King's Recognition");
            QuestOTRT.Event eventQueensFavor = new QuestOTRT.Event("Queen's Favor");
            QuestOTRT.Event eventCCTC = new QuestOTRT.Event("Court Called to Camelot");
            QuestOTRT.Event eventPox = new QuestOTRT.Event("Pox");
            QuestOTRT.Event eventPlague = new QuestOTRT.Event("Plague");
            QuestOTRT.Event eventChivalrousDeed = new QuestOTRT.Event("Chivalrous Deed");
            QuestOTRT.Event eventPTTR = new QuestOTRT.Event("Properity Throughout the Realm");
            QuestOTRT.Event eventKingsCallToArms = new QuestOTRT.Event("King's Call to Arms");

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
