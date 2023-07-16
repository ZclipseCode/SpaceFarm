using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Results : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI total;

    private void Start()
    {
        total.text = $"${MoneyManager.overallMoney}";
    }

    public void ResetMoney()
    {
        MoneyManager.overallMoney = 0;
        MoneyManager.currentMoney = 0;
        MoneyManager.singleton = false;
    }
}
