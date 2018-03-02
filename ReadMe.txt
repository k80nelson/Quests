ReadMe - Comp3004 Iteration 1
=============================


Members: Group 18
-------
Katie Nelson - 101012786
Andrew Dodge - 100938015
Bertholin Destinvil - 100915003 
Jeremy Crinson - 101008617 

	
How to Start Game:
------------------
Double click on the .exe file to start to the game.
Or open the project in unity and click build and run from the file menu.


How to Use Game:
----------------
- All buttons on the menu are click-able, they will take you to the page that they 
	describe. Take your time here, it just gets worse from here on out.
	
- Click Play, then select the number of players you wish to have.
	- It says you can choose between 2-4 players, but when you actually play
	it will always be a 4 player game.

- Click the story deck to draw a card
	- Events drawn happen automatically, most of them work.
	- Quests do not work
	- Tournaments work
		- Click join tournament to join, then end turn, and repeat for all the
			players that you want to join.
		- Once back on the first player who joined click cards that
			have a hover mechanic to add them to the play queue
		- Click play cards once you have selected all the cards you want to play
		- Click end turn to move onto the next player in the tournament
		- Tournaments resolve automatically once all players have played
			- If there is a Tie, one tiebreaker occurs
	
- After you do your task for the turn, click the end turn button

- Click anywhere on the overlay screen to go back to the game scene
	- It will be the next players turn once you return to the game scene.
	
- Repeat steps 3 through 5 for each player

- If you have more than 12 cards in your hand you must discard some before doing 
	anything else. 

NOTES
-----
There is not a lot implemented game wise for this project
the test runner shows a lot of the implemented logic that we have written
but that we did not show on the GUI.
All logs are in the unity console.

STRATEGY PATTERN
----------------

Strategy base class is in Assets/Scripts/Model/Strategy.cs
Strategy2 implementation is in Assets/Scripts/Model/Strategy2.cs

Both are used in Assets/Scripts/Model/AI.cs


