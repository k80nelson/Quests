using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuestOTRT
{
    public class AdventureDeck : Deck
    {
        System.Random rnd = new System.Random();
        public AdventureDeck()
        {
            this.initialize();
        }
        //This should return a card
        public override QuestOTRT.Card draw()
        {
            QuestOTRT.Card card;
            int index = -1;
            while (true)
            {
                index = -1;
                index = rnd.Next(0, 31);
                Console.WriteLine("rndInt: " + index + " ");
                
                int validity = this.DeckAmount[index];//.ToList()[index];
                Console.WriteLine("Validity is " + validity);
                if (validity > 0)
                {
                    card = this.DeckList[index];//.ToList()[index];
                    return card;
                }
                else
                {
                    Console.Write("The Validity of the card failed");
                }
            }
        }

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
            QuestOTRT.Foe dragon = new QuestOTRT.Foe("Dragon", 50, 0, 70, "");
            QuestOTRT.Foe giant = new QuestOTRT.Foe("Giant", 40, 0, 0, "");
            QuestOTRT.Foe mordred = new QuestOTRT.Foe("Mordred", 30, 0, 0, "Use as a Foe or sacrifice at any time to remove any player's Ally from play");
            QuestOTRT.Foe greenKnight = new QuestOTRT.Foe("Green Knight", 25, 0, 40, "");
            QuestOTRT.Foe blackKnight = new QuestOTRT.Foe("Black Knight", 25, 0, 35, "");
            QuestOTRT.Foe evilKnight = new QuestOTRT.Foe("Evil Knight", 20, 0, 30, "");
            QuestOTRT.Foe saxonKnight = new QuestOTRT.Foe("Saxon Knight", 15, 0, 25, "");
            QuestOTRT.Foe robberKnight = new QuestOTRT.Foe("Robber Knight", 15, 0, 0, "");
            QuestOTRT.Foe saxons = new QuestOTRT.Foe("Saxon", 10, 0, 20, "");
            QuestOTRT.Foe boar = new QuestOTRT.Foe("Boar", 5, 0, 15, "");
            QuestOTRT.Foe thieves = new QuestOTRT.Foe("Thieves", 5, 0, 0, "");
            
            //Amour
            QuestOTRT.Amour amours = new QuestOTRT.Amour("Amours", 10, 1);
            
            //Allies
            QuestOTRT.Ally sirGalahad = new QuestOTRT.Ally("Sir Galahad", 15, 0, 0, 0, "");
            QuestOTRT.Ally sirLancelot = new QuestOTRT.Ally("Sir Lancelot", 15, 0, 25, 0, "+25 when on the Quest to Defend the Queen's Honor");
            QuestOTRT.Ally kingArthur = new QuestOTRT.Ally("King Arthur", 10, 2, 0, 0, "");
            QuestOTRT.Ally sirTristan = new QuestOTRT.Ally("Sir Tristan", 10, 0, 20, 0, "+20 When Queen Iseult is in play");
            QuestOTRT.Ally kingPellinore = new QuestOTRT.Ally("Sir Pellinore", 10, 0, 0, 4, "4 Bids on the Search for the Questing Beast Quest");
            QuestOTRT.Ally sirGawain = new QuestOTRT.Ally("Sir Gawain", 10, 0, 20, 0, "+20 on the Test of the Green Knight Quest");
            QuestOTRT.Ally sirPercival = new QuestOTRT.Ally("Sir Percival", 5, 0, 20, 0, "+20 on the Search for the Holy Grail Quest");
            QuestOTRT.Ally queenGuinevere = new QuestOTRT.Ally("Queen Gunevere", 0, 3, 0, 0, "");
            QuestOTRT.Ally queenIseult = new QuestOTRT.Ally("Queen Iseult", 0, 2, 0, 4, "4 Bids when Tristan is in play");
            QuestOTRT.Ally merlin = new QuestOTRT.Ally("Merlin", 0, 0, 0, 0, "Player may preview any one stage per Quest");
            //QuestOTRT.Ally sirPellinore = new QuestOTRT.Ally("King Pellinore", 10, 0, 0, 4, "4 Bids on the Search for the Questing Beast Quest");

            //Tests
            QuestOTRT.Test testOfValor = new QuestOTRT.Test("Test of Valor", 0, 1, 0, "");
            QuestOTRT.Test testOfTemptation = new QuestOTRT.Test("Test of Temptation", 0, 1, 0, "");
            QuestOTRT.Test testOfMorganLeFey = new QuestOTRT.Test("Test of Morgan Le Fey", 0, 1, 3, "Minimum 3 Bid");
            QuestOTRT.Test testOfQuestingBeast = new QuestOTRT.Test("Test of the Questing Beast", 0, 1, 4, "Minimum 4 Bid on the Search for the Questing Beast Quest");

            this.DeckList = new Dictionary<int, QuestOTRT.Card>();
            this.DeckAmount = new Dictionary<int, int>();
            //Weapons
            DeckList.Add(0, excalibur);
            DeckList.Add(1, lance);
            DeckList.Add(2, battleAx);
            DeckList.Add(3, sword);
            DeckList.Add(4, horse);
            DeckList.Add(5, dagger);

            //Foes
            DeckList.Add(6, dragon);
            DeckList.Add(7, giant);
            DeckList.Add(8, mordred);
            DeckList.Add(9, greenKnight);
            DeckList.Add(10, blackKnight);
            DeckList.Add(11, evilKnight);
            DeckList.Add(12, saxonKnight);
            DeckList.Add(13, robberKnight);
            DeckList.Add(14, saxons);
            DeckList.Add(15, boar);
            DeckList.Add(16, thieves);

            //Tests
            DeckList.Add(17, testOfValor);
            DeckList.Add(18, testOfTemptation);
            DeckList.Add(19, testOfMorganLeFey);
            DeckList.Add(20, testOfQuestingBeast);

            //Allies
            DeckList.Add(21, sirGalahad);
            DeckList.Add(22, sirLancelot);
            DeckList.Add(23, kingArthur);
            DeckList.Add(24, sirTristan);
            DeckList.Add(25, kingPellinore);
            DeckList.Add(26, sirGawain);
            DeckList.Add(27, sirPercival);
            DeckList.Add(28, queenGuinevere);
            DeckList.Add(29, queenIseult);
            DeckList.Add(30, merlin);

            //Amours
            DeckList.Add(31, amours);

            //Adding the amounts of each card to the Dictionary
            //Weapons
            DeckAmount.Add(0, 2);
            DeckAmount.Add(1, 6);
            DeckAmount.Add(2, 8);
            DeckAmount.Add(3, 16);
            DeckAmount.Add(4, 11);
            DeckAmount.Add(5, 6);

            //Foes
            DeckAmount.Add(6, 1);
            DeckAmount.Add(7, 2);
            DeckAmount.Add(8, 4);
            DeckAmount.Add(9, 2);
            DeckAmount.Add(10, 3);
            DeckAmount.Add(11, 6);
            DeckAmount.Add(12, 8);
            DeckAmount.Add(13, 7);
            DeckAmount.Add(14, 5);
            DeckAmount.Add(15, 4);
            DeckAmount.Add(16, 8);

            //Tests
            DeckAmount.Add(17, 2);
            DeckAmount.Add(18, 2);
            DeckAmount.Add(19, 2);
            DeckAmount.Add(20, 2);

            //Allies
            DeckAmount.Add(21, 1);
            DeckAmount.Add(22, 1);
            DeckAmount.Add(23, 1);
            DeckAmount.Add(24, 1);
            DeckAmount.Add(25, 1);
            DeckAmount.Add(26, 1);
            DeckAmount.Add(27, 1);
            DeckAmount.Add(28, 1);
            DeckAmount.Add(29, 1);
            DeckAmount.Add(30, 1);
            DeckAmount.Add(31, 8);
        }
    }
}

