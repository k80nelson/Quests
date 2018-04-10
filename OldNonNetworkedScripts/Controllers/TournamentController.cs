using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentController : GameElement {

    public TournamentModel model;
    public TournamentView view;

    public Transform cardArea;
    int counter;
    bool inTie;


    private void OnEnable()
    {
        Debug.Log("[TournamentController.cs:OnEnable] Initializing Tournament");
        counter = 0;
        inTie = false;
    }

    public void startTournament(List<int> players)
    {
        model.initializePlayers(players);
        model.giveAdventureCards();
        nextPlayer();
    }

    public void nextPlayer()
    {
        if (counter >= model.numPlayers) checkWinner();
        else
        {
            model.nextActivePlayer();
            game.setActivePlayer(model.playerIds[model.activePlayer]);
            view.showCards();
        }

    }

    void checkWinner()
    {
        Debug.Log("[TournamentController.cs:checkWinner] Checking winners.. ");
        List<int> winners = model.findWinners();
        if (inTie && winners.Count > 1)
        {
            Debug.Log("[TournamentController.cs:checkWinner] " + winners.Count + " players have won the tournament.");
            game.EndTournamentTie(winners, model.joined, model.numShields);
            end();
        }
        else if (winners.Count > 1)
        {
            Debug.Log("[TournamentController.cs:checkWinner] " + winners.Count + " players have tied and continue the tournament.");
            inTie = true;
            counter = 0;
            model.activePlayer = -1;
            game.view.promptUser("There was a tie. Tournament will continue.");
            model.giveAdventureCards();
            nextPlayer();
        }
        else
        {
            Debug.Log("[TournamentController.cs:checkWinner] player " + winners[0] + " won the tournament.");
            game.EndTournament(winners[0], model.joined,model.numShields);
            end();
        }
    }

    public void end()
    {
        foreach(PlayerModel player in model.players)
        {
            player.cardsPlayed4Quest.discardWeaponsNAmours();
            player.addAllies(player.cardsPlayed4Quest.cardsPlayed);
            player.cardsPlayed4Quest.Empty();
        }

        game.view.EndTournament();
    }



    public void play()
    {
        
        List<AdventureCard> cardsPlayed = new List<AdventureCard>(cardArea.GetComponentsInChildren<AdventureCard>());
        model.players[model.activePlayer].cardsPlayed4Quest.addList(cardsPlayed);
        PlayerController currPlayerCtrl = game.players[game.activePlayer].GetComponent<PlayerController>();

        // hide each card in the player
        foreach (AdventureCard card in cardsPlayed)
        {
            currPlayerCtrl.hideCard(card.gameObject);
        }
        currPlayerCtrl.removeCards(cardsPlayed);

        counter += 1;
        Debug.Log("[TournamentController.cs:play] player " + (model.playerIds[model.activePlayer] + 1) + " played " + cardsPlayed.Count + " cards in the Tournament");
        nextPlayer();
    }

    public bool validate(AdventureCard card)
    {
        if (model.players[model.activePlayer].overMax())
        {
            game.view.promptUser("You are holding too many cards.");
            return false;
        }

        if (card.type == AdventureCard.Type.FOE || card.type == AdventureCard.Type.TEST) return false;

        List<AdventureCard> cardsPlayed = new List<AdventureCard>(cardArea.GetComponentsInChildren<AdventureCard>());
        if (card.type == AdventureCard.Type.AMOUR)
        {
            if (model.players[model.activePlayer].cardsPlayed4Quest.containsAmour()) return false;
            if (cardsPlayed.Find(i => i.type == AdventureCard.Type.AMOUR) != null) return false;
        }

        if (card.type == AdventureCard.Type.WEAPON)
        {

            if (cardsPlayed.Find(i => i.Name == card.Name) != null) return false;
        }

        return true;
    }



    
    
}
