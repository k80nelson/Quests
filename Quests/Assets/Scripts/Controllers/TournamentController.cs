using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class TournamentController : CardController<Tournament>
    {
        public override void OnClick()
        {
            if (this.game.state == Game.gameState.Tournament)
            {
                this.game.state = Game.gameState.startTurn;
                this.game.turn.removeAll();
                Destroy(gameObject);
            }
        }
    }
}
