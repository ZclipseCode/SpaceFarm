using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGrowth : MonoBehaviour
{
    [SerializeField] GameObject eggplantAlien;
    [SerializeField] GameObject pepperAlien;
    [SerializeField] GameObject watermelonAlien;
    [SerializeField] GameObject weedsAlien;

    public void FullGrowth(Crop crop, Vector3 pos)
    {
        if (crop == Crop.Eggplant)
        {
            Instantiate(eggplantAlien, pos, Quaternion.identity);
        }
        else if (crop == Crop.Pepper)
        {
            Instantiate(pepperAlien, pos, Quaternion.identity);
        }
        else if (crop == Crop.Watermelon)
        {
            Instantiate(watermelonAlien, pos, Quaternion.identity);
        }
        else if (crop == Crop.Weeds)
        {
            Instantiate(weedsAlien, pos, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
