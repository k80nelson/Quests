using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class EventController : CardController<Event>
    {
        Event e;
        public override void OnClick()
        {
            if (this.game.state == Game.gameState.Event)
            {

                //c.play();
                this.game.state = Game.gameState.startTurn;
                Destroy(gameObject);
            }
        }
        
    }
}
