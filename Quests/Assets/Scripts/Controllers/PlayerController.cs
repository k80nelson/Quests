using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControllerK : DropZone
{
    public PlayerView view;
    public PlayerModel model;

    private void Start()
    {
        view = gameObject.GetComponent<PlayerView>();
        model = gameObject.GetComponent<PlayerModel>();
        view.changeName(gameObject.name);
        view.updateRank(model.rank.ToString());
        view.updateShields(model.shields);
        view.updateCards(1);
    }

    private void Update()
    {
        view.updateRank(model.rank.ToString());
        view.updateShields(model.shields);
        view.updateCards(1);
    }
    
    bool isValid(Draggable d)
    {
        return true;
    }
}
