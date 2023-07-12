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
            Vector3 difference = target.position - transform.position;
            if (constrainX)
            {
                difference.x = 0;
            }

            if (constraintY)
            {
                difference.y = 0;
            }

            transform.position = new Vector3(transform.position.x + difference.x * smoothingTimePercentage, transform.position.y + difference.y * smoothingTimePercentage, -10f);
        }

    }
}
