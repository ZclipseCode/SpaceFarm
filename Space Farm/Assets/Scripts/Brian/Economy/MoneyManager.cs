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
    public static bool singleton;

    private void Start()
    {
        if (!singleton)
        {
            overallMoney = startingMoney;
            currentMoney = startingMoney;
            singleton = true;
        }
        
        UpdateMoney();
    }
}
