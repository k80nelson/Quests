using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public GameObject CardTransform;
    public CardFactory factory;

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
        int i = 0;
        UnityEngine.Vector3 tempScale = new UnityEngine.Vector3(0.5f, 0.5f, 0.5f);
        UnityEngine.Vector3 tempSize;
        foreach(Transform child in CardTransform.transform)
        {
            tempSize = new UnityEngine.Vector3(900-(i*75), 100, 0);
            child.position = tempSize;
            child.localScale = tempScale;
            i++;
        }
    }
    

}