using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantHit : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public GameObject weapon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//change it to if in range
        {
            Attack();
        }
    }

    void Attack()
    {
        GameObject toolOfPain = Instantiate(weapon, attackPoint.position, attackPoint.rotation);
        toolOfPain.transform.localScale.Set(20, 90, 1);
        pause(); //pause then remove
        //Destroy(toolOfPain);

    }

    IEnumerator pause()
    {
        //Print the time of when the function is first called.
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(5);

        //After we have waited 5 seconds print the time again.
    }
}
