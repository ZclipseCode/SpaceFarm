using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBullet : MonoBehaviour
{
    public int count = 0;

    [SerializeField] int damage = 10;
    [SerializeField] float expirationTime = 20;

    private void Start()
    {
        StartCoroutine(Expire());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    IEnumerator Expire()
    {
        yield return new WaitForSeconds(expirationTime);

        Destroy(gameObject);
    }
}
