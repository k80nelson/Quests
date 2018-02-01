using System;

namespace QuestOTRT {

    public class Game {
        //Player[] players;     //total players in the game
        public int numPlayers;  //size of players Array


        //winlse is for finally of game, playerleft is for when AI or conclude game needs to be chosen
        private enum state{menu, game, pause, playerLeft, winlose};
    

        //total turns taken so far (for progress)
        private int turns;

        //setup for game
	    private Game() {
            /*
             * Call script for asking the number of players playing
             * Then, I/O from script is returned and numPLayers is set to it
             */
             turns=0;
            //players = new player[numPlayers];
            //state = 2;
        }
	
	    // Loop is called once per frame, AKA game loop
	    public void gameLoop () {

	    }
    }
}