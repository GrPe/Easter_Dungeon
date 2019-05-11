using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private bool isActive;

    public event Action OnPlayerWin;

    public void Activate()
    {
        isActive = true;

        if(particle != null)
        {
            Instantiate(particle, gameObject.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isActive == true)
        {
            OnPlayerWin?.Invoke();
        }
    }
}
