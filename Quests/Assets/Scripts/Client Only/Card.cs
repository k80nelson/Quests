using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
    
    [SerializeField]
    Image image;
    public BaseCard card;
    

    string cardPath;

    private void Start()
    {

    }

    public void registerCard(string cardPath)
    {
        this.cardPath = cardPath;
        loadCard();
    }

    public void setCard(BaseCard card)
    {
        this.card = card;
        updateImage();
    }

    public void loadCard()
    {
        card = Resources.Load(cardPath) as BaseCard;
        name = card.name;
        updateImage();
    }

    void updateImage()
    {
        if (card != null)
        {
            image.sprite = card.image;
        }
    }
    
}
