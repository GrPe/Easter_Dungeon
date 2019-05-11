using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 3;
    public int Health { get => health; }

    public event Action OnHealthChange;
    public event Action OnPlayerDie;

    public void DealDamage()
    {
        health--;
        OnHealthChange?.Invoke();

        if(health <= 0)
        {
            Debug.Log("Player is dead");
            OnPlayerDie?.Invoke();
        }
    }
    
}
