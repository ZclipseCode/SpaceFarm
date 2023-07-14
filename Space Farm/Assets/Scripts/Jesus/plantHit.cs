using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class plantHit : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public GameObject weapon;
    public GameObject player;

    void Update()
    {
            //Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
            //foreach(Collider2D objects in hitPlayer)
            if (Input.GetKeyDown(KeyCode.Space))//change it to if in range
            {
                //if (objects == player)
                //{
                Attack();
                //}
            }
    }

    void Attack()
    {
        //Spawn weapon
        GameObject toolOfPain = Instantiate(weapon, attackPoint.position, attackPoint.rotation);
        //Destroy weapon
        Destruction(toolOfPain);

    }

    IEnumerator Destruction(GameObject toDestroy)
    {
        yield return new WaitForSeconds(1);
        Destroy(toDestroy);
    }
}
