using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class Turn : GameElement
    {
        public GameObject TournamentDecision;
        public GameObject TournamentGameplay;
        public GameObject storyCard;
        public Game.gameState store;
        
        public void init()
        {
            storyCard = GameObject.FindGameObjectWithTag("CurrStory");
            switch (game.state)
            {
                case (Game.gameState.Sponsorship):
                    startSponsor();
                    break;
                case (Game.gameState.TourDecision):
                    startDecisions();
                    break;
                default: break;
            }
        }

        void startDecisions()
        {
            TournamentDecision.SetActive(true);
            game.activePlayers.Clear();
            game.numActive = 0;
        }

        void startSponsor()
        {

        }

        public void noTournament()
        {
            TournamentDecision.GetComponent<TournamentDecision>().reset();
            TournamentDecision.SetActive(false);
            end();
        }

        public void end()
        {
            GameObject.Destroy(storyCard);
            game.state = Game.gameState.EndEv;
        }

        public void StartTournament(int joined)
        {
            if (joined == 1)
            {
                TournamentDecision.GetComponent<TournamentDecision>().reset();
                TournamentDecision.SetActive(false);
                GameObject win = game.activePlayers.Dequeue() as GameObject;
                EndTournament(win, joined);
            }
            else
            {
                store = Game.gameState.Tournament;
                game.state = Game.gameState.StartEv;
            }
            
        }

        public void DisplayEvent()
        {
            if(game.state == Game.gameState.Tournament)
                TournamentGameplay.SetActive(true);
        }

        public void TourWin(PlayerController winner, int num)
        {
            int bonus = storyCard.GetComponent<TournamentController>().getShields();
            winner.addShields(num + bonus);
            Debug.Log(winner.name + " won the tournament, + " + (num + bonus) + " shields.");
        }

        public void EndTournament(GameObject player, int num)
        {
            TourWin(player.GetComponent<PlayerController>(), num);
            Destroy(storyCard);
            TournamentGameplay.GetComponent<TournamentGameplay>().reset();
            TournamentGameplay.SetActive(false);
            end();
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
