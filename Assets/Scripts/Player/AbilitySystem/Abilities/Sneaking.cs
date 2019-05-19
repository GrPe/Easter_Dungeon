using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Abilities/Sneaking")]
public class Sneaking : Ability
{
    [SerializeField] private SneakingTriggerable laucher;
    public float duration;   

    public override void Initialize(GameObject obj)
    {
        laucher = obj.GetComponent<SneakingTriggerable>();
        laucher.Duration = duration;
    }

    public override void TriggerAbility()
    {
        laucher.Invoke();
    }
}
