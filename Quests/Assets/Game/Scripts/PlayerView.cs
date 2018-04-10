using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour {

    [SerializeField] GameObject StatsPrefab;     // used to initialize playerstats
    [SerializeField] GameObject cardAreaPrefab;  // player dropzone at the bottom of screen
    [SerializeField] Transform allies;           // the Transform holding ally cards
    [SerializeField] Transform hidden;           // the Transform holding hidden cards
    [SerializeField] GameObject cardPrefab;      // used to show cards on the screen

    Transform cardSpawnPos;      // where to spawn player cards (in cardArea)
    PlayerStatView _stats;       // reference to the players playerStats object



    public void initStats(bool isLocalPlayer)
    {
        _stats = Instantiate(StatsPrefab, GameManager.instance.statsUIZone).GetComponent<PlayerStatView>();
        _stats.setName(gameObject.name);
        if (isLocalPlayer) _stats.setHighlight();
        else _stats.unsetHighlight();
    }

    public void initLocal()
    {
        cardSpawnPos = Instantiate(cardAreaPrefab, GameManager.instance.getActiveArea()).GetComponent<DropZone>().CardContainer;
    }

    public void updateRankText(int rank)
    {
        if (_stats != null)
            _stats.setRank(rank);
    }

    public void updateShieldText(int shields)
    {
        if (_stats != null)
            _stats.setShields(shields);
    }

    public void updateCardText(int cards)
    {
        if (_stats != null)
            _stats.setCards(cards);
    }

    // instantiates the card on the screen
    public void addCard(AdventureCard card)
    {
        Card NewCard = Instantiate(cardPrefab, cardSpawnPos).GetComponent<Card>();
        NewCard.setCard(card);
    }

    public void destroyAllies()
    {
        foreach(Transform child in allies)
        {
            Destroy(child.gameObject);
        }
    }
    public void destroyCard(GameObject card)
    {
        Destroy(card);
    }
}
