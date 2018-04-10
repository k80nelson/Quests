using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour {

    [SerializeField] GameObject StatsPrefab;
    [SerializeField] GameObject cardAreaPrefab;
    [SerializeField] GameObject allies;
    [SerializeField] GameObject hidden;
    [SerializeField] GameObject cardPrefab;

    Transform cardSpawnPos;
    PlayerStatView _stats;

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

    public void addCard(AdventureCard card)
    {
        Card NewCard = Instantiate(cardPrefab, cardSpawnPos).GetComponent<Card>();
        NewCard.setCard(card);
    }

    public void destroyCard(GameObject card)
    {
        Destroy(card);
    }
}
