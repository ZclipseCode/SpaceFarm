using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    private void Awake()
    {
        MoneyManager.UpdateMoney += UpdateText;

        text.text = $"${MoneyManager.currentMoney}";
    }

    void UpdateText()
    {
        text.text = $"${MoneyManager.currentMoney}";
    }

    private void OnDestroy()
    {
        MoneyManager.UpdateMoney -= UpdateText;
    }
}
