using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class EventController : CardController<Event>
    {
        public  void OnClick()
        {
            if(this.game.state == Game.gameState.Event)
            {
                

                ChivalrousDeed a = new ChivalrousDeed();
                Debug.Log("Player(s) with lowest rank and least amount of shields gains 3 shields");
                a.play();
                
                QueensFavor b = new QueensFavor();
                Debug.Log("Lowest ranked player(s) immediately recieve 2 Adventure Cards");
                b.play();

                CourtCalled c = new CourtCalled();
                Debug.Log("All Allies in play are discarded");
                c.play();

                KingRecognition d = new KingRecognition();
                Debug.Log("Kings Recognition not yet implemented...");
                Debug.Log("Highest ranked player(s) must place 1 weapon in the discard");
                d.play();

                KingsCall e = new KingsCall();
                Debug.Log("/Highest ranked player(s) must place 1 weapon in the discard. If unable to do so, 2 foe cards must be discarded");
                e.play();

                Plague f = new Plague();
                Debug.Log("Drawer loses 2 shields, if possible");
                f.play();

                Pox g = new Pox();
                Debug.Log("All other players lose one shield (if possible), drawer of this card is exempt");
                g.play();

                ProsperityTtR h = new ProsperityTtR();
                Debug.Log("All players can immediately draw 2 Adventure Cards");
                h.play();

                this.game.state = Game.gameState.startTurn;
                Destroy(gameObject);
            }
        }
    }
}
