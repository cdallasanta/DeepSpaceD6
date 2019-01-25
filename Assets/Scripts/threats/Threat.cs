﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Threat : MonoBehaviour
{
    public string title;
    public string type;
    public int MAXHP;
    public int currentHP;
    public int[] activationNums;

    public void ReduceHealth()
    {
        currentHP -= 1;

        if(currentHP <= 0)
        {
            DestroySelf();
        }

        PlaceOnBoard();
    }

    public void HealByOne()
    {
        currentHP = Mathf.Min(MAXHP, currentHP + 1);
        PlaceOnBoard();
    }

    private void DestroySelf()
    {
        enabled = false;
    }
    
    private void PlaceOnBoard()
    {
        Transform newParent = GameObject.Find($"{currentHP} Health").transform;
        gameObject.transform.SetParent(newParent, false);
    }
}
