using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{

    PlayerCombat playerAttack;
    PlayerHealth playerHealth;

    public void IncreaseDamage(int value)
    {
        playerAttack.attackDamage += value;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            IncreaseDamage(20);
            Debug.Log("Damage Increased by 20");
        }
    }
}
