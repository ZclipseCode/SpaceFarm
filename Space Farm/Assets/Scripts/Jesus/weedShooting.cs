using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weedShooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public int count = 0;

    public float bulletForce = 6f;

    // Update is called once per frame
    void Update()
    {
        if (count == 600)
        {
            Shoot();
            count = 0;
        }
        else
            count++;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
