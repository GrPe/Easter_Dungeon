using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakingTriggerable : MonoBehaviour
{
    [HideInInspector] public float Duration;
    private float timeLeft = 0f;

    public void Invoke()
    {
        timeLeft = Duration;
    }

    public void Update()
    {
        if(timeLeft <=0)
        {
            //clear;
        }
    }
}
