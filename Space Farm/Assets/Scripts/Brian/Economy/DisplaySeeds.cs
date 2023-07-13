using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySeeds : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI eggplantSeedText;
    [SerializeField] TextMeshProUGUI pepperSeedText;
    [SerializeField] TextMeshProUGUI watermelonSeedText;

    private void Awake()
    {
        SeedManager.UpdateSeeds += UpdateText;

        eggplantSeedText.text = $"x{SeedManager.eggplantSeeds}";
        pepperSeedText.text = $"x{SeedManager.pepperSeeds}";
        watermelonSeedText.text = $"x{SeedManager.watermelonSeeds}";
    }

    public void UpdateText()
    {
        eggplantSeedText.text = $"x{SeedManager.eggplantSeeds}";
        pepperSeedText.text = $"x{SeedManager.pepperSeeds}";
        watermelonSeedText.text = $"x{SeedManager.watermelonSeeds}";
    }

    private void OnDestroy()
    {
        SeedManager.UpdateSeeds -= UpdateText;
    }
}
