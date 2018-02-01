using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CardTesting : IPrebuildSetup{
    private QuestOTRT.Foe foeCard;
    private QuestOTRT.Ally allyCard;
    private QuestOTRT.Test testCard;
    private QuestOTRT.Quest quest1;
    private QuestOTRT.Quest quest2;

	[SetUp]
    public void Setup()
    {
        this.foeCard = new QuestOTRT.Foe("Thief", 5, 1, 10, new string[] { "Quest for the Holy Grail" });
        this.allyCard = new QuestOTRT.Ally("Sir Percival", 10, 1, 15, 3, "Quest for the Holy Grail");
        this.testCard = new QuestOTRT.Test("Test of the Questing Beast", 0, 1, 3, "Search for the Questing Beast");
        this.quest1 = new QuestOTRT.Quest("Search for the Questing Beast", 3);
        this.quest2 = new QuestOTRT.Quest("Quest for the Holy Grail", 4);

    }

    [Test]
    public void foeBPTest()
    {
        Assert.AreEqual("Thief", this.foeCard.Name);
        Assert.AreEqual(5, foeCard.getBP(new string[] { quest1.Name }));
        Assert.AreEqual(10, foeCard.getBP(new string[] { quest2.Name }));
        Assert.AreEqual(10, foeCard.getBP(new string[] { quest1.Name, "Defend the Queen's Honor"}));
    }

    [Test]
    public void allyBPTest()
    {
        Assert.AreEqual("Sir Percival", this.allyCard.Name);
        Assert.AreEqual(10, allyCard.getBP(new string[] { quest1.Name }));
        Assert.AreEqual(15, allyCard.getBP(new string[] { quest2.Name }));
        Assert.AreEqual(10, allyCard.getBP(new string[] { quest1.Name, "Defend the Queen's Honor" }));
    }
    [Test]
    public void allyBidsTest()
    {
        Assert.AreEqual("Sir Percival", this.allyCard.Name);
        Assert.AreEqual(1, allyCard.getBids(new string[] { quest1.Name }));
        Assert.AreEqual(3, allyCard.getBids(new string[] { quest2.Name }));
        Assert.AreEqual(1, allyCard.getBids(new string[] { quest1.Name, "Defend the Queen's Honor" }));
    }

    [Test]
    public void testBidsTest()
    {
        Assert.AreEqual("Test of the Questing Beast", this.testCard.Name);
        Assert.AreEqual(3, testCard.getBids(new string[] { quest1.Name }));
        Assert.AreEqual(1, testCard.getBids(new string[] { quest2.Name }));
        Assert.AreEqual(3, testCard.getBids(new string[] { quest1.Name, "Defend the Queen's Honor" }));
        Assert.AreEqual(0, testCard.getBP(new string[] { quest2.Name }));
    }
}
