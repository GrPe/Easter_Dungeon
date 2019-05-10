using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Egg : MonoBehaviour
{
    [SerializeField] private GameObject particle = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (particle != null)
            {
                var instance = Instantiate(particle, transform.parent.position, Quaternion.identity, null);
                Destroy(instance, 1);
            }
            Destroy(gameObject);
        }
    }
}
