using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engineering : MonoBehaviour
{
    private Ship ship;

    // Start is called before the first frame update
    void Start()
    {
        ship = gameObject.GetComponentInParent<Ship>();
    }

    void OnMouseDown()
    {
        if (ship.game.currentStage == 4 &&
            ship.selectedDice != null &&
            ship.selectedDice.face == "Engineering")
        {
            ActivateEngineering();
            PostActivationCleanup();
        }
    }

    private void PostActivationCleanup()
    {
        ship.selectedDice.MoveArea("Returned Area");
        ship.selectedDice.spriteR.color = Color.white;
        ship.selectedDice = null;
    }

    private void ActivateEngineering()
    {
        if (ship.engineeringUsed)
        {
            ship.RepairHull(2);
        }
        else
        {
            ship.RepairHull(1);
            ship.engineeringUsed = true;
        }
    }
}
