using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightTilemap : MonoBehaviour
{
    [SerializeField] Tile defaultTile;
    [SerializeField] Tile highlightTile;
    [SerializeField] Camera cam;
    Tilemap tilemap;
    Vector3 currentTilePos;
    bool firstTileFound;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnMouseOver()
    {
        if (!firstTileFound)
        {
            currentTilePos = GetMouseWorldPosition(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(GetMouseWorldPosition(Input.mousePosition)), highlightTile);

            firstTileFound = true;
        }

        if (currentTilePos != GetMouseWorldPosition(Input.mousePosition))
        {
            tilemap.SetTile(Vector3Int.FloorToInt(currentTilePos), defaultTile);

            currentTilePos = GetMouseWorldPosition(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(GetMouseWorldPosition(Input.mousePosition)), highlightTile);
        }
    }

    public Vector3 GetMouseWorldPosition(Vector3 pos)
    {
        Vector3 worldPos = cam.ScreenToWorldPoint(pos);
        worldPos.z = 0;

        return worldPos;
    }
}
