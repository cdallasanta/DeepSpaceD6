using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextStepButton : MonoBehaviour
{
    private Game game;

    private void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    private void ChangeText(string newText)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = newText;
    }


    /* Stages:
     * 1. Roll Dice
     * 2. Lock Threats
     * 3. Assign Crew
     * 4. Draw Threat
     * 5. Roll Threat Dice
     * 6. Resolve Threat Cards
     * 7. Return Crew
     */
    public void OnClick()
    {
        switch (game.currentStage)
        {
            case 1:
                game.Step1();
                game.currentStage++;
                ChangeText("Lock Threats");
                break;
            case 2:
                game.Step2();
                game.currentStage += 2; //skipping step 3, since players do things then
                ChangeText("Done Assigning Crew,\nDraw Threat Card");
                break;
            case 4:
                game.Step4();
                game.currentStage++;
                ChangeText("Roll Threat Dice");
                break;
            case 5:
                game.Step5();
                game.currentStage++;
                ChangeText("Resolve Threat Cards");
                break;
            case 6:
                game.Step6();
                game.currentStage++;
                ChangeText("Next Round");
                break;
            case 7:
                game.Step7();
                game.currentStage = 1;
                ChangeText("Roll Dice");
                break;
        }
    }
}
