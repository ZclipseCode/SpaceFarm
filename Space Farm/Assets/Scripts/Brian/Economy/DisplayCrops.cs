using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayCrops : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI eggplantText;
    [SerializeField] TextMeshProUGUI pepperText;
    [SerializeField] TextMeshProUGUI watermelonText;
    [SerializeField] TextMeshProUGUI weedsText;

    private void Awake()
    {
        CropManager.UpdateCrop += UpdateText;

        eggplantText.text = $"x{CropManager.eggplants}";
        pepperText.text = $"x{CropManager.peppers}";
        watermelonText.text = $"x{CropManager.watermelons}";
        weedsText.text = $"x{CropManager.weeds}";
    }

    void UpdateText()
    {
        eggplantText.text = $"x{CropManager.eggplants}";
        pepperText.text = $"x{CropManager.peppers}";
        watermelonText.text = $"x{CropManager.watermelons}";
        weedsText.text = $"x{CropManager.weeds}";
    }

    private void OnDestroy()
    {
        CropManager.UpdateCrop -= UpdateText;
    }
}
