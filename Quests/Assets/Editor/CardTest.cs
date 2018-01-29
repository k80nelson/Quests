using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class CardTest : IPrebuildSetup {

    public QuestOTRT.Foe foeCard;
    public QuestOTRT.Ally allyCard;
    public QuestOTRT.Test testCard;
    public QuestOTRT.Quest questCard1;
    public QuestOTRT.Quest questCard2;

    [SetUp]
    public void Setup()
    {
        foeCard = new QuestOTRT.Foe("Thief", 5, 1, 0, null);
        allyCard = new QuestOTRT.Ally("Sir Percival", 10, 1, 15, 3, "Quest for the Holy Grail");
        testCard = new QuestOTRT.Test("Test of the Questing Beast", 0, 1, 3, "Search for the Questing Beast");
        questCard1 = new QuestOTRT.Quest("Quest for the Holy Grail", 3);
        questCard2 = new QuestOTRT.Quest("Search for the Questing Beast", 3);
    }

    [Test]
    public void TestFoe()
    {
        Assert.AreEqual(expected: "Thief", actual: foeCard.Name);
        Assert.AreEqual(expected: 5, actual: foeCard.getBP(questCard2.Name));
    }

    [Test]
    public void TestAlly()
    {
        Assert.AreEqual(expected: "Sir Percival", actual: allyCard.Name);
        Assert.AreEqual(expected: 10, actual: allyCard.getBP(questCard2.Name));
        Assert.AreEqual(expected: 15, actual: allyCard.getBP(questCard1.Name));
    }

    [Test]
    public void TestTest()
    {
        Assert.AreEqual(expected: "Test of the Questing Beast", actual: testCard.Name);
        Assert.AreEqual(expected: 3, actual: testCard.getBids(questCard2.Name));
        Assert.AreEqual(expected: 1, actual: testCard.getBids(questCard1.Name));
    }
}
