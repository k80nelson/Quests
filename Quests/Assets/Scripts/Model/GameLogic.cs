using System;
using System.Collections.Generic;

namespace QuestOTRT
{
    public class GameLogic
    {
        public List<QuestOTRT.AdventureCard> adventurecards;

        public GameLogic()
        {
            /* Weapons */
            //adding Excalibur
            QuestOTRT.Weapon excalibur = new QuestOTRT.Weapon("Excalibur", 30, 0);
            for (int i = 0; i < 2; ++i)
                adventurecards.Add(excalibur);

            //adding Lance
            QuestOTRT.Weapon lance = new QuestOTRT.Weapon("Lance", 20, 0);
            for (int i = 0; i < 6; ++i)
                adventurecards.Add(lance);

            //adding Battle-ax
            QuestOTRT.Weapon battleAx = new QuestOTRT.Weapon("Battle-ax", 15, 0);
            for (int i = 0; i < 8; ++i)
                adventurecards.Add(battleAx);

            //adding Sword
            QuestOTRT.Weapon sword = new QuestOTRT.Weapon("Sword",10,0);
            for (int i = 0; i < 5; ++i)
                adventurecards.Add(sword);

            //adding Horse
            QuestOTRT.Weapon horse = new QuestOTRT.Weapon("Horse", 10, 0);
            for (int i = 0; i < 11; ++i)
                adventurecards.Add(horse);

            //adding Dagger
            QuestOTRT.Weapon dagger = new QuestOTRT.Weapon("Dagger", 5, 0);
            for (int i = 0; i < 5; ++i)
                adventurecards.Add(dagger);




            /* Foes */
            //adding Dragon
            QuestOTRT.Foe dragon = new QuestOTRT.Foe("Dragon", 50, 0, 70, "");
            for (int i = 0; i < 1; ++i)
                adventurecards.Add(dragon);

            //adding Giant
            QuestOTRT.Foe giant = new QuestOTRT.Foe("Giant", 40, 0, 0, "");
            for (int i = 0; i < 2; ++i)
                adventurecards.Add(giant);

            //adding Mordred
            QuestOTRT.Foe mordred = new QuestOTRT.Foe("Mordred", 30, 0, 0, "Use as a Foe or sacrifice at any time to remove any player's Ally from play");
            for (int i = 0; i < 4; ++i)
                adventurecards.Add(mordred);

            //adding Green Knight
            QuestOTRT.Foe greenKnight = new QuestOTRT.Foe("Green Knight", 25, 0, 40, "");
            for (int i = 0; i < 2; ++i)
                adventurecards.Add(greenKnight);

            //adding Black Knight
            QuestOTRT.Foe blackKnight = new QuestOTRT.Foe("Black Knight", 25, 0, 35, "");
            for (int i = 0; i < 3; ++i)
                adventurecards.Add(blackKnight);

            //adding Evil Knight
            QuestOTRT.Foe evilKnight = new QuestOTRT.Foe("Evil Knight", 20, 0, 30, "");
            for (int i = 0; i < 6; ++i)
                adventurecards.Add(evilKnight);

            //adding Saxon Knight
            QuestOTRT.Foe saxonKnight = new QuestOTRT.Foe("Saxon Knight", 15, 0, 25, "");
            for (int i = 0; i < 8; ++i)
                adventurecards.Add(saxonKnight);

            //adding Robber Knight
            QuestOTRT.Foe robberKnight = new QuestOTRT.Foe("Robber Knight", 15, 0, 0, "");
            for (int i = 0; i < 7; ++i)
                adventurecards.Add(robberKnight);

            //adding Saxon
            QuestOTRT.Foe saxon = new QuestOTRT.Foe("Saxon", 10, 0, 20, "");
            for (int i = 0; i < 5; ++i)
                adventurecards.Add(saxon);

            //adding Boar
            QuestOTRT.Foe boar = new QuestOTRT.Foe("Boar", 5, 0, 15, "");
            for (int i = 0; i < 4; ++i)
                adventurecards.Add(boar);

            //adding Thieves
            QuestOTRT.Foe thieves = new QuestOTRT.Foe("Thieves", 5, 0, 0, "");
            for (int i = 0; i < 8; ++i)
                adventurecards.Add(thieves);

            /* Amours */
            //adding Amours
            QuestOTRT.Foe amours = new QuestOTRT.Foe("Amours", 10, 1, 0, "");
            for (int i = 0; i < 8; ++i)
                adventurecards.Add(amours);

            /* Test */



            /*
        //Weapons 
            //adding Excalibur
            QuestOTRT.Weapon excalibur = new QuestOTRT.Weapon("Excalibur", 30, 0);
            QuestOTRT.Weapon excalibur2 = excalibur;

            //adding Lance
            QuestOTRT.Weapon lance = new QuestOTRT.Weapon("Lance", 20, 0);
            QuestOTRT.Weapon lance1 = lance;
            QuestOTRT.Weapon lance2 = lance;
            QuestOTRT.Weapon lance3 = lance;
            QuestOTRT.Weapon lance4 = lance;
            QuestOTRT.Weapon lance5 = lance;

            for (int i = 0; i < 6; ++i)
                adventurecards.add(lance);

            //adding Battle-ax
            QuestOTRT.Weapon battleAx = new QuestOTRT.Weapon("Battle-ax", 15, 0);
            QuestOTRT.Weapon battleAx1 = battleAx;
            QuestOTRT.Weapon battleAx2 = battleAx;
            QuestOTRT.Weapon battleAx3 = battleAx;
            QuestOTRT.Weapon battleAx4 = battleAx;
            QuestOTRT.Weapon battleAx5 = battleAx;
            QuestOTRT.Weapon battleAx6 = battleAx;
            QuestOTRT.Weapon battleAx7 = battleAx;

            //adding Sword
            QuestOTRT.Weapon sword = new QuestOTRT.Weapon("Sword", 10, 0);
            QuestOTRT.Weapon sword1 = sword;
            QuestOTRT.Weapon sword2 = sword;
            QuestOTRT.Weapon sword3 = sword;
            QuestOTRT.Weapon sword4 = sword;

            //adding Horse
            QuestOTRT.Weapon horse = new QuestOTRT.Weapon("Horse", 10, 0);
            QuestOTRT.Weapon horse1 = horse;
            QuestOTRT.Weapon horse2 = horse;
            QuestOTRT.Weapon horse3 = horse;
            QuestOTRT.Weapon horse4 = horse;
            QuestOTRT.Weapon horse5 = horse;
            QuestOTRT.Weapon horse6 = horse;
            QuestOTRT.Weapon horse7 = horse;
            QuestOTRT.Weapon horse8 = horse;
            QuestOTRT.Weapon horse9 = horse;
            QuestOTRT.Weapon horse10 = horse;

            //adding Dagger
            QuestOTRT.Weapon dagger = new QuestOTRT.Weapon("Dagger", 5, 0);
            QuestOTRT.Weapon dagger1 = dagger;
            QuestOTRT.Weapon dagger2 = dagger;
            QuestOTRT.Weapon dagger3 = dagger;
            QuestOTRT.Weapon dagger4 = dagger;
            QuestOTRT.Weapon dagger5 = dagger;

            // Foes
            //adding Dragon
            QuestOTRT.Foe dragon = new QuestOTRT.Foe("Dragon", 50, 0, 70, "");



            //adding Giant
            QuestOTRT.Foe giant = new QuestOTRT.Foe("Giant", 40, 0, 0, "");
            QuestOTRT.Foe giant1 = giant;

            //adding Mordred
            QuestOTRT.Foe mordred = new QuestOTRT.Foe("Mordred", 30, 0, 0, "Use as a Foe or sacrifice at any time to remove any player's Ally from play");
            QuestOTRT.Foe mordred1 = mordred;
            QuestOTRT.Foe mordred2 = mordred;
            QuestOTRT.Foe mordred3 = mordred;

            for (int i = 0; i < 4; ++i)
                adventurecards.add(mordred);

            //adding Green Knight
            QuestOTRT.Foe greenKnight = new QuestOTRT.Foe("Green Knight", 25, 0, 40, "");
            QuestOTRT.Foe greenKnight1 = greenKnight;

            //adding Black Knight
            QuestOTRT.Foe blackKnight = new QuestOTRT.Foe("Black Knight", 25, 0, 35, "");
            QuestOTRT.Foe blackKnight1 = blackKnight;
            QuestOTRT.Foe blackKnight2 = blackKnight;

            //adding Evil Knight
            QuestOTRT.Foe evilKnight = new QuestOTRT.Foe("Evil Knight", 20, 0, 30, "");
            QuestOTRT.Foe evilKnight1 = evilKnight;
            QuestOTRT.Foe evilKnight2 = evilKnight;
            QuestOTRT.Foe evilKnight3 = evilKnight;
            QuestOTRT.Foe evilKnight4 = evilKnight;
            QuestOTRT.Foe evilKnight5 = evilKnight;

            //adding Saxon Knight
            QuestOTRT.Foe saxonKnight = new QuestOTRT.Foe("Saxon Knight", 15, 0, 25, "");
            QuestOTRT.Foe saxonKnight1 = saxonKnight;
            QuestOTRT.Foe saxonKnight2 = saxonKnight;
            QuestOTRT.Foe saxonKnight3 = saxonKnight;
            QuestOTRT.Foe saxonKnight4 = saxonKnight;
            QuestOTRT.Foe saxonKnight5 = saxonKnight;
            QuestOTRT.Foe saxonKnight6 = saxonKnight;
            QuestOTRT.Foe saxonKnight7 = saxonKnight;

            //adding Robber Knight
            QuestOTRT.Foe robberKnight = new QuestOTRT.Foe("Robber Knight", 15, 0, 0, "");
            QuestOTRT.Foe robberKnight1 = robberKnight;
            QuestOTRT.Foe robberKnight2 = robberKnight;
            QuestOTRT.Foe robberKnight3 = robberKnight;
            QuestOTRT.Foe robberKnight4 = robberKnight;
            QuestOTRT.Foe robberKnight5 = robberKnight;
            QuestOTRT.Foe robberKnight6 = robberKnight;
            

            //adding Saxon
            QuestOTRT.Foe saxon = new QuestOTRT.Foe("Saxon", 10, 0, 20, "");
            QuestOTRT.Foe saxon1 = saxon;
            QuestOTRT.Foe saxon2 = saxon;
            QuestOTRT.Foe saxon3 = saxon;
            QuestOTRT.Foe saxon4 = saxon;
            

            //adding Boar
            QuestOTRT.Foe boar = new QuestOTRT.Foe("Boar", 5, 0, 15, "");
            QuestOTRT.Foe boar1 = boar;
            QuestOTRT.Foe boar2 = boar;
            QuestOTRT.Foe boar3 = boar;
            

            //adding Thieves
            QuestOTRT.Foe thieves = new QuestOTRT.Foe("Thieves", 5, 0, 0, "");
            QuestOTRT.Foe thieves1 = thieves;
            QuestOTRT.Foe thieves2 = thieves;
            QuestOTRT.Foe thieves3 = thieves;
            QuestOTRT.Foe thieves4 = thieves;
            QuestOTRT.Foe thieves5 = thieves;
            QuestOTRT.Foe thieves6 = thieves;
            QuestOTRT.Foe thieves7 = thieves;
            

            // Amours 
            //adding Amours
            QuestOTRT.Foe amours = new QuestOTRT.Foe("Amours", 10, 1, 0, "");
            QuestOTRT.Foe amours1 = amours;
            QuestOTRT.Foe amours2 = amours;
            QuestOTRT.Foe amours3 = amours;
            QuestOTRT.Foe amours4 = amours;
            QuestOTRT.Foe amours5 = amours;
            QuestOTRT.Foe amours6 = amours;
            QuestOTRT.Foe amours7 = amours;
            
            */

            /*
             * 
             * Dont know why test have speical bids... im assuming if the card states minimum 3 then bid should be set to 3?
             * 
             */
            
            /* Test */
            //add Test of Valor
        }
    }
}
