﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectingEggs : MonoBehaviour
{
    [SerializeField] private int score = 0;
    public int Score { get => score; }
    
    private void OnTriggerEnter(Collider other)
    {
        var egg = other.gameObject.GetComponent<Egg>();

        if(egg!= null)
        {
            score += egg.Score;
        }
    }
}