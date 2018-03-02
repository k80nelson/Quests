using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class PlayerView : MonoBehaviour
{
    public GameObject CardTransform;
    public GameObject UI;
    public CardFactory factory;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setViewOn()
    {
        UI.SetActive(true);
    }

    public void setViewOff()
    {
        UI.SetActive(false);
    }

    public void createCard(QuestOTRT.AdventureCard card)
    {
        GameObject newCard = factory.create(card);
        
        int sum = 0;
        foreach (Transform child in CardTransform.transform)
        {
            if (child.name.Contains(newCard.name))
            {
                sum += 1;
            }
        }
        newCard.name += " " + sum;
        newCard.transform.SetParent(CardTransform.transform, false);
        
    }

    public void removeCard(QuestOTRT.AdventureCard card)
    {
        foreach(Transform child in CardTransform.transform)
        {
            if (child.name == card.Name)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }

    public void removeCard(string name)
    {
        foreach (Transform child in CardTransform.transform)
        {
            if (child.name == name)
            {
                Destroy(child.gameObject);
                break;
            }
        }

    }

    public void adjustHand()
    {
        int i = 0;
        UnityEngine.Vector3 tempScale = new UnityEngine.Vector3(0.5f, 0.5f, 0.5f);
        UnityEngine.Vector3 tempSize;
        foreach(Transform child in CardTransform.transform)
        {
            if (i < 10)
            {
                tempSize = new UnityEngine.Vector3(1050 - (i * 75), 80, 0);
            }
            else
            {
                tempSize = new UnityEngine.Vector3(1050 - ((i-10) * 75), 180, 0);
            }
            child.position = tempSize;
            child.localScale = tempScale;
            i++;
        }
    }
    

}