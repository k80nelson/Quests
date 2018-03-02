using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class DeckTesting : IPrebuildSetup
{
    QuestOTRT.AdventureDeck adv;
    QuestOTRT.StoryDeck str;

    [SetUp]
    public void Setup()
    {
        this.adv = new QuestOTRT.AdventureDeck();
        this.str = new QuestOTRT.StoryDeck();
    }

    [Test]
    public void TestCount()
    {
        Assert.AreEqual(125, adv.Count);
        Assert.AreEqual(28, str.Count);
    }

    [Test]
    public void testAdvSpecificDraw()
    {
        QuestOTRT.AdventureCard test = adv.draw("Saxons") as QuestOTRT.AdventureCard;
        Assert.AreEqual("Saxons", test.Name);
        Assert.AreEqual(10, test.getBP(new string[] { }));
        Assert.AreEqual(20, test.getBP(new string[] { "Defend the Queen's Honor" }));
    }

    [Test]
    public void testAdvDrawingAll()
    {
        List<QuestOTRT.AdventureCard> temp = new List<QuestOTRT.AdventureCard>();
        int c = adv.Count;
        for (int i=0; i<c; i++)
        {
            temp.Add(adv.draw() as QuestOTRT.AdventureCard);
        }
        Assert.AreEqual(125, temp.Count);
        Assert.AreEqual(0, adv.Count);
        List<QuestOTRT.AdventureCard> swords = temp.FindAll(i => i.Name == "Sword");
        List<QuestOTRT.AdventureCard> thieves = temp.FindAll(i => i.Name == "Thieves");
        List<QuestOTRT.AdventureCard> merlins = temp.FindAll(i => i.Name == "Merlin");
        Assert.AreEqual(16, swords.Count);
        Assert.AreEqual(8, thieves.Count);
        Assert.AreEqual(1, merlins.Count);
    }

    [Test]
    public void testStrDrawingAll()
    {
        List<QuestOTRT.StoryCard> temp = new List<QuestOTRT.StoryCard>();
        int c = str.Count;
        for (int i = 0; i < c; i++)
        {
            temp.Add(str.draw() as QuestOTRT.StoryCard);
        }
        Assert.AreEqual(28, temp.Count);
        Assert.AreEqual(0, str.Count);
    }

    [Test]
    public void testTooManyRemoval()
    {
        int i = 0;
        while(adv.draw("Sword") != null) i++;
        Assert.AreEqual(16, i);
    }

    [Test]
    public void TestListAddingToDeck()
    {
        QuestOTRT.Weapon excalibur = new QuestOTRT.Weapon("Excalibur", 30, 0);
        QuestOTRT.Weapon lance = new QuestOTRT.Weapon("Lance", 20, 0);
        QuestOTRT.Weapon battleAx = new QuestOTRT.Weapon("Battle-Axe", 15, 0);

        List<QuestOTRT.AdventureCard> list = new List<QuestOTRT.AdventureCard> { excalibur, lance, battleAx };

        Assert.AreEqual(2, adv.getNumCard("Excalibur"));
        Assert.AreEqual(6, adv.getNumCard("Lance"));
        Assert.AreEqual(8, adv.getNumCard("Battle-Axe"));

        Assert.True(adv.AddCards(list));

        Assert.AreEqual(3, adv.getNumCard("Excalibur"));
        Assert.AreEqual(7, adv.getNumCard("Lance"));
        Assert.AreEqual(9, adv.getNumCard("Battle-Axe"));
    }

    [Test]
    public void TestDictAddingToDeck()
    {
        QuestOTRT.Weapon excalibur = new QuestOTRT.Weapon("Excalibur", 30, 0);
        QuestOTRT.Weapon lance = new QuestOTRT.Weapon("Lance", 20, 0);
        QuestOTRT.Weapon battleAx = new QuestOTRT.Weapon("Battle-Axe", 15, 0);
        
        Dictionary<QuestOTRT.AdventureCard, int> di = new Dictionary<QuestOTRT.AdventureCard, int>();
        di.Add(excalibur, 4);
        di.Add(lance, 6);
        di.Add(battleAx, 2);

        Assert.AreEqual(2, adv.getNumCard("Excalibur"));
        Assert.AreEqual(6, adv.getNumCard("Lance"));
        Assert.AreEqual(8, adv.getNumCard("Battle-Axe"));

        Assert.True(adv.AddCards(di));

        Assert.AreEqual(6, adv.getNumCard("Excalibur"));
        Assert.AreEqual(12, adv.getNumCard("Lance"));
        Assert.AreEqual(10, adv.getNumCard("Battle-Axe"));
    }

    [Test]
    public void TestShuffleAtEnd()
    {
        List<QuestOTRT.AdventureCard> temp = new List<QuestOTRT.AdventureCard>();
        while (adv.Count > 0)
        {
            temp.Add(adv.draw());
        }
        Assert.AreEqual(0, adv.Count);
        Assert.True(adv.AddCards(temp));
        Assert.AreEqual(125, adv.Count);
        temp = adv.drawAll();
        Assert.AreEqual(0, adv.Count);
        Assert.AreEqual(125, temp.Count);
    }
}