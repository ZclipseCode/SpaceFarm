using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    [SerializeField] Vector3 originPos;
    [SerializeField] int x;
    [SerializeField] int y;
    [SerializeField] float cellSize;
    [SerializeField] Camera cam;
    PlantGrid grid;

    private void Start()
    {
        grid = new PlantGrid(x, y, cellSize, originPos);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(GetMouseWorldPosition(), 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(GetMouseWorldPosition()));
        }
    }

    public Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;

        return worldPos;
    }
}
