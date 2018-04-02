using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentModel : GameElement {

    public List<PlayerModel> players;
    public List<int> playerIds;
    public int joined;
    public int numPlayers;
    public int activePlayer;
    public int numShields;

    private void OnEnable()
    {
        players = new List<PlayerModel>();
        playerIds = new List<int>();
        numShields = GameObject.FindGameObjectWithTag("CurrStory").GetComponent<TournamentCard>().BonusShields;
    }

    public void initializePlayers(List<int> players)
    {
        playerIds = new List<int>(players);
        foreach(int id in players)
        {
            PlayerModel curr = game.players[id].GetComponent<PlayerModel>();
            this.players.Add(curr);
            curr.cardsPlayed4Quest.discardWeaponsNAmours();
            curr.cardsPlayed4Quest.Empty();
        }

        joined = players.Count;
        numPlayers = players.Count;
        activePlayer = -1;

    }

    public void nextActivePlayer()
    {
        activePlayer = (activePlayer + 1) % numPlayers;
    }

    public List<int> findWinners()
    {
        Debug.Log("[TournamentController.cs:findWinners] Finding winners");
        List<int> winners = new List<int>();
        int highestBp = 0;

        foreach(PlayerModel player in players)
        {
            int playerBP = player.cardsPlayed4Quest.totalBP() + player.getBP() + player.calculateAllyBP();
            if (playerBP > highestBp)
            {
                Debug.Log("[TournamentController.cs:findWinners] Current highest winner: player " + (player.index+1));
                winners.Clear();
                winners.Add(player.index);
                highestBp = playerBP;
            }
            else if (playerBP == highestBp)
            {
                Debug.Log("[TournamentController.cs:findWinners] winner with same bp " + (player.index + 1));
                winners.Add(player.index);
            }

        }
        Debug.Log("[TournamentController.cs:findWinners] Found "+ (winners.Count) + " winner(s).");
        
        List<PlayerModel> models = new List<PlayerModel>(players);
        foreach(PlayerModel player in models)
        {
            if (winners.Contains(player.index))
            {
                player.cardsPlayed4Quest.discardWeapons();
                player.GetComponent<PlayerView>().saveHiddenAllies();
                continue;
            }
            Debug.Log("[TournamentController.cs:findWinners] Removing player " + (player.index + 1) + " from the tournament.");
            players.Remove(player);
            playerIds.Remove(player.index);
            numPlayers -= 1;
            player.cardsPlayed4Quest.discardWeaponsNAmours();
            player.addAllies(player.cardsPlayed4Quest.cardsPlayed);
            player.GetComponent<PlayerView>().saveHiddenAllies();
            player.cardsPlayed4Quest.Empty();
        }

        return winners;
    }

}
