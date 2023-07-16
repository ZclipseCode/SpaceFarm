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
    //public Collision2D collision;
    public string targetTag = "Player";
    //private Boolean aimForHit = false;

    [SerializeField] int damage = 15;
    [SerializeField] float attackDelay = 1;
    bool inRange;
    bool isAttacking;

    //void Update()
    //{
    //    //if(aimForHit)
    //    if (Input.GetKeyDown(KeyCode.Space))//change it to if in range
    //    {
    //        Attack();
    //    }
    //}

    private void Update()
    {
        if (inRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    //void Attack()
    //{
    //    //Spawn weapon
    //    GameObject toolOfPain = Instantiate(weapon, attackPoint.position, attackPoint.rotation);
    //    //Destroy weapon
    //    Destruction(toolOfPain);

    //}

    IEnumerator Attack()
    {
        isAttacking = true;

        yield return new WaitForSeconds(attackDelay);

        if (inRange)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        isAttacking = false;
    }

    //IEnumerator Destruction(GameObject toDestroy)
    //{
    //    yield return new WaitForSeconds(1);
    //    Destroy(toDestroy);
    //}

    //void OnCollisionEnter2D(Collision2D range)//If close to player, should activate attack
    //{
    //    if (range.gameObject.CompareTag(targetTag))
    //    {
    //        //aimForHit = true;
    //        Debug.Log("Range Deteced");
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
