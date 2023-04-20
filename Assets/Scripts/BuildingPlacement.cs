using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingPlacement : MonoBehaviour
{
    public Tilemap tilemap; // The tilemap to place the building on
    //public ResourceSystem resourceSystem; // The resource management system

    private GameObject currentBuilding; // The building currently being placed
    private bool isBuildingPlaced = false; // Whether a building has been placed

    void Update()
    {
        if (currentBuilding != null && !isBuildingPlaced)
        {
            Debug.Log("Script if 1");
            // Get the tile position of the mouse cursor
            Vector3Int tilePos = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            // Snap the building to the nearest tile
            Vector3 snapPos = tilemap.GetCellCenterWorld(tilePos);
            currentBuilding.transform.position = snapPos;

            // Place the building when the left mouse button is clicked
            if (Input.GetMouseButtonDown(0))
            {
                // Check if the player has enough resources to place the building
                //if (resourceSystem.HasEnoughResources(currentBuilding.GetComponent<Building>().cost))
                //{
                    // Deduct the cost of the building from the player's resources
                    //resourceSystem.DeductResources(currentBuilding.GetComponent<Building>().cost);

                    // Mark the building as placed
                    isBuildingPlaced = true;
                //}
            }
            // Cancel building placement when the right mouse button is clicked
            else if (Input.GetMouseButtonDown(1))
            {
                Destroy(currentBuilding);
                currentBuilding = null;
            }
        }
    }

    public void StartPlacingBuilding(GameObject buildingPrefab)
    {
        // Instantiate the building prefab
        currentBuilding = Instantiate(buildingPrefab);
        currentBuilding.transform.SetParent(GameObject.Find("Buildings").transform);

        // Mark the building as not placed
        isBuildingPlaced = false;
    }
}
