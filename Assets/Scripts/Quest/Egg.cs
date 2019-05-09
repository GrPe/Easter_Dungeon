using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Egg : MonoBehaviour
{
    [SerializeField] private GameObject particle = null;
    [SerializeField] private int score = 5;
    public int Score { get => score; }

    private void OnTriggerEnter(Collider other)
    {
        if (particle != null)
        {
            var instance = Instantiate(particle, transform.parent.position, Quaternion.identity, null);
            Destroy(instance, 1);
        }
        Destroy(gameObject);
    }
}
