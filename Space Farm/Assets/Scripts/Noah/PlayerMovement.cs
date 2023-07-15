using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public bool isFacingRight;
    public KeyCode dodgeButton = KeyCode.H;
    public bool isDodging;
    public float dodgeTime = 1;

    Vector2 movement;

    public float dodgeForce = 5;



    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (!isFacingRight && movement.x > 0 || isFacingRight && movement.x < 0)
        {
            Flip();
        }
        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (Input.GetKeyDown(dodgeButton) && !isDodging)
        {
            StartCoroutine(Dodge());
        }
    }

    private void FixedUpdate()
    {
        if (!isDodging)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * dodgeForce * Time.fixedDeltaTime);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    IEnumerator Dodge()
    {
        isDodging = true;
        
        yield return new WaitForSeconds(dodgeTime);

        isDodging = false;
    }
}
