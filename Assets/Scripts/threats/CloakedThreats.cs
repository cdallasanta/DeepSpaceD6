using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakedThreats : Card
{
    private Game game;
    private bool firstPass;

    // Start is called before the first frame update
    void Start()
    {
        title = "CLoaked Threats";
        type = "internal";
        activationNums = new int[] { 2 };
        game = GameObject.Find("Game").GetComponent<Game>();
        firstPass = true;
        alternateCost = new string[] { "shields", "commander" };
    }

    public override void OnActivation()
    {
        if (firstPass)
        {
            firstPass = false;
            game.Step5();
            firstPass = true;
        }
    }
}
