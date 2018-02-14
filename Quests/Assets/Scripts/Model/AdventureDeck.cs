using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuestOTRT
{
    public class AdventureDeck : Deck
    {
        public AdventureDeck()
        {
            this.DeckList = new Dictionary<QuestOTRT.Card, int>();
            this.currCards = 125;
            this.initialize();
            this.ValidCards = DeckList.Keys.ToList();
        }
        
        public override void initialize()
        {
            //Weapons
            QuestOTRT.Weapon excalibur = new QuestOTRT.Weapon("Excalibur", 30, 0);
            QuestOTRT.Weapon lance = new QuestOTRT.Weapon("Lance", 20, 0);
            QuestOTRT.Weapon battleAx = new QuestOTRT.Weapon("Battle-ax", 15, 0);
            QuestOTRT.Weapon sword = new QuestOTRT.Weapon("Sword", 10, 0);
            QuestOTRT.Weapon horse = new QuestOTRT.Weapon("Horse", 10, 0);
            QuestOTRT.Weapon dagger = new QuestOTRT.Weapon("Dagger", 5, 0);
            
            //Foe
            QuestOTRT.Foe dragon = new QuestOTRT.Foe("Dragon", 50, 1, 70, new string[] { "Search for the Holy Grail", "Slay the Dragon", "Defend the Queen's Honor" });
            QuestOTRT.Foe giant = new QuestOTRT.Foe("Giant", 40, 1, 40, new string[] {"Search for the Holy Grail", "Defend the Queen's Honor" });
            QuestOTRT.Foe mordred = new QuestOTRT.Foe("Mordred", 30, 1, 30, new string[] { "Search for the Holy Grail", "Defend the Queen's Honor" });
            QuestOTRT.Foe greenKnight = new QuestOTRT.Foe("Green Knight", 25, 1, 40, new string[] { "Search for the Holy Grail", "Test of the Green Knight", "Defend the Queen's Honor" });
            QuestOTRT.Foe blackKnight = new QuestOTRT.Foe("Black Knight", 25, 1, 35, new string[] { "Search for the Holy Grail", "Rescue the Fair Maiden", "Defend the Queen's Honor" });
            QuestOTRT.Foe evilKnight = new QuestOTRT.Foe("Evil Knight", 20, 1, 30, new string[]{ "Search for the Holy Grail", "Journey Through the Enchanted Forest", "Defend the Queen's Honor" });
            QuestOTRT.Foe saxonKnight = new QuestOTRT.Foe("Saxon Knight", 15, 1, 25, new string[] { "Search for the Holy Grail", "Repel the Saxon Raiders", "Defend the Queen's Honor" });
            QuestOTRT.Foe robberKnight = new QuestOTRT.Foe("Robber Knight", 15, 1, 15, new string[] { "Search for the Holy Grail", "Defend the Queen's Honor" });
            QuestOTRT.Foe saxons = new QuestOTRT.Foe("Saxon", 10, 1, 20, new string[] { "Search for the Holy Grail", "Repel the Saxon Raiders", "Defend the Queen's Honor" });
            QuestOTRT.Foe boar = new QuestOTRT.Foe("Boar", 5, 1, 15, new string[] { "Search for the Holy Grail", "Boar Hunt", "Defend the Queen's Honor" });
            QuestOTRT.Foe thieves = new QuestOTRT.Foe("Thieves", 5, 1, 5, new string[] { "Search for the Holy Grail", "Defend the Queen's Honor" });
            
            //Amour
            QuestOTRT.Amour amours = new QuestOTRT.Amour("Amours", 10, 1);
            
            //Allies
            QuestOTRT.Ally sirGalahad = new QuestOTRT.Ally("Sir Galahad", 15, 1, 15, 1, null);
            QuestOTRT.Ally sirLancelot = new QuestOTRT.Ally("Sir Lancelot", 15, 1, 25, 1, "Defend the Queen's Honor");
            QuestOTRT.Ally kingArthur = new QuestOTRT.Ally("King Arthur", 10, 2, 10, 2, null);
            QuestOTRT.Ally sirTristan = new QuestOTRT.Ally("Sir Tristan", 10, 1, 20, 1, "Queen Iseult");
            QuestOTRT.Ally kingPellinore = new QuestOTRT.Ally("King Pellinore", 10, 1, 10, 4, "Search for the Questing Beast");
            QuestOTRT.Ally sirGawain = new QuestOTRT.Ally("Sir Gawain", 10, 1, 20, 1, "Test of the Green Knight");
            QuestOTRT.Ally sirPercival = new QuestOTRT.Ally("Sir Percival", 5, 1, 20, 1, "Search for the Holy Grail");
            QuestOTRT.Ally queenGuinevere = new QuestOTRT.Ally("Queen Guinevere", 0, 3, 0, 3, null);
            QuestOTRT.Ally queenIseult = new QuestOTRT.Ally("Queen Iseult", 0, 2, 0, 4, "Sir Tristan");
            QuestOTRT.Ally merlin = new QuestOTRT.Ally("Merlin", 0, 1, 0, 1, null);

            //Tests
            QuestOTRT.Test testOfValor = new QuestOTRT.Test("Test of Valor", 0, 1, 1, null);
            QuestOTRT.Test testOfTemptation = new QuestOTRT.Test("Test of Temptation", 0, 1, 1, null);
            QuestOTRT.Test testOfMorganLeFey = new QuestOTRT.Test("Test of Morgan Le Fey", 0, 1, 3, null);
            QuestOTRT.Test testOfQuestingBeast = new QuestOTRT.Test("Test of the Questing Beast", 0, 1, 4, "Search for the Questing Beast");


            DeckList.Add(excalibur, 2);
            DeckList.Add(lance, 6);
            DeckList.Add(battleAx, 8);
            DeckList.Add(sword, 16);
            DeckList.Add(horse, 11);
            DeckList.Add(dagger, 6);

            DeckList.Add(dragon, 1);
            DeckList.Add(giant, 2);
            DeckList.Add(mordred, 4);
            DeckList.Add(greenKnight, 2);
            DeckList.Add(blackKnight, 3);
            DeckList.Add(evilKnight, 6);
            DeckList.Add(saxonKnight, 8);
            DeckList.Add(robberKnight, 7);
            DeckList.Add(saxons, 5);
            DeckList.Add(boar, 4);
            DeckList.Add(thieves, 8);

            DeckList.Add(testOfValor, 2);
            DeckList.Add(testOfTemptation, 2);
            DeckList.Add(testOfMorganLeFey, 2);
            DeckList.Add(testOfQuestingBeast, 2);

            DeckList.Add(sirGalahad, 1);
            DeckList.Add(sirLancelot, 1);
            DeckList.Add(kingArthur, 1);
            DeckList.Add(sirTristan, 1);
            DeckList.Add(kingPellinore, 1);
            DeckList.Add(sirGawain, 1);
            DeckList.Add(sirPercival, 1);
            DeckList.Add(queenGuinevere, 1);
            DeckList.Add(queenIseult, 1);
            DeckList.Add(merlin, 1);

            DeckList.Add(amours, 8);
        }
    }
}

