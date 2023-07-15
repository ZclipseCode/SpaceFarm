using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour
{
    [SerializeField] Crop crop;
    [SerializeField] HighlightTilemap highlightTilemap;
    [SerializeField] GameObject eggplantSeed;
    [SerializeField] GameObject pepperSeed;
    [SerializeField] GameObject watermelonSeed;
    [SerializeField] float eggplantGrowthTime;
    [SerializeField] float pepperGrowthTime;
    [SerializeField] float watermelonGrowthTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (!hit.collider.CompareTag("Plant"))
            {
                StartCoroutine(Plant(highlightTilemap.GetWorldPosition(Input.mousePosition)));
            }
        }

        // scroll
    }

    IEnumerator Plant(Vector3 pos)
    {
        if (crop == Crop.Eggplant && SeedManager.eggplantSeeds > 0)
        {
            GameObject es = Instantiate(eggplantSeed, pos, Quaternion.identity);

            yield return new WaitForSeconds(eggplantGrowthTime);

            es.GetComponent<SeedGrowth>().FullGrowth(crop, pos);
        }
        else if (crop == Crop.Pepper && SeedManager.pepperSeeds > 0)
        {
            GameObject ps = Instantiate(pepperSeed, pos, Quaternion.identity);

            yield return new WaitForSeconds(pepperGrowthTime);

            ps.GetComponent<SeedGrowth>().FullGrowth(crop, pos);
        }
        else if (crop == Crop.Watermelon && SeedManager.watermelonSeeds > 0)
        {
            GameObject ws = Instantiate(watermelonSeed, pos, Quaternion.identity);

            yield return new WaitForSeconds(watermelonGrowthTime);

            ws.GetComponent<SeedGrowth>().FullGrowth(crop, pos);
        }
    }
}
