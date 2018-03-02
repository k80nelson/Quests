//Used to give functionality to a button element with nothing in it in unity
//Basically turns on a transparent button

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Touch : Text
{
    //Wakes the button to allow the transparent space on the screen to be functional.
    protected override void Awake()
    {
        base.Awake();
    }
}

 // Touchable_Editor component, to prevent treating the component as a Text object.
 [CustomEditor(typeof(Touch))]
public class Touchable_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        // Do nothing
    }
}