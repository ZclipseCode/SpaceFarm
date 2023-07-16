using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{

    public void IncreaseDamage(int value)
    {
        PlayerCombat.attackDamage += value;
    }

    public void IncreaseAttackRate(int value)
    {
        PlayerCombat.attackRate += value;
    }

    public void IncreaseHealth(int value)
    {
        PlayerHealth.maxHealth += value;
        PlayerHealth.currentHealth += value;
    }

    public void IncreaseSpeed(int value)
    {
        PlayerMovement.moveSpeed += value;
    }

    public void IncreaseRange(int value)
    {
        PlayerCombat.attackRange += value;
    }


    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Y))
    //    {
    //        IncreaseDamage(20);
    //        Debug.Log("Damage Increased by 20");
    //    }
    //    if (Input.GetKeyDown(KeyCode.U))
    //    {
    //        IncreaseAttackRate(20);
    //        Debug.Log("Attack Rate Increased by 20");
    //    }
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        IncreaseRange(20);
    //        Debug.Log("Range Increased by 20");
    //    }
    //    if (Input.GetKeyDown(KeyCode.O))
    //    {
    //        IncreaseHealth(20);
    //        Debug.Log("Health Increased by 20");
    //    }
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        IncreaseSpeed(20);
    //        Debug.Log("Speed Increased by 20");
    //    }
    //}
}
