using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuestOTRT
{
    public class AdventureDeck : Deck<AdventureCard>
    {
        public AdventureDeck()
        {
            CardComparer<AdventureCard> comparer = new CardComparer<AdventureCard>();
            this.DeckList = new Dictionary<AdventureCard, int>(comparer);
            this.currCards = 125;
            this.initialize();
            this.ValidCards = DeckList.Keys.ToList();
        }
        
        public override void initialize()
        {
            //Weapons
            Weapon excalibur = new Weapon("Excalibur", 30, 0);
            Weapon lance = new Weapon("Lance", 20, 0);
            Weapon battleAx = new Weapon("Battle-axe", 15, 0);
            Weapon sword = new Weapon("Sword", 10, 0);
            Weapon horse = new Weapon("Horse", 10, 0);
            Weapon dagger = new Weapon("Dagger", 5, 0);
            
            //Foes
            Foe dragon = new Foe("Dragon", 50, 1, 70, new string[] { "Search for the Holy Grail", "Slay the Dragon", "Defend the Queen's Honor" });
            Foe giant = new Foe("Giant", 40, 1, 40, new string[] {"Search for the Holy Grail", "Defend the Queen's Honor" });
            Foe mordred = new Foe("Mordred", 30, 1, 30, new string[] { "Search for the Holy Grail", "Defend the Queen's Honor" });
            Foe greenKnight = new Foe("Green Knight", 25, 1, 40, new string[] { "Search for the Holy Grail", "Test of the Green Knight", "Defend the Queen's Honor" });
            Foe blackKnight = new Foe("Black Knight", 25, 1, 35, new string[] { "Search for the Holy Grail", "Rescue the Fair Maiden", "Defend the Queen's Honor" });
            Foe evilKnight = new Foe("Evil Knight", 20, 1, 30, new string[]{ "Search for the Holy Grail", "Journey Through the Enchanted Forest", "Defend the Queen's Honor" });
            Foe saxonKnight = new Foe("Saxon Knight", 15, 1, 25, new string[] { "Search for the Holy Grail", "Repel the Saxon Raiders", "Defend the Queen's Honor" });
            Foe robberKnight = new Foe("Robber Knight", 15, 1, 15, new string[] { "Search for the Holy Grail", "Defend the Queen's Honor" });
            Foe saxons = new Foe("Saxons", 10, 1, 20, new string[] { "Search for the Holy Grail", "Repel the Saxon Raiders", "Defend the Queen's Honor" });
            Foe boar = new Foe("Boar", 5, 1, 15, new string[] { "Search for the Holy Grail", "Boar Hunt", "Defend the Queen's Honor" });
            Foe thieves = new Foe("Thieves", 5, 1, 5, new string[] { "Search for the Holy Grail", "Defend the Queen's Honor" });
            
            //Amours
            Amour amours = new Amour("Amour", 10, 1);
            
            //Allies
            Ally sirGalahad = new Ally("Sir Galahad", 15, 1, 15, 1, null);
            Ally sirLancelot = new Ally("Sir Lancelot", 15, 1, 25, 1, "Defend the Queen's Honor");
            Ally kingArthur = new Ally("King Arthur", 10, 2, 10, 2, null);
            Ally sirTristan = new Ally("Sir Tristan", 10, 1, 20, 1, "Queen Iseult");
            Ally kingPellinore = new Ally("King Pellinore", 10, 1, 10, 4, "Search for the Questing Beast");
            Ally sirGawain = new Ally("Sir Gawain", 10, 1, 20, 1, "Test of the Green Knight");
            Ally sirPercival = new Ally("Sir Percival", 5, 1, 20, 1, "Search for the Holy Grail");
            Ally queenGuinevere = new Ally("Queen Guinevere", 0, 3, 0, 3, null);
            Ally queenIseult = new Ally("Queen Iseult", 0, 2, 0, 4, "Sir Tristan");
            Ally merlin = new Ally("Merlin", 0, 1, 0, 1, null);

            //Tests
            Test testOfValor = new Test("Test of Valor", 0, 1, 1, null);
            Test testOfTemptation = new Test("Test of Temptation", 0, 1, 1, null);
            Test testOfMorganLeFey = new Test("Test of Morgan Le Fey", 0, 1, 3, null);
            Test testOfQuestingBeast = new Test("Test of the Questing Beast", 0, 1, 4, "Search for the Questing Beast");

            //Weapons
            DeckList.Add(excalibur, 2);
            DeckList.Add(lance, 6);
            DeckList.Add(battleAx, 8);
            DeckList.Add(sword, 16);
            DeckList.Add(horse, 11);
            DeckList.Add(dagger, 6);

            //Foes
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

            //Tests
            DeckList.Add(testOfValor, 2);
            DeckList.Add(testOfTemptation, 2);
            DeckList.Add(testOfMorganLeFey, 2);
            DeckList.Add(testOfQuestingBeast, 2);

            //Allies
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

            //~Amour~
            DeckList.Add(amours, 8);   
        }
        
    }
}

