using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{

    PlayerCombat playerAttack;
    PlayerHealth playerHealth;
    PlayerMovement playerMovement;

    public void IncreaseDamage(int value)
    {
        playerAttack.attackDamage += value;
    }

    public void IncreaseAttackRate(int value)
    {
        playerAttack.attackRate += value;
    }

    public void IncreaseHealth(int value)
    {
        playerHealth.maxHealth += value;
        playerHealth.currentHealth += value;
    }

    public void IncreaseSpeed(int value)
    {
        playerMovement.moveSpeed += value;
    }

    public void IncreaseRange(int value)
    {
        playerAttack.attackRange += value;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = GetComponent<PlayerCombat>();
        playerHealth = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            IncreaseDamage(20);
            Debug.Log("Damage Increased by 20");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            IncreaseAttackRate(20);
            Debug.Log("Attack Rate Increased by 20");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            IncreaseRange(20);
            Debug.Log("Range Increased by 20");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            IncreaseHealth(20);
            Debug.Log("Health Increased by 20");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            IncreaseSpeed(20);
            Debug.Log("Speed Increased by 20");
        }
    }
}
