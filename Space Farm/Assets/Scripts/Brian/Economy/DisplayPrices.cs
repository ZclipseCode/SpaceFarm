using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPrices : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI eggplantSeeds;
    [SerializeField] TextMeshProUGUI pepperSeeds;
    [SerializeField] TextMeshProUGUI watermelonSeeds;
    Deposit deposit;

    private void Start()
    {
        deposit = GetComponent<Deposit>();
        eggplantSeeds.text = $"${deposit.eggplantPrice}";
        pepperSeeds.text = $"${deposit.pepperPrice}";
        watermelonSeeds.text = $"${deposit.watermelonPrice}";
    }
}
