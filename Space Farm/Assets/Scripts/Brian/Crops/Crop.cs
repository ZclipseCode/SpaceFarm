using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoneyManager.overallMoney += value;
            MoneyManager.currentMoney += value;

            MoneyManager.UpdateMoney();

            Destroy(gameObject);
        }
    }
}
