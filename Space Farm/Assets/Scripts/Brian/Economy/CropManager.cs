using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    public static int eggplants;
    public static int peppers;
    public static int watermelons;
    public static int weeds;

    public delegate void UpdateCropDelegate();
    public static UpdateCropDelegate UpdateCrop;
}
