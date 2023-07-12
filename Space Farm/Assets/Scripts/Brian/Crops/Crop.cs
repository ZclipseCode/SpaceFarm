using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] int value;

    private void Awake()
    {
        MoneyManager.UpdateMoney += AddMoney;
    }

    void AddMoney()
    {
        MoneyManager.overallMoney += value;
        MoneyManager.currentMoney += value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoneyManager.UpdateMoney();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        MoneyManager.UpdateMoney -= AddMoney;
    }
}
