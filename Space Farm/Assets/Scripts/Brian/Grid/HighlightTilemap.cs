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

    Tile currentTile;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnMouseOver()
    {
        if (!firstTileFound)
        {
            currentTilePos = GetWorldPosition(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(GetWorldPosition(Input.mousePosition)), highlightTile);

            currentTile = tilemap.GetTile<Tile>(tilemap.WorldToCell(GetWorldPosition(Input.mousePosition)));

            firstTileFound = true;
        }

        if (currentTilePos != GetWorldPosition(Input.mousePosition))
        {
            tilemap.SetTile(Vector3Int.FloorToInt(currentTilePos), defaultTile);

            currentTilePos = GetWorldPosition(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(GetWorldPosition(Input.mousePosition)), highlightTile);

            currentTile = tilemap.GetTile<Tile>(tilemap.WorldToCell(GetWorldPosition(Input.mousePosition)));
        }
    }

    public Vector3 GetWorldPosition(Vector3 pos)
    {
        Vector3 worldPos = cam.ScreenToWorldPoint(pos);
        worldPos.z = 0;

        return worldPos;
    }

    public Tile GetCurrentTile()
    {
        return currentTile;
    }
}
