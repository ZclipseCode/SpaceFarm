using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    [SerializeField] int eggplantValue;
    [SerializeField] int pepperValue;
    [SerializeField] int watermelonValue;

    public static int eggplants;
    public static int peppers;
    public static int watermelons;

    public delegate void UpdateCropDelegate();
    public static UpdateCropDelegate UpdateCrop;
}
