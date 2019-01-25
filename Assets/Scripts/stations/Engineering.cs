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

    // Update is called once per frame
    void Update()
    {

    }
    private void ActivateEngineering()
    {
        if (ship.engineeringUsed)
        {
            ship.hull += 2;
        }
        else
        {
            ship.hull += 1;
        }

        if (ship.hull > 8)
        {
            ship.hull = 8;
        }
    }
}
