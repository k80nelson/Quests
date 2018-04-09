using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour {

    [SerializeField] GameObject StatsPrefab;
    [SerializeField] GameObject cardAreaPrefab;

    Transform cardSpawnPos;
    PlayerStatView _stats;

    public void initStats(bool isLocalPlayer)
    {
        _stats = Instantiate(StatsPrefab, GameManager.instance.statsUIZone).GetComponent<PlayerStatView>();
        if (isLocalPlayer) _stats.setHighlight();
        else _stats.unsetHighlight();
    }

    public void initLocal()
    {
        cardSpawnPos = Instantiate(cardAreaPrefab, GameManager.instance.getActiveArea()).GetComponent<DropZone>().CardContainer;
    }

    public void updatePlayerText(string player)
    {
        _stats.setName(player);
    }

    public void updateRankText(int rank)
    {
        _stats.setRank(rank);
    }

    public void updateShieldText(int shields)
    {
        _stats.setShields(shields);
    }

    public void updateCardText(int cards)
    {
        _stats.setCards(cards);
    }
}
