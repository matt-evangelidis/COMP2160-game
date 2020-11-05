using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Slider healthBar;
    private int currentHP;
    private int minHP;
    private int maxHP;
	
	public Health health;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        maxHP = (int)healthBar.maxValue;
        minHP = (int)healthBar.minValue;

        healthBar.value = health.CurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health.CurrentHealth;
    }
}
