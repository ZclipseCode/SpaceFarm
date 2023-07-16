using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int maxHealth = 100;
    public static int currentHealth;

    [SerializeField] string gameOverSceneName;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Hurt Animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Debug.Log("Player died!");

        //Die aniamtion

        //Whatever else we plan on adding after player dies lol
        // lmao

        SceneManager.LoadScene(gameOverSceneName);
    }
}
