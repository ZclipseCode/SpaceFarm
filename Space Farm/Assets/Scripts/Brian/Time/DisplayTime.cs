using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    DayCycle dayCycle;

    private void Start()
    {
        dayCycle = GetComponent<DayCycle>();
    }

    void Update()
    {
        text.text = $"Time: {dayCycle.GetCurrentTime()}";
    }
}
