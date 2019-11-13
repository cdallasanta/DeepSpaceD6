using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minidice : MonoBehaviour
{
    public Sprite[] allSides = new Sprite[6];
    public SpriteRenderer spriteR;
    public int faceNum;

    private void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }
}
