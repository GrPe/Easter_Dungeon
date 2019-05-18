using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCoolDown : MonoBehaviour
{
    [SerializeField] private KeyCode abilityKey;
    [SerializeField] private Image darkMask;
    [SerializeField] private Ability ability;
    [SerializeField] private GameObject player;

    private Image abilityImage;
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        Initialize(ability, player);
    }

    public void Initialize(Ability ability, GameObject player)
    {
        this.ability = ability;
        abilityImage = GetComponent<Image>();
        abilityImage.sprite = this.ability.Sprite;
        darkMask.sprite = this.ability.Sprite;
        coolDownDuration = this.ability.BaseCoolDown;
        this.ability.Initialize(player);
        AbilityReady();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextReadyTime)
        {
            AbilityReady();
            if (Input.GetKeyDown(abilityKey))
            {
                ButtonTriggered();
            }
        }
        else
        {
            CoolDown();
        }
    }

    private void AbilityReady()
    {
        darkMask.enabled = false;
    }

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
        darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
    }

    private void ButtonTriggered()
    {
        nextReadyTime = coolDownDuration + Time.deltaTime;
        coolDownTimeLeft = coolDownDuration;
        darkMask.enabled = true;

        ability.TriggerAbility();
    }
}
