using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiddingView : GameElement {
    
    public Transform testCardParent;
    public Text stageText;

    public void setEncounterText(int stage)
    {
        stageText.text = "Stage " + stage;
    }

    public void setEncounterCard(Transform card)
    {
        card.SetParent(testCardParent);
        card.localScale = new Vector3(1, 1, 1);
        card.localPosition = new Vector3(1, 1, 1);
    }
    
}
