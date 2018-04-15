using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TournamentController : MonoBehaviour {

    [SerializeField] Transform playArea;
    [SerializeField] Transform cardsInPlay;
    [SerializeField] GameObject cardPrefab;
    [SerializeField] Button playCards;
    [SerializeField] GameObject UI;

    StageModel playerCards = new StageModel();
    StageModel inPlay = new StageModel();
    bool amourPlayed = false;
    
    public void Init(int cardIndex)
    {
        Debug.Log("[TournamentController.cs:Init] Initializing tournament");
        amourPlayed = false;
        inPlay = new StageModel();
        playerCards = new StageModel();
        List<int> allies = NetPlayerController.LocalPlayer.getAllies();
        inPlay = new StageModel();
        foreach (int ally in allies)
        {
            spawnInPlayCard(ally);
        }
        UI.SetActive(true);
        playArea.gameObject.SetActive(true);
        playCards.gameObject.SetActive(true);
    }

    public void spawnInPlayCard(int index)
    {
        inPlay.Add(GameManager.instance.dict.findCard(index) as AdventureCard);
        GameObject card = Instantiate(cardPrefab, cardsInPlay);
        card.GetComponent<Draggable>().draggable = false;
        card.GetComponent<Card>().setCard(GameManager.instance.dict.findCard(index));
    }

    public bool isValid(AdventureCard card)
    {
        if (card.type == AdventureCardType.FOE || card.type == AdventureCardType.TEST) return false;

        List<AdventureCard> cardsPlayed = new List<AdventureCard>();
        foreach (Card child in playArea.GetComponentsInChildren<Card>())
        {
            cardsPlayed.Add(child.card as AdventureCard);
        }
        if (card.type == AdventureCardType.AMOUR)
        {
            if (amourPlayed) return false;
            if (cardsPlayed.Find(i => i.type == AdventureCardType.AMOUR) != null) return false;
        }

        if (card.type == AdventureCardType.WEAPON)
        {

            if (cardsPlayed.Find(i => i.name == card.name) != null) return false;
        }

        return true;
    }

    public void setTie()
    {
        Debug.Log("[TournamentController.cs:setTir] Player ties in tournament");
        NetPlayerController.LocalPlayer.drawAdvCards(1);
        playArea.gameObject.SetActive(true);
        playCards.gameObject.SetActive(true);
        playerCards = new StageModel();
    }

    public void play()
    {
        
        foreach (Card child in playArea.GetComponentsInChildren<Card>())
        {
            playerCards.Add(child.card as AdventureCard);
        }


        int totalBp = playerCards.totalBP() + NetPlayerController.LocalPlayer.getBP() + inPlay.totalBP();

        Debug.Log("[TournamentController.cs:Init] Playing player cards. Total BP: " + totalBp);
        List<AdventureCard> allies = playerCards.removeAllies();
        foreach (AdventureCard ally in allies)
        {
            NetPlayerController.LocalPlayer.addAlly(ally);
            NetPlayerController.LocalPlayer.removeCard(ally.index);
            spawnInPlayCard(ally.index);
        }

        if (playerCards.containsAmour())
        {
            amourPlayed = true;
            spawnInPlayCard(31);
            NetPlayerController.LocalPlayer.removeCard(31);
        }

        playerCards.removeAmours();
        
        foreach (AdventureCard card in playerCards.cardsPlayed)
        {
            NetPlayerController.LocalPlayer.discardCard(card.index);
        }
        foreach (Transform child in playArea)
        {
            Destroy(child.gameObject);
        }
        playArea.gameObject.SetActive(false);
        playCards.gameObject.SetActive(false);
        TourHandler.instance.SendServerPlayedCards(NetPlayerController.LocalPlayer.index, totalBp);
    }

    public void fail()
    {
        Debug.Log("[TournamentController.cs:Fail] Player has failed tournament");
        playArea.gameObject.SetActive(false);
        playCards.gameObject.SetActive(false);
        end();
    }

    public void win()
    {
        Debug.Log("[TournamentController.cs:Win] Player wins the tournament");
        playArea.gameObject.SetActive(false);
        playCards.gameObject.SetActive(false);
        end();
    }
    
    public void end()
    {
        Debug.Log("[TournamentController.cs:End] Ending tournament");
        if (amourPlayed)
        {
            NetPlayerController.LocalPlayer.discardCard(31);
            amourPlayed = false;
        }

        stopUI();
    }

    void stopUI()
    {
        foreach (Transform card in cardsInPlay)
        {
            Destroy(card.gameObject);
        }

        UI.SetActive(false);
    }

}
