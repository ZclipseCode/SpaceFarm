using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    [SerializeField] GameObject crop;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Hurt Animation

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Debug.Log("Enemy died!");
        
        //Die aniamtion

        Instantiate(crop, transform.position, Quaternion.identity);

        //Disable the enemy
        Destroy(gameObject);
    }

}
