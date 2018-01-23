using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class CardTest : IPrebuildSetup {

    public Foe card;

    [SetUp]
    public void Setup()
    {
        card = new Foe("Hello", 10, 1, 20, "Beast");
    }

    [Test]
    public void Test()
    {
        Assert.AreEqual(expected: "Hello", actual: card.Name);
        Assert.AreNotEqual(expected: "World", actual: card.Name);
    }
}
