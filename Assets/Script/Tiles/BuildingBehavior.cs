using UnityEngine;
using System.Collections;

public class BuildingBehavior : MonoBehaviour {
    public GameObject[][] tiles;
    public int placeX;
    public int placeY;
    public GameObject building;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Activate()
    {
        if (GameUtilities.Instance.money >= GameUtilities.Instance.building.GetComponent<Building>().price)
        {
            GameUtilities.Instance.DesactiveConstructing();
            GameObject newBuilding = Instantiate(GameUtilities.Instance.building, transform.position, Quaternion.identity) as GameObject;
            GameUtilities.Instance.ChangeMoney(-GameUtilities.Instance.building.GetComponent<Building>().price);
            newBuilding.transform.parent = transform;
            GameObject[][] newTiles = new GameObject[newBuilding.GetComponent<Building>().height][];
            for (int i = 0; i < newBuilding.GetComponent<Building>().height; i++)
            {
                newTiles[i] = new GameObject[newBuilding.GetComponent<Building>().width];
            }
            Recursive(newBuilding, newBuilding.GetComponent<Building>().width, newBuilding.GetComponent<Building>().height, newTiles);
            newBuilding.SetActive(true);
        }
    }
    public void Recursive(GameObject newBuilding, int width, int height, GameObject[][] newTiles)
    {
        if (GetComponent<TilesBehavior>().constructible)
        {
            GetComponent<TilesBehavior>().setConstructible(false, newBuilding.GetComponent<Building>());
            building = newBuilding;
            tiles = newTiles;
            tiles[tiles.Length - height][tiles[0].Length - width] = gameObject;
            placeX = tiles[0].Length - width;
            placeY = tiles.Length - height;
            if (width > 1)
            {
                GetComponent<TilesBehavior>().right.GetComponent<BuildingBehavior>().Recursive(newBuilding, width - 1, height, newTiles);
            }
            if (height > 1)
            {
                GetComponent<TilesBehavior>().top.GetComponent<BuildingBehavior>().Recursive(newBuilding, width, height - 1, newTiles);
            }
            CheckEntrance();
        }
    }

    public void CheckEntrance()
    {
        if (building != null)
        {
            if (building.GetComponent<Building>().entranceX == placeX && building.GetComponent<Building>().entranceY == placeY)
            {
                building.GetComponent<Building>().setEntrance(null);
                if (GetComponent<TilesBehavior>().left != null && GetComponent<TilesBehavior>().left.GetComponent<RoadBehavior>().distanceToEntrance != -1)
                {
                    building.GetComponent<Building>().setEntrance(GetComponent<TilesBehavior>().left);
                }
                else if (GetComponent<TilesBehavior>().top != null && GetComponent<TilesBehavior>().top.GetComponent<RoadBehavior>().distanceToEntrance != -1)
                {
                    building.GetComponent<Building>().setEntrance(GetComponent<TilesBehavior>().top);
                }
                else if (GetComponent<TilesBehavior>().right != null && GetComponent<TilesBehavior>().right.GetComponent<RoadBehavior>().distanceToEntrance != -1)
                {
                    building.GetComponent<Building>().setEntrance(GetComponent<TilesBehavior>().right);
                }
                else if (GetComponent<TilesBehavior>().down != null && GetComponent<TilesBehavior>().down.GetComponent<RoadBehavior>().distanceToEntrance != -1)
                {
                    building.GetComponent<Building>().setEntrance(GetComponent<TilesBehavior>().down);
                }
            }
        }
    }
}
