using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{

    public class Deck
    {
        public Deck()
        {
        }


        public void initialize()
        {
            //The index is the int, lists the weapons, then foes, then tests, then allies
            Dictionary<int, string> AdventureDeckList = new Dictionary<int, string>();

            //Index is the same as the other dictionary, second into represents the number of that kind of cards left
            Dictionary<int, int> AdventureDeckAmount = new Dictionary<int, int>();


            //Weapons
            AdventureDeckList.Add(0, "Excalibur");
            AdventureDeckList.Add(1, "Lance");
            AdventureDeckList.Add(2, "Battle-ax");
            AdventureDeckList.Add(3, "Sword");
            AdventureDeckList.Add(4, "Horse");
            AdventureDeckList.Add(5, "Dagger");

            //Foes
            AdventureDeckList.Add(6, "Dragon");
            AdventureDeckList.Add(7, "Giant");
            AdventureDeckList.Add(8, "Mordred");
            AdventureDeckList.Add(9, "Green Knight");
            AdventureDeckList.Add(10, "Black Knight");
            AdventureDeckList.Add(11, "Evil Knight");
            AdventureDeckList.Add(12, "Saxon Knight");
            AdventureDeckList.Add(13, "Robber Knight");
            AdventureDeckList.Add(14, "Saxons");
            AdventureDeckList.Add(15, "Boar");
            AdventureDeckList.Add(16, "Thieves");

            //Tests
            AdventureDeckList.Add(17, "Test of Valor");
            AdventureDeckList.Add(18, "Test of Temptation");
            AdventureDeckList.Add(19, "Test of Morgan Le Fey");
            AdventureDeckList.Add(20, "Test of the Questing Beast");

            //Allies
            AdventureDeckList.Add(21, "Sir Galahad");
            AdventureDeckList.Add(22, "Sir Lancelot");
            AdventureDeckList.Add(23, "King Arthur");
            AdventureDeckList.Add(24, "Sir Tristan");
            AdventureDeckList.Add(25, "Sir Pellinore");
            AdventureDeckList.Add(26, "Sir Gawain");
            AdventureDeckList.Add(27, "Sir Percival");
            AdventureDeckList.Add(28, "Queen Guinevere");
            AdventureDeckList.Add(29, "Queen Iseult");
            AdventureDeckList.Add(30, "Merlin");

            //Adding the amounts of each card to the Dictionary
            //Weapons
            AdventureDeckAmount.Add(0, 2);
            AdventureDeckAmount.Add(1, 6);
            AdventureDeckAmount.Add(2, 8);
            AdventureDeckAmount.Add(3, 16);
            AdventureDeckAmount.Add(4, 11);
            AdventureDeckAmount.Add(5, 6);

            //Foes
            AdventureDeckAmount.Add(6, 1);
            AdventureDeckAmount.Add(7, 2);
            AdventureDeckAmount.Add(8, 4);
            AdventureDeckAmount.Add(9, 2);
            AdventureDeckAmount.Add(10, 3);
            AdventureDeckAmount.Add(11, 6);
            AdventureDeckAmount.Add(12, 8);
            AdventureDeckAmount.Add(13, 7);
            AdventureDeckAmount.Add(14, 5);
            AdventureDeckAmount.Add(15, 4);
            AdventureDeckAmount.Add(16, 8);

            //Tests
            AdventureDeckAmount.Add(17, 2);
            AdventureDeckAmount.Add(18, 2);
            AdventureDeckAmount.Add(19, 2);
            AdventureDeckAmount.Add(20, 2);

            //Allies
            AdventureDeckAmount.Add(21, 1);
            AdventureDeckAmount.Add(22, 1);
            AdventureDeckAmount.Add(23, 1);
            AdventureDeckAmount.Add(24, 1);
            AdventureDeckAmount.Add(25, 1);
            AdventureDeckAmount.Add(26, 1);
            AdventureDeckAmount.Add(27, 1);
            AdventureDeckAmount.Add(28, 1);
            AdventureDeckAmount.Add(29, 1);
            AdventureDeckAmount.Add(30, 1);

            
            //The index is the int, lists the Quests, then Tournaments, then Events
            Dictionary<int, string> StoryDeckList = new Dictionary<int, string>();

            //Index is the same as the other dictionary, second into represents the number of that kind of cards left
            Dictionary<int, int> StoryDeckAmount = new Dictionary<int, int>();

            //Quests
            StoryDeckList.Add(0, "Search for the Holy Grail");
            StoryDeckList.Add(1, "Test of the Green Knight");
            StoryDeckList.Add(2, "Search for the Questing Beast");
            StoryDeckList.Add(3, "Defend the Queen's Honor");
            StoryDeckList.Add(4, "Rescue the Fair Maiden");
            StoryDeckList.Add(5, "Journey Through the Enchanted Forest");
            StoryDeckList.Add(6, "Vanquish King Arthur's Enemies");
            StoryDeckList.Add(7, "Slay the Dragon");
            StoryDeckList.Add(8, "Boar Hunt");
            StoryDeckList.Add(9, "Repel the Saxon Raiders");

            //Tournaments
            StoryDeckList.Add(10, "Tournament at Camelot");
            StoryDeckList.Add(11, "Tournament at Orkney");
            StoryDeckList.Add(12, "Tournament at Tintagel");
            StoryDeckList.Add(13, "Tournament at York");

            //Events
            StoryDeckList.Add(14, "King's Recognition");
            StoryDeckList.Add(15, "Queen's Favor");
            StoryDeckList.Add(16, "Court Called to Camelot");
            StoryDeckList.Add(17, "Pox");
            StoryDeckList.Add(18, "Plague");
            StoryDeckList.Add(19, "Chivalrous Deed");
            StoryDeckList.Add(20, "Properity Throughout the Realm");
            StoryDeckList.Add(21, "King's Call to Arms");

            //Adding the amounts of each card to the Dictionary
            //Quests
            StoryDeckAmount.Add(0, 1);
            StoryDeckAmount.Add(1, 1);
            StoryDeckAmount.Add(2, 1);
            StoryDeckAmount.Add(3, 1);
            StoryDeckAmount.Add(4, 1);
            StoryDeckAmount.Add(5, 1);
            StoryDeckAmount.Add(6, 2);
            StoryDeckAmount.Add(7, 1);
            StoryDeckAmount.Add(8, 2);
            StoryDeckAmount.Add(9, 2);

            //Tournaments
            StoryDeckAmount.Add(10, 1);
            StoryDeckAmount.Add(11, 1);
            StoryDeckAmount.Add(12, 1);
            StoryDeckAmount.Add(13, 1);

            //Events
            StoryDeckAmount.Add(14, 2);
            StoryDeckAmount.Add(15, 2);
            StoryDeckAmount.Add(16, 2);
            StoryDeckAmount.Add(17, 1);
            StoryDeckAmount.Add(18, 1);
            StoryDeckAmount.Add(19, 1);
            StoryDeckAmount.Add(20, 1);
            StoryDeckAmount.Add(21, 1);


            //Rank Deck, probably un-needed but I included it anyway
            Dictionary<int, string> RankDeckList = new Dictionary<int, string>();

            //Disctionary that holds same key as the other one but the value holds the number of that card remaining
            Dictionary<int, int> RankDeckAmount = new Dictionary<int, int>();

            RankDeckList.Add(0, "Squire");
            RankDeckList.Add(1, "Knight");
            RankDeckList.Add(2, "Champion Knight");

            RankDeckAmount.Add(0, 4);
            RankDeckAmount.Add(1, 4);
            RankDeckAmount.Add(2, 4);
        }
    }
}
