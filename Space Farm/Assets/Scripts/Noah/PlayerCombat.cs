using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackRange = 0.5f;
    public KeyCode attackButton;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0;

    [SerializeField] GameObject slash;

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
        StartCoroutine(Slash());

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    IEnumerator Slash()
    {
        GameObject s = Instantiate(slash, transform.position, Quaternion.identity);
        s.transform.SetParent(transform);

        yield return new WaitForSeconds(0.2f);

        Destroy(s);
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
