using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
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

    private void ActivateShields()
    {
        ship.RefillShields();
    }

    private void ActivateStasis()
    {
        //select target
        //deactivate target
    }
}
