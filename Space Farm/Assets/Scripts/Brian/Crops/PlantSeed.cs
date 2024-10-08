using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour
{
    Crop crop;
    [SerializeField] HighlightTilemap highlightTilemap;
    [SerializeField] GameObject eggplantSeed;
    [SerializeField] GameObject pepperSeed;
    [SerializeField] GameObject watermelonSeed;
    [SerializeField] float eggplantGrowthTime;
    [SerializeField] float pepperGrowthTime;
    [SerializeField] float watermelonGrowthTime;

    float scroll;
    [SerializeField] GameObject[] selectionLines;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Deposit.menuOpen)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (!hit.collider.CompareTag("Plant"))
            {
                StartCoroutine(Plant(highlightTilemap.GetWorldPosition(Input.mousePosition), crop));
            }
        }

        if (selectionLines[0] != null)
        {
            SelectSeed();
        }
    }

    IEnumerator Plant(Vector3 pos, Crop c)
    {
        if (c == Crop.Eggplant && SeedManager.eggplantSeeds > 0)
        {
            GameObject es = Instantiate(eggplantSeed, pos, Quaternion.identity);

            SeedManager.eggplantSeeds--;
            SeedManager.UpdateSeeds?.Invoke();

            yield return new WaitForSeconds(eggplantGrowthTime);

            es.GetComponent<SeedGrowth>().FullGrowth(c, pos);
        }
        else if (c == Crop.Pepper && SeedManager.pepperSeeds > 0)
        {
            GameObject ps = Instantiate(pepperSeed, pos, Quaternion.identity);

            SeedManager.pepperSeeds--;
            SeedManager.UpdateSeeds?.Invoke();

            yield return new WaitForSeconds(pepperGrowthTime);

            ps.GetComponent<SeedGrowth>().FullGrowth(c, pos);
        }
        else if (c == Crop.Watermelon && SeedManager.watermelonSeeds > 0)
        {
            GameObject ws = Instantiate(watermelonSeed, pos, Quaternion.identity);

            SeedManager.watermelonSeeds--;
            SeedManager.UpdateSeeds?.Invoke();

            yield return new WaitForSeconds(watermelonGrowthTime);

            ws.GetComponent<SeedGrowth>().FullGrowth(c, pos);
        }
    }

    void SelectSeed()
    {
        scroll += Input.mouseScrollDelta.y;

        if (scroll > 2)
        {
            scroll = 0;
        }
        if (scroll < 0)
        {
            scroll = 2;
        }

        if (scroll == 0)
        {
            crop = Crop.Eggplant;
            for (int i = 0; i < selectionLines.Length; i++)
            {
                if (i == 0)
                {
                    selectionLines[i].SetActive(true);
                }
                else
                {
                    selectionLines[i].SetActive(false);
                }
            }
        }
        else if (scroll == 1)
        {
            crop = Crop.Pepper;
            for (int i = 0; i < selectionLines.Length; i++)
            {
                if (i == 1)
                {
                    selectionLines[i].SetActive(true);
                }
                else
                {
                    selectionLines[i].SetActive(false);
                }
            }
        }
        else if (scroll == 2)
        {
            crop = Crop.Watermelon;
            for (int i = 0; i < selectionLines.Length; i++)
            {
                if (i == 2)
                {
                    selectionLines[i].SetActive(true);
                }
                else
                {
                    selectionLines[i].SetActive(false);
                }
            }
        }
    }
}
