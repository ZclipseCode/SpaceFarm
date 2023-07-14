using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class plantHit : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public GameObject weapon;
    public Collision2D collision;
    public string targetTag = "Player";
    //private Boolean aimForHit = false;

    void Update()
    {
        //if(aimForHit)
        if (Input.GetKeyDown(KeyCode.Space))//change it to if in range
        {
            Attack();
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

    void OnCollisionEnter2D(Collision2D range)//If close to player, should activate attack
    {
        if (range.gameObject.CompareTag(targetTag))
        {
            //aimForHit = true;
            Debug.Log("Range Deteced");
        }
    }
}
