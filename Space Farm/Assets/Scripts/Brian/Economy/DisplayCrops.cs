using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayCrops : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI eggplantText;
    [SerializeField] TextMeshProUGUI pepperText;
    [SerializeField] TextMeshProUGUI watermelonText;

    private void Awake()
    {
        CropManager.UpdateCrop += UpdateText;

        eggplantText.text = $"x{CropManager.eggplants}";
        pepperText.text = $"x{CropManager.peppers}";
        watermelonText.text = $"x{CropManager.watermelons}";
    }

    void UpdateText()
    {
        eggplantText.text = $"x{CropManager.eggplants}";
        pepperText.text = $"x{CropManager.peppers}";
        watermelonText.text = $"x{CropManager.watermelons}";
    }

    private void OnDestroy()
    {
        CropManager.UpdateCrop -= UpdateText;
    }
}
