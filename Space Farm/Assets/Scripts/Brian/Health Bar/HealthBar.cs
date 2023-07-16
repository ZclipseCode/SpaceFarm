using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    [SerializeField] PlayerHealth playerHealth;

    private void Start()
    {
        slider = GetComponent<Slider>();
        SetMaxHealth(playerHealth.maxHealth);
        SetHealth(playerHealth.maxHealth);
    }

    private void Update()
    {
        SetMaxHealth(playerHealth.maxHealth);
        SetHealth(playerHealth.currentHealth);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
