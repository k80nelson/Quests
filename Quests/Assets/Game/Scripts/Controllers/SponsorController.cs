using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SponsorController : MonoBehaviour
{
    [SerializeField] GameObject StagePrefab;
    [SerializeField] Transform stageSpawnPos;
    [SerializeField] GameObject UI;

    QuestCard currCard;
    NetPlayerController sponsor;
    List<Transform> stages = new List<Transform>();
    List<StageModel> stageModels = new List<StageModel>();

    public void Init(int cardIndex)
    {
        UI.SetActive(true);
        currCard = GameManager.instance.dict.findCard(cardIndex) as QuestCard;
        for (int i=0; i<currCard.stages; i++)
        {
            GameObject newObj = Instantiate(StagePrefab, stageSpawnPos);
            stages.Add(newObj.GetComponent<SponsorDropZone>().CardContainer);
            newObj.GetComponentInChildren<Text>().text = "Stage " + (i + 1);
        }
        List<StageModel> stageModels = new List<StageModel>(currCard.stages);
    }

    bool validateStages()
    {
        bool valid = true;

        int currentStageBP = 0;
        int lastStageBP = -1;

        for (int i = 0; i < stages.Count; i++)
        {
            if (!stageModels[i].validState())
            {
                Debug.Log("[Sponsor.cs:validateStages] Error in stage " + (i + 1) + ": not in valid state");
                PromptHandler.instance.localPrompt("Sponsorship","Stage " + (i + 1) + " is in an invalid state. Weapons can only be placed with a Foe.");
                valid = false;
                break;
            }

            if (stageModels[i].containsTest()) continue;

            currentStageBP = stageModels[i].totalBP();

            if (currentStageBP <= lastStageBP)
            {
                PromptHandler.instance.localPrompt("Sponsorship", "Stage " + (i + 1) + " contains equal or less BP than stage " + i + ".");
                valid = false;
            }
            else lastStageBP = currentStageBP;
        }

        if (!valid)
        {
            for (int i = 0; i < stages.Count; i++)
            {
                stageModels[i].RemoveAll();
            }
        }
        return valid;
    }

    public void playCards()
    {
        for(int i=0; i<stages.Count; i++)
        {
            List<AdventureCard> tmp = new List<AdventureCard>();
            foreach(Card card in stages[i].GetComponentsInChildren<Card>())
            {
                tmp.Add(card.card as AdventureCard);
            }
            stageModels[i].addList(tmp);
        }
        if (validateStages())
        {
            PromptHandler.instance.localPrompt("Sponsorship", "ALL GOOD.");
        }
    }

    public bool testValid(AdventureCard currCard, List<AdventureCard> currStage)
    {
        if (currCard.type == AdventureCardType.AMOUR || currCard.type == AdventureCardType.ALLY) return false;
        if (currStage.Find(i => i.type == AdventureCardType.TEST) != null) return false;
        if ((currCard.type == AdventureCardType.FOE) && currStage.Find(i => i.type == AdventureCardType.FOE) != null) return false;
        if ((currCard.type == AdventureCardType.WEAPON) &&
            ((currStage.Find(i => i.type == AdventureCardType.TEST) != null) ||
            !(currStage.Find(i => i.type == AdventureCardType.FOE) != null) ||
            (currStage.Find(i => i.name == currCard.name) != null))) return false;

        bool testFlag = false;
        for (int i = 0; i < stages.Count; i++)
        {
            List<AdventureCard> testStage = new List<AdventureCard>();
            foreach (Card c in stages[i].GetComponentsInChildren<Card>())
                testStage.Add(c.card as AdventureCard);
            for (int j = 0; j < testStage.Count; j++)
            {
                if (testStage[j].type == AdventureCardType.TEST)
                {
                    testFlag = true;
                }
            }
        }

        if ((currCard.type == AdventureCardType.TEST) && ((currStage.Count > 0) || testFlag)) return false;
        return true;
    }
}
