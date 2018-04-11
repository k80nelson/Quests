using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatView : MonoBehaviour {

    [SerializeField] Text _name;
    [SerializeField] Text _rank;
    [SerializeField] Text _shields;
    [SerializeField] Text _cards;
    [SerializeField] GameObject highlight;

    public void setName(string name)
    {
        _name.text = name;
    }

    public void setRank(int rank)
    {
        _rank.text = "Rank: " + ((Rank)rank).ToString();
    }

    public void setShields(int shields)
    {
        Debug.Log("Setting shields in view");
        _shields.text = "Shields: " + shields;
    }

    public void setCards(int cards)
    {
        Debug.Log("Setting cards in view");
        _cards.text = "Cards: " + cards;
    }

    public void setHighlight()
    {
        highlight.SetActive(true);
    }

    public void unsetHighlight()
    {
        highlight.SetActive(false);
    }
}
