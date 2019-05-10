using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectingEggs : MonoBehaviour
{
    [SerializeField] private int collectedEggs = 0;
    public int Score { get => collectedEggs; }
    
    private void OnTriggerEnter(Collider other)
    {
        var egg = other.gameObject.GetComponent<Egg>();

        if(egg!= null)
        {
            collectedEggs++;
        }
    }
}
