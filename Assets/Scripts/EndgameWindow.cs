using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EndgameWindow : MonoBehaviour
{
    //this code doesn't work as intended yet, the screen popup isn't right for the resolution
     
    // 800x1200 px window will apear in the center of the screen.
    private Rect windowRect = new Rect((Screen.width - 1200) / 2, (Screen.height - 800) / 2, 1200, 800);
    // Only show it if needed.
    private bool show = false;
    private bool gameWon = false;

    void OnGUI()
    {
        if (show)
        {
            if (gameWon)
            {
                windowRect = GUI.Window(0, windowRect, DialogWindow, "You've Won!");
            } else
            {
                windowRect = GUI.Window(0, windowRect, DialogWindow, "You've been destroyed!");
            }
        }
    }

    // This is the actual window.
    void DialogWindow(int windowID)
    {
        float y = 20;
        GUI.Label(new Rect(5, y, windowRect.width, 20), "Again?");

        if (GUI.Button(new Rect(5, y, windowRect.width - 10, 20), "Restart"))
        {
            //restart the game here
            show = false;
        }

        if (GUI.Button(new Rect(5, y, windowRect.width - 10, 20), "Exit"))
        {
            Application.Quit();
            show = false;
        }
    }

    // To open the dialogue from outside of the script.
    public void GameLost()
    {
        show = true;
    }

    public void GameWon()
    {
        show = true;
        gameWon = true;
    }
}
