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
        QuestOTRT.AdventureCard test = adv.draw("Saxon") as QuestOTRT.AdventureCard;
        Assert.AreEqual("Saxon", test.Name);
        Assert.AreEqual(10, test.getBP(new string[] { }));
        Assert.AreEqual(20, test.getBP(new string[] { "Defend the Queen's Honor" }));
    }

    [Test]
    public void testDrawingAll()
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
}