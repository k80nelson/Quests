using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameElement : MonoBehaviour
{
    protected Gameplay game;

    void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Gameplay>();
    }
}

public class Gameplay : MonoBehaviour
{

    public GameState state;
    public int currPlayer;
    public int activePlayer;

    public AdventureDeckModel AdventureDeck;
    public StoryDeckController StoryDeck;

    public int numPlayers;
    public List<GameObject> players;
    public GameObject playerPrefab;
    public GameObject StatsPrefab;
    public Transform PlayerStats;

    public GameView view;
    public GameObject endTurn;
    public GameObject startTurn;

    private void Awake()
    {
        // Get the settings from the main menu
        GameObject found = GameObject.FindGameObjectWithTag("Global");
        if (found != null)
        {
            numPlayers = found.GetComponent<Globals>().numPlayers;
        }

        // Declare values
        players = new List<GameObject>();
        state = new GameState();

        currPlayer = -1;
        activePlayer = -1;
    }

    private void Start()
    {
        // Initialize players with 12 cards
        initPlayers();
        setActivePlayer(nextPlayer());
        setCurrPlayer(nextPlayer());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            view.toggleMenu();
        }
    }

    private void initPlayers()
    {
        for (int i = 0; i < numPlayers; i++)
        {
            Debug.Log("Instantiating Player " + (i + 1));
            GameObject player = Instantiate(playerPrefab, this.transform);
            GameObject stats = Instantiate(StatsPrefab, PlayerStats);

            player.name = "Player " + (i + 1);
            stats.name = "Player " + (i + 1) + " Stats";

            player.GetComponent<PlayerModel>().index = i;

            PlayerView tmp = player.GetComponent<PlayerView>();
            tmp.nameText = stats.transform.Find("Name").GetComponent<Text>();
            tmp.rankText = stats.transform.Find("Rank").GetComponent<Text>();
            tmp.shieldText = stats.transform.Find("Shields").GetComponent<Text>();
            tmp.cardsText = stats.transform.Find("Num Cards").GetComponent<Text>();
            tmp.highlight = stats.transform.Find("Highlight").gameObject;

            player.GetComponent<PlayerController>().addManyCards(AdventureDeck.drawMany(12));

            //Instantiate the stageModel for each player that will hold the cards they play for each stage on a quest.
            player.GetComponent<PlayerModel>().cardsPlayed4Quest = new StageModel();

            players.Add(player);
        }

    }

    public int nextPlayer()
    {
        return (currPlayer + 1) % numPlayers;
    }

    public void setActivePlayer(int player)
    {
        if (activePlayer > -1) players[activePlayer].GetComponent<PlayerView>().turnOff();
        activePlayer = player;
        players[player].GetComponent<PlayerView>().turnOn();
        view.ShowPlayerOverlay(player + 1);
    }

    public void setCurrPlayer(int player)
    {
        currPlayer = player;
    }

    public void setNextPlayer()
    {
        setActivePlayer(nextPlayer());
        currPlayer = activePlayer;
    }

    public void PlayStoryCard()
    {
        if (state.currCard != null)
        {
            state.currCard.Apply();
        }
    }

    public void StartSponsor()
    {
        view.LoadJoinSponsor();
    }

    public void CreateSponsor(int sponsor)
    {
        Debug.Log("The current active player is " + activePlayer + " in create sponsor");
        if (sponsor < 0)
        {
            StoryDeck.discard();
            setNextPlayer();
        }
        else
        {
            Debug.Log("Quest Sponsored by Player " + (sponsor + 1));
            view.LoadSponsor();
        }
    }

    public void CreateTournament(List<int> players)
    {
        if (players.Count == 0)
        {
            StoryDeck.discard();
            setNextPlayer();
        }
        else
        {
            Debug.Log(players.Count + " Players in tournament");
        }
    }

    public void CreateQuest(List<int> players)
    {
        if (players.Count == 0)
        {
            StoryDeck.discard();
            setNextPlayer();
        }
        else
        {
            Debug.Log(players.Count + " Players in Quest");
        }
    }

    public void PromptTournament()
    {
        view.LoadJoinTournament();
    }

    public void PromptQuest()
    {
        view.LoadJoinQuest();
    }
}
