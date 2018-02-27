using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public GameObject CardTransform;
    public CardFactory factory;
    public GameObject[] cardPrefabs;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void createCard(QuestOTRT.AdventureCard card)
    {
        GameObject newCard = factory.create(card);
        newCard.transform.SetParent(CardTransform.transform, false);
    }
    public void adjustHand()
    {
        int i = -600;
        foreach (GameObject c in cardPrefabs)
        {
            UnityEngine.Vector3 temp = new UnityEngine.Vector3(0, 0, 0);
            c.transform.position = temp;
            i++;
        }
    }
    

}