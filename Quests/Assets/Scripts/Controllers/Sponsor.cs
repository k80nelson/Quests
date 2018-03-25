using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sponsor : MonoBehaviour {


    public Transform storyCardTransform;
    public GameObject questCard;
    public int stages;

    public GameObject[] stagesObjects;
    public StageModel[] stageModels;

    public GameObject promptBox;
    public Text promptText;

    private void OnEnable()
    {
        if (storyCardTransform.GetChild(0) != null)
        {
            questCard = storyCardTransform.GetChild(0).gameObject;
        }

        stages = questCard.GetComponent<QuestCard>().stages;

        for(int i=0; i<stages; i++)
        {
            stagesObjects[i].SetActive(true);
        }

        stageModels = new StageModel[stages];

        for (int i=0; i<stages; i++)
        {
            stageModels[i] = new StageModel();
        }
    }

    public void promptUser(string message)
    {
        promptText.text = message;
        promptBox.SetActive(true);
    }

    public bool testValid(int id, Draggable d)
    {
        AdventureCard currCard = d.gameObject.GetComponent<AdventureCard>();

        if (currCard.type == AdventureCard.Type.AMOUR || currCard.type == AdventureCard.Type.ALLY) return false;
        List<AdventureCard> currStage = new List<AdventureCard>(stagesObjects[id].GetComponentsInChildren<AdventureCard>());
        if ((currCard.type == AdventureCard.Type.WEAPON) && 
            ((currStage.Find(i => i.type == AdventureCard.Type.TEST) != null) || 
            !(currStage.Find(i => i.type == AdventureCard.Type.FOE) != null) || 
            (currStage.Find(i=>i.Name == currCard.Name) != null))) return false;
        if ((currCard.type == AdventureCard.Type.TEST) && (currStage.Count > 0)) return false;
        if (currStage.Find(i => i.type == AdventureCard.Type.TEST) != null) return false;
        if ((currCard.type == AdventureCard.Type.FOE) && currStage.Find(i => i.type == AdventureCard.Type.FOE) != null) return false;

        return true;
    }
    
    public void End()
    {
        questCard = null;
        stages = 0;

        for (int i = 0; i < stages; i++)
        {
            stagesObjects[i].SetActive(false);
        }
    }
}
