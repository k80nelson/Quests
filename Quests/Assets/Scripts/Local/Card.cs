using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Card : NetworkBehaviour {
    
    [SyncVar]
    public string cardPath;

    public Image image;
    public BaseCard card;
    public bool loaded = false;

    private void Start()
    {
        if (!loaded && cardPath != null)
        {
            loadCard();
        }
    }

    public void registerCard(string cardPath)
    {
        this.cardPath = cardPath;
        loadCard();
    }

    public void loadCard()
    {
        card = Resources.Load(cardPath) as BaseCard;
        name = card.name;
        updateImage();
    }

    public void updateImage()
    {
        if (card != null) image.sprite = card.image;
    }
    
}
