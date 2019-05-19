using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakingTriggerable : MonoBehaviour
{
    public bool IsHidden { get; private set; }
    [HideInInspector] public float Duration;
    private float timeLeft = 0f;

    public void Invoke()
    {
        timeLeft = Duration;
        IsHidden = true;
    }

    public void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <=0)
        {
            //clear;
            IsHidden = false;
        }
    }
}
