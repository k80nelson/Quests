using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sponsor : GameElement {
    

    public Transform storyCardTransform;
    public GameObject questCard;
    public static int stages;
            
    public GameObject[] stagesObjects;
    public Transform[] stagesTransforms;
    public static StageModel[] stageModels;
            
    public GameObject promptBox;
    public Text promptText;

    bool testFlag = false;

    public GameObject[] questStagesObjects;

private void OnEnable()
    {
        Debug.Log("[Sponsor.cs:OnEnable] Initializing Sponsor"); 

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

        Debug.Log("[Sponsor.cs:OnEnable] Initialization complete");
    }

    public void promptUser(string message)
    {
        promptText.text = message;
        promptBox.SetActive(true);
    }

    public bool testValid(int id, Draggable d)
    {
        testFlag = false;

        AdventureCard currCard = d.gameObject.GetComponent<AdventureCard>();

        if (currCard.type == AdventureCard.Type.AMOUR || currCard.type == AdventureCard.Type.ALLY) return false;

        List<AdventureCard> currStage = new List<AdventureCard>(stagesTransforms[id].GetComponentsInChildren<AdventureCard>());

        if (currStage.Find(i => i.type == AdventureCard.Type.TEST) != null) return false;

        if ((currCard.type == AdventureCard.Type.FOE) && currStage.Find(i => i.type == AdventureCard.Type.FOE) != null) return false;

        if ((currCard.type == AdventureCard.Type.WEAPON) && 
            ((currStage.Find(i => i.type == AdventureCard.Type.TEST) != null) || 
            !(currStage.Find(i => i.type == AdventureCard.Type.FOE) != null) || 
            (currStage.Find(i=>i.Name == currCard.Name) != null))) return false;

        //This nested for loop is to check if there is a test already in play
        for (int i = 0; i < stages; i++)
        {
            List<AdventureCard> testStage = new List<AdventureCard>(stagesObjects[i].GetComponentsInChildren<AdventureCard>());
            for(int j = 0; j<testStage.Count; j++)
            {
                if (testStage[j].type == AdventureCard.Type.TEST)
                {
                    testFlag = true;
                }
            }
        }

        if ((currCard.type == AdventureCard.Type.TEST) && ((currStage.Count > 0) || testFlag)) return false;

        
        return true;
    }

    public bool validateStages()
    {
        Debug.Log("[Sponsor.cs:validateStages] Validating stage setup");
        bool valid = true;

        int currentStageBP = 0;
        int lastStageBP = -1;

        for (int i = 0; i < stages; i++)
        {
            Debug.Log("[Sponsor.cs:validateStages] Validating stage " + (i+1));
            if (!stageModels[i].validState())
            {
                Debug.Log("[Sponsor.cs:validateStages] Error in stage " + (i+1)+": not in valid state");
                promptUser("Stage "+ (i+1) + " is in an invalid state. Weapons can only be placed with a Foe.");
                valid = false;
                break;
            }

            if (stageModels[i].containsTest()) continue;

            currentStageBP = stageModels[i].totalBP();

            if (currentStageBP <= lastStageBP)
            {
                Debug.Log("[Sponsor.cs:validateStages] Error in stage " + (i + 1)+ ": stage not greater than stage" + i);
                promptUser("Stage " + (i + 1) + " contains equal or less BP than stage " + i + ".");
                valid = false;
            }
            else lastStageBP = currentStageBP;
        }
        
       if (!valid)
       {
            Debug.Log("[Sponsor.cs:validateStages] Stage validation failed");
            for (int i=0; i<stages; i++)
            {
                stageModels[i].RemoveAll();
            }
       }
        return valid;
    }

    public void End()
    {
        
        for(int i=0; i<stages; i++)
        {
            List<AdventureCard> tmp = new List<AdventureCard>(stagesTransforms[i].GetComponentsInChildren<AdventureCard>());
            stageModels[i].addList(tmp);
        }
        
        if (validateStages())
        {
            Debug.Log("[Sponsor.cs:end] Validation passed");
            List<AdventureCard> allCards = new List<AdventureCard>();
            SetupModel sponsorship = new SetupModel();
            for (int i = 0; i < stages; i++)
            {
                allCards.AddRange(stageModels[i].cardsPlayed);
                int numcards = stagesTransforms[i].childCount;
                for (int j=0; j<numcards; j++)
                {
                    stagesTransforms[i].GetChild(0).SetParent(questStagesObjects[i].transform);
                }
                stagesObjects[i].SetActive(false);
                sponsorship.Add(stageModels[i]);
            }

            Debug.Log("[Sponsor.cs:end] Removing sponsor's played cards");
            game.players[game.currPlayer].GetComponent<PlayerController>().removeCards(allCards);
            game.storeSponsors(sponsorship);

            questCard = null;
            stages = 0;

            Debug.Log("[Sponsor.cs:end] Sponsorship complete");
            game.view.EndSponsor();
            game.PromptQuest();
            game.setNextPlayer();

        }
    }
}
