using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour
{
    [SerializeField] KeyCode interact; //put this on player
    [SerializeField] GameObject menu;

    [SerializeField] int eggplantValue;
    [SerializeField] int pepperValue;
    [SerializeField] int watermelonValue;
    [SerializeField] int weedsValue;

    public int eggplantPrice;
    public int pepperPrice;
    public int watermelonPrice;

    public static bool menuOpen;
    bool inBounds;

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
}
