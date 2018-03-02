using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class EventController : CardController<Event>
    {
        public void OnClick()
        {
            if(this.game.state == Game.gameState.Event)
            {
                this.game.state = Game.gameState.startTurn;
                Destroy(gameObject);
            }
        }
    }
}
