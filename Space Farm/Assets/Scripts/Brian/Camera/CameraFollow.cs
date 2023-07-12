using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothingTimePercentage = .1f;
    [SerializeField] bool constrainX = false;
    [SerializeField] bool constraintY = false;

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 differance = target.position - transform.position;
            if (constrainX)
            {
                differance.x = 0;
            }

            if (constraintY)
            {
                differance.y = 0;
            }

            transform.position = new Vector3(transform.position.x + differance.x * smoothingTimePercentage, transform.position.y + differance.y * smoothingTimePercentage, -10f);
        }

    }
}
