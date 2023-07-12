using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CropItem : MonoBehaviour
{
    [SerializeField] Crop crop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (crop == Crop.Eggplant)
            {
                CropManager.eggplants++;
            }
            else if (crop == Crop.Pepper)
            {
                CropManager.peppers++;
            }
            else if (crop == Crop.Watermelon)
            {
                CropManager.watermelons++;
            }

            CropManager.UpdateCrop();
            Destroy(gameObject);
        }
    }
}
