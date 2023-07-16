using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedsSpawn : MonoBehaviour
{
    [SerializeField] Transform leftLow;
    [SerializeField] Transform rightHigh;
    [SerializeField] GameObject weeds;
    [SerializeField] float timeBetweenSpawns = 15;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);

        Instantiate(weeds, new Vector2(Random.Range(leftLow.position.x, rightHigh.position.x), Random.Range(leftLow.position.y, rightHigh.position.y)), Quaternion.identity);

        StartCoroutine(Spawn());
    }
}
