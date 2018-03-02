using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class TestController : CardController<Test>
    {
        protected override void OnClick()
        {
            if (game.state == Game.gameState.Tournament) return;
            base.OnClick();
        }
        
        protected override void OnMouseEnter()
        {
            if (game.state == Game.gameState.Tournament) return;
            base.OnMouseEnter();
        }

        protected override void OnMouseExit()
        {
            if (game.state == Game.gameState.Tournament) return;
            base.OnMouseExit();
        }
    }
    
}
