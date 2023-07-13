using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    public static int eggplantSeeds;
    public static int pepperSeeds;
    public static int watermelonSeeds;

    public delegate void UpdateSeedsDelegate();
    public static UpdateSeedsDelegate UpdateSeeds;
}
