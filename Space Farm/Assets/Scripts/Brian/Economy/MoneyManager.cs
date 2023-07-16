using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int overallMoney;
    public static int currentMoney;

    public delegate void UpdateMoneyDelegate();
    public static UpdateMoneyDelegate UpdateMoney;

    [SerializeField] int startingMoney;

    private void Start()
    {
        overallMoney = startingMoney;
        currentMoney = startingMoney;
        UpdateMoney();
    }
}
