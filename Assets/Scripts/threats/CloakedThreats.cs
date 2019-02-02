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
        game = GameObject.Find("Game").GetComponent<Game>();
        firstPass = true;
    }

    public override void OnActivation()
    {
        if (firstPass)
        {
            firstPass = false;
            game.ResolveThreats(Random.Range(0,6));
            firstPass = true;
        }
    }
}
