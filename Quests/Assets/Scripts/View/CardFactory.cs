using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour {

    public void create(QuestOTRT.AdventureCard card)
    {
        if (card is QuestOTRT.Ally) GetComponent<AllyCreator>().create(card as QuestOTRT.Ally);
        if (card is QuestOTRT.Amour) GetComponent<AmourCreator>().create(card as QuestOTRT.Amour);
    }


}
