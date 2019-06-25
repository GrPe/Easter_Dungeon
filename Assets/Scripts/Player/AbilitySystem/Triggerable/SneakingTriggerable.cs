using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakingTriggerable : MonoBehaviour
{
    [SerializeField] private GameObject model;
    private Renderer modelRenderer = null;
    private Color backupColor;

    public bool IsHidden { get; private set; }
    [HideInInspector] public float Duration;
    private float timeLeft = 0f;

    public void Invoke()
    {
        if(modelRenderer == null)
        {
            modelRenderer = model.GetComponent<Renderer>();
        }

        timeLeft = Duration;
        IsHidden = true;
        backupColor = modelRenderer.material.color;
        modelRenderer.material.color = new Color(1, 0.5f, 1, 0.5f);
    }

    public void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <=0 && IsHidden)
        {
            //clear;
            IsHidden = false;
            modelRenderer.material.color = backupColor;
        }
    }
}
