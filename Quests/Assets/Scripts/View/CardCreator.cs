using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour {

    public static void createAlly(string name, int bp, int bids, int sBP, int sBids, string sQuest)
    {
        GameObject prefab = Object.Instantiate(Resources.Load(name)) as GameObject;
        QuestOTRT.AllyController someCard = prefab.GetComponent<QuestOTRT.AllyController>();
        someCard.initialize(name, bp, bids, sBP, sBids, sQuest);
    }

    public static void createAlly(QuestOTRT.Ally ally)
    {
        GameObject prefab = Object.Instantiate(Resources.Load(ally.Name)) as GameObject;
        QuestOTRT.AllyController someCard = prefab.GetComponent<QuestOTRT.AllyController>();
        someCard.initialize(ally);
    }
}
