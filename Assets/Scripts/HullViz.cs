using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullViz : MonoBehaviour
{
    private SpriteRenderer spriteR;
    public Sprite[] allSprites = new Sprite[9];
    private Ship ship;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        ship = GameObject.Find("Ship").GetComponent<Ship>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ship.hull >= 0)
        {
            spriteR.sprite = allSprites[Mathf.Max(ship.hull, 0)];
        }
    }
}
