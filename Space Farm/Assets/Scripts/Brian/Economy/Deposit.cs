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

    bool menuOpen;
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
}
