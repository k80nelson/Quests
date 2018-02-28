using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestOTRT;

public class Sponsoring : GameElement {
    public GameObject btn;
    public GameObject ourBtn;
    public QuestController quest;
    public List<List<Card>> stages;
    public int numStages;
    public List<Card> tempCards;
    public int currStage;

	// Use this for initialization
	void Start () {
        quest = GameObject.FindGameObjectWithTag("CurrStory").GetComponent<QuestController>();
        stages = new List<List<Card>>();
        tempCards = new List<Card>();
        currStage = 1;

        ourBtn = Instantiate(btn);
        ourBtn.transform.parent = gameObject.transform;
        ourBtn.GetComponentInChildren<Text>().text = "Create Stage " + currStage;
        ourBtn.GetComponent<Button>().onClick.AddListener(btnFunction);

        for (int i=0; i<quest.card.Stages; i++)
        {
            stages.Add(new List<Card>());
        }
        numStages = quest.card.Stages;
	}

    public void add(Card card)
    {
        tempCards.Add(card);
    }

    public void btnFunction()
    {
        stages[currStage - 1] = new List<Card>(tempCards);
        tempCards.Clear();

        foreach (Card card in stages[currStage-1])
        {
            this.game.current.GetComponent<PlayerController>().removeCard(card as AdventureCard);
            this.game.turn.removeClicked();
        }
        currStage++;
        
        if (currStage == numStages)
        {
            ourBtn.GetComponent<Button>().onClick.RemoveAllListeners();
            ourBtn.GetComponentInChildren<Text>().text = "End Sponsoring";
            ourBtn.GetComponent<Button>().onClick.AddListener(endFunction);
        }
        else
        {
            ourBtn.GetComponentInChildren<Text>().text = "Create Stage " + currStage;
        }
    }

    public void endFunction()
    {
        stages[currStage - 1] = new List<Card>(tempCards);
        tempCards.Clear();

        foreach (Card card in stages[currStage - 1])
        {
            this.game.current.GetComponent<PlayerController>().removeCard(card as AdventureCard);
            this.game.turn.removeClicked();
        }
        Debug.Log("we done");

        GameObject.Destroy(ourBtn);
        game.nextPlayer();
    }
    
	
	// Update is called once per frame
	void Update ()
    {
        
		
	}

    void sayStages()
    {
        Debug.Log(quest.card.Stages + " Stage Quest");
    }

}
