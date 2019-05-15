using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EndPoint : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private bool isActive;

    public event Action OnPlayerWin;

    private void Start()
    {
        particle?.SetActive(false);
    }

    public void Activate()
    {
        isActive = true;

        particle?.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isActive == true)
        {
            OnPlayerWin?.Invoke();
        }
    }
}
