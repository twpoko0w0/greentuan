﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarImage : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    HealthrPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        player = FindObjectOfType<HealthrPlayer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = player.currentHitPoints;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;


    }
}
