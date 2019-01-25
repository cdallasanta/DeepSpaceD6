using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic : MonoBehaviour
{
    private Ship ship;

    // Start is called before the first frame update
    void Start()
    {
        ship = gameObject.GetComponentInParent<Ship>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ActivateMedic()
    {
        Dice[] diceInInfirmary = GameObject.Find("Infirmary Area").GetComponentsInChildren<Dice>();

        foreach (Dice dice in diceInInfirmary)
        {
            dice.MoveArea("Returned Area");
        }
    }

    private void ReduceScannersByOne()
    {
        Dice dice = GameObject.Find("Scanners").GetComponentInChildren<Dice>();
        dice.MoveArea("Returned Area");
    }
}
