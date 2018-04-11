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
