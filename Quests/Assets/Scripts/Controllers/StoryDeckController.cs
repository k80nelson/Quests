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
    //Function is called whenever the T key is pressed, it will put a random Tournement on the screen.
    //Function is called whenever the E key is pressed, it will put a random Event on the screen.
    //Function is called whenever the C key is pressed, it will put Chivalrous Deed (+ 3 Shields) on the screen.
    //Function is called whenever the B key is pressed, it will put Boar Hunt on the screen.
    //Function is called whenever the P key is pressed, it will put Prosperity Throughout the Kingdom on the screen.
    //Function is called whenever the S key is pressed, it will put Slay the Dragon on the screen.
    public void gameRig(char key)
    {
        int rand = 0;

        if (key == 'q') rand = rng.Next(0, 10);
        else if (key == 't') rand = rng.Next(10, 14);
        else if (key == 'e') rand = rng.Next(14, 22);
        else if (key == 'c') rand = 14;
        else if (key == 'b') rand = 0;
        else if (key == 'p') rand = 20;
        else if (key == 's') rand = 7;

        GameObject prefab = model.draw(rand);
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
        else if (card != card.GetComponent<TournamentCard>() && card != card.GetComponent<QuestCard>())
        {
            game.state.currCard = card.GetComponent<StoryCard>();
        }

        game.PlayStoryCard();

    }
}
