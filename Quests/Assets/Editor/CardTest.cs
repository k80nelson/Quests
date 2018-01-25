using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class CardTest : IPrebuildSetup {

    public Foe foeCard;
    public Ally allyCard;
    public Weapon weaponCard;
    public Amour amourCard;
    public Test testCard;
    public Quest questCard1;
    public Quest questCard2;

    [SetUp]
    public void Setup()
    {
        foeCard = new Foe("Thief", 5, 1, 0, null);
        allyCard = new Ally("Sir Percival", 10, 1, 15, 3, "Quest for the Holy Grail");
        weaponCard = new Weapon("Dagger", 5, 1);
        amourCard = new Amour("Amour", 10, 1);
        testCard = new Test("Test of the Questing Beast", 0, 1, 3, "Search for the Questing Beast");
        questCard1 = new Quest("Quest for the Holy Grail", 3);
        questCard2 = new Quest("Search for the Questing Beast", 3);
    }

    [Test]
    public void TestFoe()
    {
        Assert.AreEqual(expected: "Thief", actual: foeCard.Name);
        Assert.AreEqual(expected: 5, actual: foeCard.getBP(questCard2));
    }

    [Test]
    public void TestAlly()
    {
        Assert.AreEqual(expected: "Sir Percival", actual: allyCard.Name);
        Assert.AreEqual(expected: 10, actual: allyCard.getBP(questCard2));
        Assert.AreEqual(expected: 15, actual: allyCard.getBP(questCard1));
    }

    [Test]
    public void TestWeapon()
    {
        Assert.AreEqual(expected: "Dagger", actual: weaponCard.Name);
        Assert.AreEqual(expected: 5, actual: weaponCard.getBP(questCard2));
    }

    [Test]
    public void TestAmour()
    {
        Assert.AreEqual(expected: "Amour", actual: amourCard.Name);
        Assert.AreEqual(expected: 1, actual: amourCard.getBids(questCard2));
    }

    [Test]
    public void TestTest()
    {
        Assert.AreEqual(expected: "Test of the Questing Beast", actual: testCard.Name);
        Assert.AreEqual(expected: 3, actual: testCard.getBids(questCard2));
        Assert.AreEqual(expected: 1, actual: testCard.getBids(questCard1));
    }
}
