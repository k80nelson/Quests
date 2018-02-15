using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class PlayerTesting : IPrebuildSetup
{
    public QuestOTRT.Player player1;
    public QuestOTRT.Player player2;
    public List<QuestOTRT.AdventureCard> cards;
    public List<QuestOTRT.Ally> allies;
    public QuestOTRT.Ally Testally;

    [SetUp]
    public void Setup()
    {
        player1 = new QuestOTRT.Player();

        Testally = new QuestOTRT.Ally("Testing", 10, 1, 10, 2, "None");
        cards = new List<QuestOTRT.AdventureCard>
        {
            new QuestOTRT.Ally("Ally", 10, 1, 10, 2, "None"),
            new QuestOTRT.Foe("Foe", 10, 11, 21, new string[]{"Hello"}),
        };

        allies = new List<QuestOTRT.Ally>
        {
            Testally,
            new QuestOTRT.Ally("Test", 10, 1, 10, 2, "None"),
            new QuestOTRT.Ally("Ally", 10, 1, 10, 2, "None")
        };

        QuestOTRT.Hand hand = new QuestOTRT.Hand(3, cards);
        player2 = new QuestOTRT.Player(5, 5, 0, hand, allies);
        
    }

    [Test]
    public void TestValues()
    {
        Assert.AreEqual(0, player1.Shields);
        Assert.AreEqual(5, player2.Shields);
        Assert.AreEqual(5, player1.BP);
        Assert.AreEqual(5, player2.BP);
        Assert.True(player1.getCards().Count == 0);
        Assert.True(player2.getCards().TrueForAll(i => this.cards.Contains(i)));
        Assert.True(player1.getAllies().Count == 0);
        Assert.True(player2.getAllies().TrueForAll(i => this.allies.Contains(i)));
    }

    [Test]
    public void TestAddAlly()
    {
        player1.addAlly(Testally);
        Assert.Contains(Testally, player1.getAllies());
    }

    [Test]
    public void TestRemoveAllyByName()
    {
        Assert.Contains(Testally, player2.getAllies());
        player2.removeAlly(Testally.Name);
        Assert.False(player2.getAllies().Contains(Testally));
    }

    [Test]
    public void TestRemoveAllyByCard()
    {
        Assert.Contains(Testally, player2.getAllies());
        player2.removeAlly(Testally);
        Assert.False(player2.getAllies().Contains(Testally));
    }

    [Test]
    public void testAddCard()
    {
        QuestOTRT.Weapon newCard = new QuestOTRT.Weapon("Excalibur", 10, 1);
        player2.addCard(newCard);
        Assert.Contains(newCard, player2.getCards());
    }

    [Test]
    public void testAddTooManyCards()
    {
        QuestOTRT.Weapon newCard = new QuestOTRT.Weapon("Excalibur", 10, 1);
        player2.addCard(newCard);
        QuestOTRT.Test newTest = new QuestOTRT.Test("some", 23, 23, 23, "BODY");
        player2.addCard(newTest);
        Assert.AreEqual(4, player2.getCards().Count);
    }
    
    [Test]
    public void testRemoveCardsByCard()
    {
        QuestOTRT.Weapon newCard = new QuestOTRT.Weapon("Excalibur", 10, 1);
        player2.addCard(newCard);
        Assert.Contains(newCard, player2.getCards());
        player2.removeCard(newCard);
        Assert.False(player2.getCards().Contains(newCard));
    }

    [Test]
    public void testRemoveCardsByName()
    {
        QuestOTRT.Weapon newCard = new QuestOTRT.Weapon("Excalibur", 10, 1);
        player2.addCard(newCard);
        Assert.Contains(newCard, player2.getCards());
        player2.removeCard(newCard.Name);
        Assert.False(player2.getCards().Contains(newCard));
    }

    [Test]
    public void testRemoveOneCardOfTwo()
    {
        QuestOTRT.Weapon newCard = new QuestOTRT.Weapon("Excalibur", 10, 1);
        player2.addCard(newCard);
        player2.addCard(newCard);
        Assert.Contains(newCard, player2.getCards());
        player2.removeCard(newCard.Name);
        Assert.True(player2.getCards().Contains(newCard));
        player2.removeCard(newCard.Name);
        Assert.False(player2.getCards().Contains(newCard));
    }

    [Test]
    public void testRanks()
    {
        Assert.AreEqual(QuestOTRT.Rank.Squire, player1.getRank());
        Assert.AreEqual(QuestOTRT.Rank.Squire, player2.getRank());
    }

    [Test]
    public void testSuccessRankUp()
    {
        Assert.True(player2.rankUp());
        Assert.AreEqual(0, player2.Shields);
        Assert.AreEqual(10, player2.BP);
        Assert.AreEqual(QuestOTRT.Rank.Knight, player2.getRank());
    }

    [Test]
    public void testFailRankUp()
    {
        Assert.False(player1.rankUp());
    }

    [Test]
    public void testAddShields()
    {
        Assert.AreEqual(0, player1.Shields);
        player1.addShields(2);
        Assert.AreEqual(2, player1.Shields);
    }
}
