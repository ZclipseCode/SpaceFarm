using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int overallMoney;
    public static int currentMoney;
    public static int cropsToSellMoney;

    public delegate void UpdateMoneyDelegate();
    public static UpdateMoneyDelegate UpdateMoney;
}
