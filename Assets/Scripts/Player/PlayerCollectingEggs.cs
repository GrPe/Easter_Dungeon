using System;
using UnityEngine;

public class PlayerCollectingEggs : MonoBehaviour
{
    [SerializeField] private int collectedEggs = 0;
    public int CollectedEggs { get => collectedEggs; }

    public event Action OnCollectedEggs;
    
    private void OnTriggerEnter(Collider other)
    {
        var egg = other.gameObject.GetComponent<Egg>();

        if(egg!= null)
        {
            collectedEggs++;
            OnCollectedEggs();
        }
    }
}
