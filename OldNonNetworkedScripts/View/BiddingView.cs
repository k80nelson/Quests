﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiddingView : GameElement {
    
    public Transform testCardParent;
    public Text stageText;
    public Text bidText;

    public void setEncounterText(int stage)
    {
        stageText.text = "Stage " + stage;
    }

    public void setBidText(int num)
    {
        bidText.text = "Minimum bid: " + num;
    }

    public void setEncounterCard(Transform card)
    {
        foreach(Transform child in testCardParent)
        {
            Destroy(child.gameObject);
        }
        card.SetParent(testCardParent);
        card.localScale = new Vector3(1, 1, 1);
        card.localPosition = new Vector3(1, 1, 1);
    }
    
}
