using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Stun")]
public class Stun : Ability
{
    [SerializeField] private StunTriggerable laucher;
    public float range;
    public float duration;

    public override void Initialize(GameObject obj)
    {
        laucher = obj.GetComponent<StunTriggerable>();
        laucher.Duration = duration;
        laucher.Range = range;
    }

    public override void TriggerAbility()
    {
        laucher.Invoke();
    }
}
