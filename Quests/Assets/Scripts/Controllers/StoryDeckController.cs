using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryDeckController : GameElement {

    public Transform CardTransform;
    public StoryDeckModel model;
    public GameObject discardPrompt;
    public Button btn;
    public static System.Random rng = new System.Random();

    public void tryDraw()
    {
        if (game.players[game.activePlayer].GetComponent<PlayerModel>().overMax())
        {
            discardPrompt.SetActive(true);
        }
        else
        {
            if (CardTransform.transform.childCount > 0) discard();
            btn.interactable = false;
            draw();
        }
    }

    public void draw()
    {
        
        GameObject prefab = model.draw();
        GameObject card = Instantiate(prefab, CardTransform);
        card.name = prefab.name;
        card.tag = "CurrStory";

        if (card.GetComponent<QuestCard>() != null)
        {
            game.state.currCard = card.GetComponent<QuestCard>();
        }

        else if (card.GetComponent<TournamentCard>() != null)
        {
            game.state.currCard = card.GetComponent<TournamentCard>();
        }

        game.PlayStoryCard();
    }

    public void discard()
    {
        if (CardTransform.transform.childCount == 0) return;
        Destroy(CardTransform.transform.GetChild(0).gameObject);
        game.state.currCard = null; 
    }

    //Used only for Game Rigging
    //Function is called whenever the Q key is pressed, it will put a random quest on the screen.
    public void getQuest()
    {
        int rand = rng.Next(0, 10);
        GameObject prefab = model.draw(rand);
        GameObject card = Instantiate(prefab, CardTransform);
        card.name = prefab.name;
        card.tag = "CurrStory";

        if (card.GetComponent<QuestCard>() != null)
        {
            game.state.currCard = card.GetComponent<QuestCard>();
        }

        game.PlayStoryCard();

    }

    //Used only for Game Rigging
    //Function is called whenever the T key is pressed, it will put a random Tournement on the screen.
    public void getTournement()
    {
        int rand = rng.Next(10, 14);
        GameObject prefab = model.draw(rand);
        GameObject card = Instantiate(prefab, CardTransform);
        card.name = prefab.name;
        card.tag = "CurrStory";

        if (card.GetComponent<TournamentCard>() != null)
        {
            game.state.currCard = card.GetComponent<TournamentCard>();
        }

        game.PlayStoryCard();

    }

    //Used only for Game Rigging
    //Function is called whenever the T key is pressed, it will put a random Tournement on the screen.
    public void getEvent()
    {
        int rand = rng.Next(14, 22);
        GameObject prefab = model.draw(rand);
        GameObject card = Instantiate(prefab, CardTransform);
        card.name = prefab.name;
        card.tag = "CurrStory";

        if (card != card.GetComponent<TournamentCard>() && card != card.GetComponent<QuestCard>())
        {
            game.state.currCard = card.GetComponent<StoryCard>();
        }

        game.PlayStoryCard();

    }
}
