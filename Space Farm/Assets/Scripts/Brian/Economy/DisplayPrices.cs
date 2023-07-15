using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPrices : MonoBehaviour
{
    [Header("Seeds")]
    [SerializeField] TextMeshProUGUI eggplantSeeds;
    [SerializeField] TextMeshProUGUI pepperSeeds;
    [SerializeField] TextMeshProUGUI watermelonSeeds;
    Deposit deposit;

    [Header("Upgrades")]
    [SerializeField] TextMeshProUGUI damage;
    [SerializeField] TextMeshProUGUI attackSpeed;
    [SerializeField] TextMeshProUGUI range;
    [SerializeField] TextMeshProUGUI movementSpeed;
    [SerializeField] TextMeshProUGUI health;

    private void Start()
    {
        deposit = GetComponent<Deposit>();
        eggplantSeeds.text = $"${deposit.eggplantPrice}";
        pepperSeeds.text = $"${deposit.pepperPrice}";
        watermelonSeeds.text = $"${deposit.watermelonPrice}";

        damage.text = $"${deposit.damagePrice}";
        attackSpeed.text = $"${deposit.attackSpeedPrice}";
        range.text = $"${deposit.rangePrice}";
        movementSpeed.text = $"${deposit.movementSpeedPrice}";
        health.text = $"${deposit.healthPrice}";
    }
}
