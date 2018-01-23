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

    [SetUp]
    public void Setup()
    {
        foeCard = new Foe("Thief", 5, 1, 0, null);
        allyCard = new Ally("Sir Percival", 10, 1, 15, 3, "Quest for the Holy Grail");
        weaponCard = new Weapon("Dagger", 5, 1);
        amourCard = new Amour("Amour", 10, 1);
        testCard = new Test("Test of the Questing Beast", 0, 1, 3, "Search for the Questing Beast");
    }

    [Test]
    public void TestFoe()
    {
        Assert.AreEqual(expected: "Thief", actual: foeCard.Name);
        Assert.False(foeCard.hasSpecial());
    }

    [Test]
    public void TestAlly()
    {
        Assert.AreEqual(expected: "Sir Percival", actual: allyCard.Name);
        Assert.True(allyCard.hasSpecial());
        if (allyCard.hasSpecial()) Assert.AreEqual(expected: 15, actual: allyCard.SpecialBP);
    }

    [Test]
    public void TestWeapon()
    {
        Assert.AreEqual(expected: "Dagger", actual: weaponCard.Name);
        Assert.AreEqual(expected: 5, actual: weaponCard.BP);
    }

    [Test]
    public void TestAmour()
    {
        Assert.AreEqual(expected: "Amour", actual: amourCard.Name);
        Assert.AreEqual(expected: 1, actual: amourCard.Bids);
    }

    [Test]
    public void TestTest()
    {
        Assert.AreEqual(expected: "Test of the Questing Beast", actual: testCard.Name);
        Assert.True(testCard.hasSpecial());
        if (testCard.hasSpecial()) Assert.AreEqual(expected: 3, actual: testCard.SpecialBids);
    }
}
