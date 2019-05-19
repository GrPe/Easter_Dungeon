using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTriggerable : MonoBehaviour
{
    [HideInInspector] public float Duration;
    [HideInInspector] public float Range;

    public void Invoke()
    {
        var colliders = Physics.OverlapSphere(transform.position, Range);

        foreach(var collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                var enemy = collider.gameObject.GetComponent<Enemy>();
                enemy.Stun(Duration);
            }
        }
    }
}
