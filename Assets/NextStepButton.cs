using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextStepButton : MonoBehaviour
{
    private Game game;
    private int gameStage;

    private void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
        gameStage = game.currentStage;
    }

    private void ChangeText(string newText)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = newText;
    }

    public void OnClick()
    {
        Debug.Log(gameStage);
        switch (gameStage)
        {
            case 1:
                game.Step1();
                gameStage++;
                ChangeText("Lock Threats");
                break;
            case 2:
                game.Step2();
                gameStage += 2; //skipping step 3, since players do things then
                ChangeText("Draw Threat Card");
                break;
            case 4:
                game.Step4();
                gameStage++;
                ChangeText("Roll Threat Dice");
                break;
            case 5:
                game.Step5();
                gameStage++;
                ChangeText("Next Round");
                break;
            case 6:
                game.Step6();
                gameStage = 1;
                ChangeText("Roll Dice");
                break;
        }
    }
}
