using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public enum StageType { COMBAT, BIDDING }

public class QuestController : MonoBehaviour {

    [SerializeField] Transform playArea;     // Dropzone area 
    [SerializeField] Transform cardsInPlay;  // cards already played
    [SerializeField] GameObject cardPrefab;
    [SerializeField] Button playCards;
    [SerializeField] GameObject combat;
    [SerializeField] GameObject bidding;
    [SerializeField] CombatController combatCtrl;
    [SerializeField] BiddingController biddingCtrl;
    [SerializeField] GameObject UI;
    [SerializeField] Image testImage;
    [SerializeField] Text minBidText;

    [SerializeField] Transform sponsorCardPos;
    [SerializeField] Transform playerCardPos;
    [SerializeField] GameObject showPrevStage;

    int stages = 0;
    QuestCard card;

    StageType currStageType;
    int currStage;
    int minBP;
    int minBid;

    bool amourPlayed = false;

    StageModel previousStage;
    StageModel sponsorCards;
    StageModel playerCards;
    StageModel inPlay;

    bool failed = false;

    // ---- INITIALIZATION ----

    public void Init(int cardIndex)
    {
        amourPlayed = false;
        failed = false;
        card = GameManager.instance.dict.findCard(cardIndex) as QuestCard;
        stages = card.stages;
        List<int> allies = NetPlayerController.LocalPlayer.getAllies();
        inPlay = new StageModel();
        foreach (int ally in allies)
        {
            spawnInPlayCard(ally);
        }
        UI.SetActive(true);
        startStage(0);
    }

    public void startStage(int index)
    {
        stopStage();
        currStage = index;
        if (index == 0)
        {
            setStage(index);
        }
        else
        {
            if (currStageType == StageType.COMBAT) showLastStage();
            else setStage(currStage);
        }
    }
    
    void showLastStage()
    {
        stopStage();

        foreach(int i in sponsorCards.getIndexList())
        {
            GameObject tmp = Instantiate(cardPrefab, sponsorCardPos);
            tmp.GetComponent<Draggable>().draggable = false;
            tmp.GetComponent<Card>().setCard(GameManager.instance.dict.findCard(i));
        }

        foreach(int i in previousStage.getIndexList())
        {
            GameObject tmp = Instantiate(cardPrefab, playerCardPos);
            tmp.GetComponent<Draggable>().draggable = false;
            tmp.GetComponent<Card>().setCard(GameManager.instance.dict.findCard(i));
        }

        showPrevStage.SetActive(true);
    }

    void unshowLastStage()
    {
        foreach (Transform child in sponsorCardPos)
        {
            Destroy(child.gameObject);
        }
        foreach(Transform child in playerCardPos)
        {
            Destroy(child.gameObject);
        }
        showPrevStage.SetActive(false);
    }
    
    public void lastStageBtn()
    {
        unshowLastStage();
        if (failed)
        {
            end();
        }
        else
        {
            setStage(currStage);
        }
    }

    public void setStage(int index)
    {
        if (currStage > 0) NetPlayerController.LocalPlayer.drawAdvCards(1);
        playArea.gameObject.SetActive(true);
        playCards.gameObject.SetActive(true);
        sponsorCards = NetSponsorModel.instance.getStage(index);
        playerCards = new StageModel();
        currStageType = sponsorCards.stageType();
        if (currStageType == StageType.COMBAT)
        {
            initCombat();
        }
        else
        {
            initBidding();
        }
    }
    void initCombat()
    {
        showCombat();
        minBP = sponsorCards.totalBP();
    }

    void initBidding()
    {
        testImage.sprite =  sponsorCards.getTest().image;
        minBid = sponsorCards.getTest().getMinimumBid();
        bidding.SetActive(true);
        SponsorHandler.instance.sendStartBid(minBid);
        playArea.gameObject.SetActive(false);
        playCards.gameObject.SetActive(false);
    }

    public void startBid(int bid)
    {
        playArea.gameObject.SetActive(true);
        playCards.gameObject.SetActive(true);
        minBid = bid;
        minBidText.text = "Minimum bid: " + bid;
    }

    public void play()
    {
        if (currStageType == StageType.COMBAT) playCombat();
        else playBid();
    }

    public bool valid(AdventureCard card)
    {
        if (currStageType == StageType.BIDDING) return true;
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

    void playCombat()
    {
        foreach (Card child in playArea.GetComponentsInChildren<Card>())
        {
            playerCards.Add(child.card as AdventureCard);
        }

        previousStage = new StageModel();
        
        bool passedStage = checkPass(playerCards);

        List<AdventureCard> allies = playerCards.removeAllies();
        foreach(AdventureCard ally in allies)
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

        previousStage.addList(playerCards.cardsPlayed);
        foreach (AdventureCard card in playerCards.cardsPlayed)
        {
            NetPlayerController.LocalPlayer.discardCard(card.index);
        }
        foreach(Transform child in playArea)
        {
            Destroy(child.gameObject);
        }
        playArea.gameObject.SetActive(false);
        playCards.gameObject.SetActive(false);
        SponsorHandler.instance.SendEndStage(NetPlayerController.LocalPlayer.index, passedStage);
        PromptHandler.instance.localPrompt("Quest", "Waiting for other players to complete stage.");
    }

    bool checkPass(StageModel cards)
    {
        return (minBP <= (cards.totalBP() + inPlay.totalBP() + NetPlayerController.LocalPlayer.getBP()));
    }

    void playBid()
    {
        int playerBid = 0;
        foreach(AdventureCard card in inPlay.cardsPlayed)
        {
            playerBid += card.getBids();
        }
        foreach(Transform child in playArea)
        {
            playerBid += 1;
        }
        if (playerBid >= minBid)
        {
            Debug.Log("BID " + playerBid);
            playArea.gameObject.SetActive(false);
            playCards.gameObject.SetActive(false);
            SponsorHandler.instance.sendBid(playerBid);
        }
        else
        {
            PromptHandler.instance.localPrompt("Quest", "Minimum bid is " + minBid + ". Your bid: " + playerBid);
        }
    }

    public void dropOut()
    {
        foreach(Transform child in playArea)
        {
            child.SetParent(NetPlayerController.LocalPlayer.cardArea);
        }
        SponsorHandler.instance.sendEndBid(NetPlayerController.LocalPlayer.index, minBid);
        fail();
        stopUI();
    }

    public void winBid()
    {
        foreach (Transform child in playArea)
        {
            NetPlayerController.LocalPlayer.discardBid(child.gameObject);
            PromptHandler.instance.localPrompt("Quest", "You've won the bid");
        }
        playArea.gameObject.SetActive(false);
        playCards.gameObject.SetActive(false);
    }

    public void end()
    {
        if (amourPlayed)
        {
            NetPlayerController.LocalPlayer.discardCard(31);
            amourPlayed = false;
        }

        stopUI();
    }

    public void fail()
    {
        failed = true;
        PromptHandler.instance.localPrompt("Quest", "You have failed the quest.");
        stopStage();
        if (currStageType == StageType.COMBAT) showLastStage();
        else end();
    }
    
    void spawnInPlayCard(int index)
    {
        inPlay.Add(GameManager.instance.dict.findCard(index) as AdventureCard);
        GameObject card = Instantiate(cardPrefab, cardsInPlay);
        card.GetComponent<Draggable>().draggable = false;
        card.GetComponent<Card>().setCard(GameManager.instance.dict.findCard(index));
    }

    void stopStage()
    {
        combat.SetActive(false);
        bidding.SetActive(false);
        playArea.gameObject.SetActive(false);
        playCards.gameObject.SetActive(false);
    }

    void stopUI()
    {
        foreach(Transform card in cardsInPlay)
        {
            Destroy(card.gameObject);
        }
        
        UI.SetActive(false);
    }

    void showCombat()
    {
        bidding.SetActive(false);
        combat.SetActive(true);
    }

    void showBidding()
    {
        combat.SetActive(true);
        testImage.sprite = sponsorCards.getTest().image;
        bidding.SetActive(true);
    }
    
}
