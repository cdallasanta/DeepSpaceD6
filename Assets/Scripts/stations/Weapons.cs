using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
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
    private void ActivateWeapons()
    {
        if (ship.weaponsUsed)
        {
            DealDamage();
            DealDamage();
        }
        else
        {
            DealDamage();
        }
    }

    private void DealDamage()
    {
        //select target card
        //reduce health by one
    }
}
