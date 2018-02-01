using System;

namespace QuestOTRT
{
    /*
     * Model of MVC
     */
    public class Model
    {
        int size;   //of updateables array
        public Updateables[] updateables;

        //Render function contrained and called by all renderable objects
        //this will (most likely) call the .cs sripts from unity.
        public void update()
        {
            /* 
             * this is where we will have a loop for the renderables of the MVC
             */
            for (int i = 0; i < size; i++)
            {
                updateables[i].update();
            }
        }
    }
}