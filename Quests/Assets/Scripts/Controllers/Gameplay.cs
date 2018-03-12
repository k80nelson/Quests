using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour {

    public GameState state;
    public int currPlayer;
    public int activePlayer;
    
    public int numPlayers;
    public List<GameObject> players;
    public GameObject playerPrefab;
    public GameObject StatsPrefab;
    public Transform PlayerStats;
    
    public GameObject JoinSponsor;
    public GameObject Sponsor;
    public GameObject JoinQuest;
    public GameObject Quest;
    public GameObject JoinTournament;
    public GameObject Tournament;
    public GameObject PlayerOverlay;

    private void Awake()
    {
        GameObject found = GameObject.FindGameObjectWithTag("Global");
        if (found != null)
        {
            numPlayers = found.GetComponent<Globals>().numPlayers;
        }
        players = new List<GameObject>();
        state = new GameState();
        currPlayer = -1;
        activePlayer = -1;
    }

    private void Start()
    {
        initPlayers();
    }

    private void initPlayers()
    {
        for (int i = 0; i < numPlayers; i++)
        {
            GameObject player = Instantiate(playerPrefab, this.transform);
            GameObject stats = Instantiate(StatsPrefab, PlayerStats);

            player.name = "Player " + (i + 1);
            stats.name = "Player " + (i + 1) + " Stats";

            PlayerView tmp = player.GetComponent<PlayerView>();
            tmp.nameText = stats.transform.Find("Name").GetComponent<Text>();
            tmp.rankText = stats.transform.Find("Rank").GetComponent<Text>();
            tmp.shieldText = stats.transform.Find("Shields").GetComponent<Text>();
            tmp.cardsText = stats.transform.Find("Num Cards").GetComponent<Text>();
            tmp.highlight = stats.transform.Find("Highlight").gameObject;
            
            players.Add(player);
        }
        
    }
}
