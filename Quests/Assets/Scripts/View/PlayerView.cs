using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public GameObject CardTransform;
    public CardFactory factory;
    public List<GameObject> cardPrefabs;

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
        cardPrefabs.Add(newCard);
    }
    public void adjustHand()
    {
        int i = 0;
        UnityEngine.Vector3 tempScale = new UnityEngine.Vector3(0.5f, 0.5f, 0.5f);
        UnityEngine.Vector3 tempSize;
        foreach (GameObject c in cardPrefabs)
        {
            tempSize = new UnityEngine.Vector3(900-(i*75), 100, 0);
            c.transform.position = tempSize;
            c.transform.localScale = tempScale;
            i++;
        }
    }
    

}