using System;
using System.Collections;
using System.Collections.Generic;

namespace QuestOTRT
{
    public class AdventureDeck : Deck
    {
        //This should return a card
        public override string draw()
        {
            int index;
            bool check = true;
            string card;
            System.Random rnd = new System.Random();
            {
                while (check)
                {
                    index = rnd.Next(0, 30);

                    int validity = this.DeckAmount.ToList()[index];
                    if (validity > 0)
                    {
                        card = this.DeckList.ToList()[index];
                        check = false;
                        return card;
                        
                    }  

                }
            }
        }

        public override void initialize()
        {
            this.DeckList = new Dictionary<int, string>();
            this.DeckAmount = new Dictionary<int, int>();
            //Weapons
            DeckList.Add(0, "Excalibur");
            DeckList.Add(1, "Lance");
            DeckList.Add(2, "Battle-ax");
            DeckList.Add(3, "Sword");
            DeckList.Add(4, "Horse");
            DeckList.Add(5, "Dagger");

            //Foes
            DeckList.Add(6, "Dragon");
            DeckList.Add(7, "Giant");
            DeckList.Add(8, "Mordred");
            DeckList.Add(9, "Green Knight");
            DeckList.Add(10, "Black Knight");
            DeckList.Add(11, "Evil Knight");
            DeckList.Add(12, "Saxon Knight");
            DeckList.Add(13, "Robber Knight");
            DeckList.Add(14, "Saxons");
            DeckList.Add(15, "Boar");
            DeckList.Add(16, "Thieves");

            //Tests
            DeckList.Add(17, "Test of Valor");
            DeckList.Add(18, "Test of Temptation");
            DeckList.Add(19, "Test of Morgan Le Fey");
            DeckList.Add(20, "Test of the Questing Beast");

            //Allies
            DeckList.Add(21, "Sir Galahad");
            DeckList.Add(22, "Sir Lancelot");
            DeckList.Add(23, "King Arthur");
            DeckList.Add(24, "Sir Tristan");
            DeckList.Add(25, "Sir Pellinore");
            DeckList.Add(26, "Sir Gawain");
            DeckList.Add(27, "Sir Percival");
            DeckList.Add(28, "Queen Guinevere");
            DeckList.Add(29, "Queen Iseult");
            DeckList.Add(30, "Merlin");

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
        }
    }
}

