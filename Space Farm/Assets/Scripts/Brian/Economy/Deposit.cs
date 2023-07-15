using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour
{
    [SerializeField] KeyCode interact; //put this on player
    [SerializeField] GameObject menu;

    [Header("Seeds")]
    [SerializeField] int eggplantValue;
    [SerializeField] int pepperValue;
    [SerializeField] int watermelonValue;
    [SerializeField] int weedsValue;

    public int eggplantPrice;
    public int pepperPrice;
    public int watermelonPrice;

    public static bool menuOpen;
    bool inBounds;

    [Header("Upgrades")]
    [SerializeField] int damageValue;
    [SerializeField] int attackSpeedValue;
    [SerializeField] int rangeValue;
    [SerializeField] int movementSpeedValue;
    [SerializeField] int healthValue;
    public int damagePrice;
    public int attackSpeedPrice;
    public int rangePrice;
    public int movementSpeedPrice;
    public int healthPrice;
    [SerializeField] PlayerUpgrades playerUpgrades;
    int[] totalUpgrades = new int[5];

    private void Start()
    {
        menu.SetActive(false);
    }

    private void Update()
    {
        if (inBounds)
        {
            if (Input.GetKeyDown(interact))
            {
                menuOpen = !menuOpen;

                if (menuOpen)
                {
                    menu.SetActive(true);
                }
                else
                {
                    menu.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inBounds = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        menuOpen = false;
        inBounds = false;
        menu.SetActive(false);
    }

    public void DepositCrops()
    {
        int sum = CropManager.eggplants * eggplantValue + CropManager.peppers * pepperValue
            + CropManager.watermelons * watermelonValue + CropManager.weeds * weedsValue;

        MoneyManager.overallMoney += sum;
        MoneyManager.currentMoney += sum;

        CropManager.eggplants = 0;
        CropManager.peppers = 0;
        CropManager.watermelons = 0;
        CropManager.weeds = 0;

        MoneyManager.UpdateMoney();
        CropManager.UpdateCrop();
    }

    public void BuySeeds(string cropName)
    {
        Enum.TryParse(cropName, out Crop crop);

        if (crop == Crop.Eggplant && MoneyManager.currentMoney >= eggplantPrice)
        {
            MoneyManager.currentMoney -= eggplantPrice;
            SeedManager.eggplantSeeds += 1;
        }
        else if (crop == Crop.Pepper && MoneyManager.currentMoney >= pepperPrice)
        {
            MoneyManager.currentMoney -= pepperPrice;
            SeedManager.pepperSeeds += 1;
        }
        else if (crop == Crop.Watermelon && MoneyManager.currentMoney >= watermelonPrice)
        {
            MoneyManager.currentMoney -= watermelonPrice;
            SeedManager.watermelonSeeds += 1;
        }

        MoneyManager.UpdateMoney();
        SeedManager.UpdateSeeds();
    }

    public void BuyUpgrade(string upgradeName)
    {
        Enum.TryParse(upgradeName, out Upgrade upgrade);

        if (upgrade == Upgrade.Damage && totalUpgrades[0] <= 2 && MoneyManager.currentMoney >= damagePrice)
        {
            MoneyManager.currentMoney -= damagePrice;
            totalUpgrades[0]++;
            playerUpgrades.IncreaseDamage(damageValue);
        }
        else if (upgrade == Upgrade.AttackSpeed && totalUpgrades[1] <= 2 && MoneyManager.currentMoney >= attackSpeedPrice)
        {
            MoneyManager.currentMoney -= attackSpeedPrice;
            totalUpgrades[1]++;
            playerUpgrades.IncreaseAttackRate(attackSpeedValue);
        }
        else if (upgrade == Upgrade.Range && totalUpgrades[2] <= 2 && MoneyManager.currentMoney >= rangePrice)
        {
            MoneyManager.currentMoney -= rangePrice;
            totalUpgrades[2]++;
            playerUpgrades.IncreaseRange(rangeValue);
        }
        else if (upgrade == Upgrade.MovementSpeed && totalUpgrades[3] <= 2 && MoneyManager.currentMoney >= movementSpeedPrice)
        {
            MoneyManager.currentMoney -= movementSpeedPrice;
            totalUpgrades[3]++;
            playerUpgrades.IncreaseSpeed(movementSpeedValue);
        }
        else if (upgrade == Upgrade.Health && totalUpgrades[4] <= 2 && MoneyManager.currentMoney >= healthPrice)
        {
            MoneyManager.currentMoney -= healthPrice;
            totalUpgrades[4]++;
            playerUpgrades.IncreaseHealth(healthValue);
        }

        MoneyManager.UpdateMoney();
    }
}
