using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTriggerable : MonoBehaviour
{
    [HideInInspector] public float Duration;
    [HideInInspector] public float Range;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private float timer = 1f;
    private float counter;

    private void Start()
    {
        particle.Stop();
        counter = timer;
    }

    private void Awake()
    {
        particle.Stop();
    }

    private void Update()
    {
        counter -= Time.deltaTime;

        if (counter <= 0 && particle.isPlaying)
        {
            particle.Stop();
        }
    }

    public void Invoke()
    {
        var colliders = Physics.OverlapSphere(transform.position, Range);

        if(particle != null)
        {
            particle.Play();
            counter = timer;
        }

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
