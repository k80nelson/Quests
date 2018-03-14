using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
namespace QuestOTRT
{
    public class Turn : GameElement
    {
        public GameObject TournamentDecision;
        public GameObject TournamentGameplay;
        public GameObject SponsorOverlay;
        public GameObject storyCard;
        public Game.gameState store;
        public ChangePlayer playChange;
        public GameObject canvas;
        public GameObject discardOverlay;
        public Button StyBtn;
        bool here = false;
        
        public void init()
        {
            storyCard = GameObject.FindGameObjectWithTag("CurrStory");
            switch (game.state)
            {
                case (Game.gameState.Sponsorship):
                    initSponsor();
                    break;
                case (Game.gameState.TourDecision):
                    startDecisions();
                    break;
                default: break;
            }
        }

        public void nextPlayer()
        {
            canvas.SetActive(true);
            playChange.onClick();
        }

        public void initSponsor()
        {
            SponsorOverlay.SetActive(true);
        }

        public void startSponsor()
        {
            SponsorOverlay.SetActive(false);
            Debug.Log(game.current.name + "Sponsored this quest");
        }

        public void noSponsor()
        {
            Debug.Log("no sponsor");
            SponsorOverlay.SetActive(false);
            end();
        }

        void startDecisions()
        {
            TournamentDecision.SetActive(true);
            game.activePlayers.Clear();
            game.numActive = 0;
        }
        
        public void noTournament()
        {
            Debug.Log("none");
            TournamentDecision.GetComponent<TournamentDecision>().reset();
            TournamentDecision.SetActive(false);
            end();
        }

        public void StartTournament(List<GameObject> players)
        {
            Debug.Log("Started");
            TournamentDecision.GetComponent<TournamentDecision>().reset();
            TournamentDecision.SetActive(false);
            game.activePlayers = players;
            game.numActive = players.Count;
            game.state = Game.gameState.Tournament;
            DisplayEvent();
        }

        public void endTourn()
        {
            GameObject.Destroy(storyCard);
            game.state = Game.gameState.startTurn;
            this.game.current.GetComponent<PlayerController>().view.setViewOff();
            game.current = game.nextPlayer();
            game.setIndeces();
            this.game.current.GetComponent<PlayerController>().view.setViewOn();
            this.game.current.GetComponent<PlayerController>().view.adjustHand();
        }

        public void end()
        {
            GameObject.Destroy(storyCard);
            game.state = Game.gameState.startTurn;
        }
        
        public void DisplayEvent()
        {
            if (game.state == Game.gameState.Tournament)
                TournamentGameplay.GetComponent<TournamentGameplay>().init();
                TournamentGameplay.SetActive(true);
        }

        public void TourWin(PlayerController winner, int num)
        {
            int bonus = storyCard.GetComponent<TournamentController>().getShields();
            winner.addShields(num + bonus);
            Debug.Log(winner.name + " won the tournament, + " + (num + bonus) + " shields.");
            
        }

        public void OneTournament(GameObject player, int num)
        {
            TourWin(player.GetComponent<PlayerController>(), num);
            Destroy(storyCard);
            TournamentGameplay.GetComponent<TournamentGameplay>().reset();
            TournamentGameplay.SetActive(false);
            end();
        }

        public void EndTournament(GameObject player, int num)
        {
            TourWin(player.GetComponent<PlayerController>(), num);
            Destroy(storyCard);
            TournamentGameplay.GetComponent<TournamentGameplay>().reset();
            TournamentGameplay.SetActive(false);
            endTourn();
        }

        public void checkWin()
        {
            if (game.state == Game.gameState.Tournament)
            {
                TournamentGameplay.GetComponent<TournamentGameplay>().checkWin();
            }
        }

        public void EndTournament(List<GameObject> ties, int num)
        {
            foreach (GameObject player in ties)
            {
                TourWin(player.GetComponent<PlayerController>(), num);
            }
            TournamentGameplay.GetComponent<TournamentDecision>().reset();
            TournamentGameplay.SetActive(false);
            end();
        }

        public void stopDiscard()
        {
            discardOverlay.SetActive(false);
            StyBtn.interactable = true;
            
        }

        public void discOverlayOn()
        {
            discardOverlay.SetActive(true);
        }

        public void discOverlayOff()
        {
            discardOverlay.SetActive(false);
        }

        public void next()
        {
            if(game.state == Game.gameState.NextTour)
            {
                TournamentDecision.GetComponent<TournamentDecision>().enableBtns();
                game.state = Game.gameState.TourDecision;
            }

            if(game.state == Game.gameState.Tournament)
            {
                TournamentGameplay.GetComponent<TournamentGameplay>().enableBtn();
                TournamentGameplay.GetComponent<TournamentGameplay>().checkWin();
            }

            if(game.state == Game.gameState.startTurn && game.current.GetComponent<PlayerController>().player.hand.overMax())
            {
                StyBtn.interactable = false;
                discardOverlay.SetActive(true);
                game.state = Game.gameState.Discard;
            }
        }
    }
}




/*
public class Turn : GameElement {
    public GameObject SponsorPrefab;
    public GameObject CombatPrefab;
    public GameObject BiddingPrefab;

    public GameObject SponsorOverlay;
    public GameObject CombatOverlay;


    public List<Card> cards;
    public GameObject overlay;

    public void init()
    {
        if (game.state == Game.gameState.Sponsorship)
        {
            SponsorOverlay.SetActive(true);
        }

        if (game.state == Game.gameState.Quest || game.state == Game.gameState.Tournament)
        {
            overlay.SetActive(true);
        }

    }

    public void startSponsor()
    {
        GameObject temp = Instantiate(SponsorPrefab);
        temp.transform.parent = game.current.transform.parent.transform;
        SponsorOverlay.SetActive(false);
    }

    public void noSponsor()
    {
        this.game.nextPlayer();
        this.game.state = Game.gameState.startTurn;
        GameObject.Destroy(GameObject.FindGameObjectWithTag("CurrStory"));
        SponsorOverlay.SetActive(false);
    }

    void Start()
    {
        cards = new List<Card>();
    }

    public void addCard(Card card)
    {
        cards.Add(card);
    }

    public void removeClicked()
    {
        GameObject[] clicked = GameObject.FindGameObjectsWithTag("Clicked");
        foreach (GameObject card in clicked)
        {
            if (card.GetComponent<WeaponController>() != null)
            {
                card.GetComponent<WeaponController>().reset();
                continue;
            }
            if (card.GetComponent<FoeController>() != null)
            {
                card.GetComponent<FoeController>().reset();
                continue;
            }
            if (card.GetComponent<TestController>() != null)
            {
                card.GetComponent<TestController>().reset();
                continue;
            }
            if (card.GetComponent<AmourController>() != null)
            {
                card.GetComponent<AmourController>().reset();
                continue;
            }
            if (card.GetComponent<AllyController>() != null)
            {
                card.GetComponent<AllyController>().reset();
                continue;
            }
        }
    }

    public void removeAll()
    {
        cards.Clear();

        removeClicked();

        if (!(game.state == Game.gameState.Quest || game.state == Game.gameState.Quest))
        {
            overlay.SetActive(false);
        }

        if(!(game.state == Game.gameState.Sponsorship))
        {
            SponsorOverlay.SetActive(false);
        }
    }

    public void removeCard(Card card)
    {
        cards.Remove(card);
    }

    public void ListAll()
    {
        string ls = "";
        foreach (Card card in cards)
        {
            ls += card.Name + ", ";
        }
        Debug.Log(ls);
    }

    public void playCards()
    {
        foreach(Card card in cards)
        {
            game.current.GetComponent<PlayerController>().removeCard(card as AdventureCard);
        }
        removeAll();
        this.game.nextPlayer();
    }


}
*/
