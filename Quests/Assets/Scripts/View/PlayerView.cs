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

}