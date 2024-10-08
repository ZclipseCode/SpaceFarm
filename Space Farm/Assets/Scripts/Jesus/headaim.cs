using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headaim : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    //public Camera cam;
    GameObject target;

    Vector2 targetPos;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        targetPos = target.transform.position;
    }

    void FixedUpdate()
    {
        Vector2 lookDir = targetPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
