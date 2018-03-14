using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryDeckController : GameElement {

    public Transform CardTransform;
    public StoryDeckModel model;
    public GameObject discardPrompt;
    public Button btn;

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
}
