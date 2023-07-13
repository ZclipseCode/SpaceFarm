using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackRange = 0.5f;
    public KeyCode attackButton;
    public LayerMask enemyLayers;
    public int attackDamge = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(attackButton))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamge);
        }
    }

    void OnDrawGizmosSelected()
    {
        //if (attackPoint == null)
        //{
        //    return;
        //}
        
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
