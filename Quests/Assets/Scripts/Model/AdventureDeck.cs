using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuestOTRT
{
    public class AdventureDeck : Deck<AdventureCard>
    {
        public static Weapon excalibur = new Weapon("Excalibur", 30, 0);
        public static Weapon lance = new Weapon("Lance", 20, 0);
        public static Weapon battleAx = new Weapon("Battle-Axe", 15, 0);
        public static Weapon sword = new Weapon("Sword", 10, 0);
        public static Weapon horse = new Weapon("Horse", 10, 0);
        public static Weapon dagger = new Weapon("Dagger", 5, 0);

        //Foes
        public static Foe dragon = new Foe("Dragon", 50, 1, 70, new string[] { "Search for the Holy Grail", "Slay the Dragon", "Defend the Queen's Honor" });
        public static Foe giant = new Foe("Giant", 40, 1, 40, new string[] { "Search for the Holy Grail", "Defend the Queen's Honor" });
        public static Foe mordred = new Foe("Mordred", 30, 1, 30, new string[] { "Search for the Holy Grail", "Defend the Queen's Honor" });
        public static Foe greenKnight = new Foe("Green Knight", 25, 1, 40, new string[] { "Search for the Holy Grail", "Test of the Green Knight", "Defend the Queen's Honor" });
        public static Foe blackKnight = new Foe("Black Knight", 25, 1, 35, new string[] { "Search for the Holy Grail", "Rescue the Fair Maiden", "Defend the Queen's Honor" });
        public static Foe evilKnight = new Foe("Evil Knight", 20, 1, 30, new string[] { "Search for the Holy Grail", "Journey Through the Enchanted Forest", "Defend the Queen's Honor" });
        public static Foe saxonKnight = new Foe("Saxon Knight", 15, 1, 25, new string[] { "Search for the Holy Grail", "Repel the Saxon Raiders", "Defend the Queen's Honor" });
        public static Foe robberKnight = new Foe("Robber Knight", 15, 1, 15, new string[] { "Search for the Holy Grail", "Defend the Queen's Honor" });
        public static Foe saxons = new Foe("Saxons", 10, 1, 20, new string[] { "Search for the Holy Grail", "Repel the Saxon Raiders", "Defend the Queen's Honor" });
        public static Foe boar = new Foe("Boar", 5, 1, 15, new string[] { "Search for the Holy Grail", "Boar Hunt", "Defend the Queen's Honor" });
        public static Foe thieves = new Foe("Thieves", 5, 1, 5, new string[] { "Search for the Holy Grail", "Defend the Queen's Honor" });

        //Amours
        public static Amour amours = new Amour("Amour", 10, 1);

        //Allies
        public static Ally sirGalahad = new Ally("Sir Galahad", 15, 1, 15, 1, null);
        public static Ally sirLancelot = new Ally("Sir Lancelot", 15, 1, 25, 1, "Defend the Queen's Honor");
        public static Ally kingArthur = new Ally("King Arthur", 10, 2, 10, 2, null);
        public static Ally sirTristan = new Ally("Sir Tristan", 10, 1, 20, 1, "Queen Iseult");
        public static Ally kingPellinore = new Ally("King Pellinore", 10, 1, 10, 4, "Search for the Questing Beast");
        public static Ally sirGawain = new Ally("Sir Gawain", 10, 1, 20, 1, "Test of the Green Knight");
        public static Ally sirPercival = new Ally("Sir Percival", 5, 1, 20, 1, "Search for the Holy Grail");
        public static Ally queenGuinevere = new Ally("Queen Guinevere", 0, 3, 0, 3, null);
        public static Ally queenIseult = new Ally("Queen Iseult", 0, 2, 0, 4, "Sir Tristan");
        public static Ally merlin = new Ally("Merlin", 0, 1, 0, 1, null);

        //Tests
        public static Test testOfValor = new Test("Test of Valor", 0, 1, 1, null);
        public static Test testOfTemptation = new Test("Test of Temptation", 0, 1, 1, null);
        public static Test testOfMorganLeFey = new Test("Test of Morgan Le Fey", 0, 1, 3, null);
        public static Test testOfQuestingBeast = new Test("Test of the Questing Beast", 0, 1, 4, "Search for the Questing Beast");

        public AdventureDeck()
        {
            CardComparer<AdventureCard> comparer = new CardComparer<AdventureCard>();
            this.DeckList = new Dictionary<AdventureCard, int>(comparer);
            this.currCards = 125;
            this.initialize();
            this.ValidCards = DeckList.Keys.ToList();
        }

        public override void emptyDeck()
        {
            AddCards(discard);
            discard.Clear();
        }

        public int getBP(string name, string[] cards)
        {
            foreach(AdventureCard card in DeckList.Keys)
            {
                if (name == card.Name)
                {
                    return card.getBP(cards);
                }
            }
            return 0;
        }

        public override void initialize()
        {
           
            DeckList[excalibur] = 2;
            DeckList[lance] = 6;
            DeckList[battleAx] = 8;
            DeckList[sword] = 16;
            DeckList[horse] = 11;
            DeckList[dagger] = 6;

            //Foes
            DeckList[dragon] = 1;
            DeckList[giant] = 2;
            DeckList[mordred] = 4;
            DeckList[greenKnight] = 2;
            DeckList[blackKnight] = 3;
            DeckList[evilKnight] = 6;
            DeckList[saxonKnight] = 8;
            DeckList[robberKnight] = 7;
            DeckList[saxons] = 5;
            DeckList[boar] = 4;
            DeckList[thieves] = 8;

            //Tests
            DeckList[testOfValor] = 2;
            DeckList[testOfTemptation] = 2;
            DeckList[testOfMorganLeFey] = 2;
            DeckList[testOfQuestingBeast] = 2;

            //Allies
            DeckList[sirGalahad] = 1;
            DeckList[sirLancelot] = 1;
            DeckList[kingArthur] = 1;
            DeckList[sirTristan] = 1;
            DeckList[kingPellinore] = 1;
            DeckList[sirGawain] = 1;
            DeckList[sirPercival] = 1;
            DeckList[queenGuinevere] = 1;
            DeckList[queenIseult] = 1;
            DeckList[merlin] = 1;

            //~Amour~
            DeckList[amours] = 8;   
        }
        
    }
}

