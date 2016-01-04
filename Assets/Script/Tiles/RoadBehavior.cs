using UnityEngine;
using System.Collections;

public class RoadBehavior : MonoBehaviour {
    public bool activated = false;
    public int distanceToEntrance = -1;
    public GameObject[] roads = new GameObject[16];
    private bool[] adjacent = new bool[4];
    private GameObject road;

    void Start () {
        adjacent[0] = false;
        adjacent[1] = false;
        adjacent[2] = false;
        adjacent[3] = false;
        if (activated)
        {
            AdRoad();
        }
	}

    public void Activate()
    {
        if (!activated)
        {
            activated = true;
            ReloadRoad();
        }
    }
    public void Desactivate()
    {
        if (activated)
        {
            activated = false;
            DestroyRoad();
        }
    }

    void ReloadRoad()
    {
        bool oldRoad = false;
        if (road != null)
        {
            oldRoad = true;
            Destroy(road);
        }
        CheckAdjacent();
        if (!oldRoad)
        {
            CheckLinkedToEntrance();
        }
        AdRoad();
    }
    void DestroyRoad()
    {
        if (road != null)
        {
            DesactivateAdjacent();
            DesactivateLink();
            GetComponent<TilesBehavior>().setConstructible(true);
            Destroy(road);
        }
    }

    void CheckAdjacent()
    {
        if (GetComponent<TilesBehavior>().left!= null)
        {
            GetComponent<TilesBehavior>().left.GetComponent<RoadBehavior>().isActivatedRight();
            if (GetComponent<TilesBehavior>().left.GetComponent<RoadBehavior>().activated)
            {
                adjacent[0] = true;
            }
        }
        if (GetComponent<TilesBehavior>().top != null)
        {
            GetComponent<TilesBehavior>().top.GetComponent<RoadBehavior>().isActivatedBottom();
            if (GetComponent<TilesBehavior>().top.GetComponent<RoadBehavior>().activated)
            {
                adjacent[1] = true;
            }
        }
        if (GetComponent<TilesBehavior>().right != null)
        {
            GetComponent<TilesBehavior>().right.GetComponent<RoadBehavior>().isActivatedLeft();
            if (GetComponent<TilesBehavior>().right.GetComponent<RoadBehavior>().activated)
            {
                adjacent[2] = true;
            }
        }
        if (GetComponent<TilesBehavior>().down != null)
        {
            GetComponent<TilesBehavior>().down.GetComponent<RoadBehavior>().isActivatedTop();
            if (GetComponent<TilesBehavior>().down.GetComponent<RoadBehavior>().activated)
            {
                adjacent[3] = true;
            }
        }
    }
    void DesactivateAdjacent()
    {
        if (GetComponent<TilesBehavior>().left != null)
        {
            GetComponent<TilesBehavior>().left.GetComponent<RoadBehavior>().desactivateRight();
        }
        if (GetComponent<TilesBehavior>().top != null)
        {
            GetComponent<TilesBehavior>().top.GetComponent<RoadBehavior>().desactivateBottom();
        }
        if (GetComponent<TilesBehavior>().right != null)
        {
            GetComponent<TilesBehavior>().right.GetComponent<RoadBehavior>().desactivateLeft();
        }
        if (GetComponent<TilesBehavior>().down != null)
        {
            GetComponent<TilesBehavior>().down.GetComponent<RoadBehavior>().desactivateTop();
        }
    }

    void CheckLinkedToEntrance()
    {
        if (!GetComponent<TilesBehavior>().gameEntrance)
        {
            int oldDistance = distanceToEntrance;
            distanceToEntrance = 999;
            if (adjacent[0])
            {
                if (GetComponent<TilesBehavior>().left.GetComponent<RoadBehavior>().distanceToEntrance != -1)
                {
                    distanceToEntrance = Mathf.Min(distanceToEntrance, GetComponent<TilesBehavior>().left.GetComponent<RoadBehavior>().distanceToEntrance + 1);
                }
            }
            if (adjacent[1])
            {
                if (GetComponent<TilesBehavior>().top.GetComponent<RoadBehavior>().distanceToEntrance != -1)
                {
                    distanceToEntrance = Mathf.Min(distanceToEntrance, GetComponent<TilesBehavior>().top.GetComponent<RoadBehavior>().distanceToEntrance + 1);
                }
            }
            if (adjacent[2])
            {
                if (GetComponent<TilesBehavior>().right.GetComponent<RoadBehavior>().distanceToEntrance != -1)
                {
                    distanceToEntrance = Mathf.Min(distanceToEntrance, GetComponent<TilesBehavior>().right.GetComponent<RoadBehavior>().distanceToEntrance + 1);
                }
            }
            if (adjacent[3])
            {
                if (GetComponent<TilesBehavior>().down.GetComponent<TilesBehavior>().gameEntrance || GetComponent<TilesBehavior>().down.GetComponent<RoadBehavior>().distanceToEntrance != -1)
                {
                    distanceToEntrance = Mathf.Min(distanceToEntrance, GetComponent<TilesBehavior>().down.GetComponent<RoadBehavior>().distanceToEntrance + 1);
                }
            }
            if (distanceToEntrance == 999)
            {
                distanceToEntrance = -1;
            }
            if (oldDistance != distanceToEntrance)
            {
                checkBuilding();
                if (adjacent[0])
                {
                    GetComponent<TilesBehavior>().left.GetComponent<RoadBehavior>().Link(distanceToEntrance + 1);
                }
                if (adjacent[1])
                {
                    GetComponent<TilesBehavior>().top.GetComponent<RoadBehavior>().Link(distanceToEntrance + 1);
                }
                if (adjacent[2])
                {
                    GetComponent<TilesBehavior>().right.GetComponent<RoadBehavior>().Link(distanceToEntrance + 1);
                }
                if (adjacent[3])
                {
                    GetComponent<TilesBehavior>().down.GetComponent<RoadBehavior>().Link(distanceToEntrance + 1);
                }
            }
        }
    }
    public void Link(int distance)
    {
        if (distanceToEntrance == -1 || distanceToEntrance > distance )
        {
            CheckLinkedToEntrance();
        }
    }
    public void DesactivateLink()
    {
        int oldDistance = distanceToEntrance;
            distanceToEntrance = -1;
            if (adjacent[0] && GetComponent<TilesBehavior>().left.GetComponent<RoadBehavior>().distanceToEntrance==oldDistance+1)
            {
                GetComponent<TilesBehavior>().left.GetComponent<RoadBehavior>().DesactivateLinkChain();
            }
            if (adjacent[1] && GetComponent<TilesBehavior>().top.GetComponent<RoadBehavior>().distanceToEntrance == oldDistance + 1)
            {
                GetComponent<TilesBehavior>().top.GetComponent<RoadBehavior>().DesactivateLinkChain();
            }
            if (adjacent[2] && GetComponent<TilesBehavior>().right.GetComponent<RoadBehavior>().distanceToEntrance == oldDistance + 1)
            {
                GetComponent<TilesBehavior>().right.GetComponent<RoadBehavior>().DesactivateLinkChain();
            }
            if (adjacent[3] && GetComponent<TilesBehavior>().down.GetComponent<RoadBehavior>().distanceToEntrance == oldDistance + 1)
            {
                GetComponent<TilesBehavior>().down.GetComponent<RoadBehavior>().DesactivateLinkChain();
            }
        checkBuilding();
    }
    public void DesactivateLinkChain()
    {
        if (!((adjacent[0] && GetComponent<TilesBehavior>().left.GetComponent<RoadBehavior>().distanceToEntrance == distanceToEntrance - 1)
            ||(adjacent[1] && GetComponent<TilesBehavior>().top.GetComponent<RoadBehavior>().distanceToEntrance == distanceToEntrance - 1)
            || (adjacent[2] && GetComponent<TilesBehavior>().right.GetComponent<RoadBehavior>().distanceToEntrance == distanceToEntrance - 1)
            ||(adjacent[3] && GetComponent<TilesBehavior>().down.GetComponent<RoadBehavior>().distanceToEntrance == distanceToEntrance - 1)))
        {
            DesactivateLink();
            CheckLinkedToEntrance();
        }
    }

    void checkBuilding()
    {
        if (GetComponent<TilesBehavior>().left != null && GetComponent<TilesBehavior>().left.GetComponent<BuildingBehavior>().building != null)
        {
            GetComponent<TilesBehavior>().left.GetComponent<BuildingBehavior>().CheckEntrance();
        }
        if (GetComponent<TilesBehavior>().top != null && GetComponent<TilesBehavior>().top.GetComponent<BuildingBehavior>().building != null)
        {
            GetComponent<TilesBehavior>().top.GetComponent<BuildingBehavior>().CheckEntrance();
        }
        if (GetComponent<TilesBehavior>().right != null && GetComponent<TilesBehavior>().right.GetComponent<BuildingBehavior>().building != null)
        {
            GetComponent<TilesBehavior>().right.GetComponent<BuildingBehavior>().CheckEntrance();
        }
        if (GetComponent<TilesBehavior>().down != null && GetComponent<TilesBehavior>().down.GetComponent<BuildingBehavior>().building != null)
        {
            GetComponent<TilesBehavior>().down.GetComponent<BuildingBehavior>().CheckEntrance();
        }
    }
    public void isActivatedLeft()
    {
        if (!adjacent[0])
        {
            adjacent[0] = true;
            if (activated)
            {
                ReloadRoad();
            }
        }
    }
    public void isActivatedTop()
    {
        if (!adjacent[1])
        {
            adjacent[1] = true;
            if (activated)
            {
                ReloadRoad();
            }
        }
    }
    public void isActivatedRight()
    {
        if (!adjacent[2])
        {
            adjacent[2] = true;
            if (activated)
            {
                ReloadRoad();
            }
        }
    }
    public void isActivatedBottom()
    {
        if (!adjacent[3])
        {
            adjacent[3] = true;
            if (activated)
            {
                ReloadRoad();
            }
        }
    }
    public void desactivateLeft()
    {
        if (adjacent[0])
        {
            adjacent[0] = false;
            if (activated)
            {
                ReloadRoad();
            }
        }
    }
    public void desactivateTop()
    {
        if (adjacent[1])
        {
            adjacent[1] = false;
            if (activated)
            {
                ReloadRoad();
            }
        }
    }
    public void desactivateRight()
    {
        if (adjacent[2])
        {
            adjacent[2] = false;
            if (activated)
            {
                ReloadRoad();
            }
        }
    }
    public void desactivateBottom()
    {
        if (adjacent[3])
        {
            adjacent[3] = false;
            if (activated)
            {
                ReloadRoad();
            }
        }
    }

    void AdRoad()
    {
        if (road != null)
        {
            Destroy(road);
        }
        GetComponent<TilesBehavior>().setConstructible(false);
            if (adjacent[0])
            {
                if (adjacent[1])
                {
                    if (adjacent[2])
                    {
                        if (adjacent[3])
                        {
                            road = Instantiate(roads[15], transform.position, Quaternion.identity) as GameObject;
                        }
                        else
                        {
                            road = Instantiate(roads[11], transform.position, Quaternion.identity) as GameObject;
                        }
                    }
                    else
                    {
                        if (adjacent[3])
                        {
                            road = Instantiate(roads[12], transform.position, Quaternion.identity) as GameObject;
                        }
                        else
                        {
                            road = Instantiate(roads[5], transform.position, Quaternion.identity) as GameObject;
                        }
                    }
                }
                else
                {
                    if (adjacent[2])
                    {
                        if (adjacent[3])
                        {
                            road = Instantiate(roads[13], transform.position, Quaternion.identity) as GameObject;
                        }
                        else
                        {
                            road = Instantiate(roads[6], transform.position, Quaternion.identity) as GameObject;
                        }
                    }
                    else
                    {
                        if (adjacent[3])
                        {
                            road = Instantiate(roads[7], transform.position, Quaternion.identity) as GameObject;
                        }
                        else
                        {
                            road = Instantiate(roads[1], transform.position, Quaternion.identity) as GameObject;
                        }
                    }
                }
            }
            else
            {
                if (adjacent[1])
                {
                    if (adjacent[2])
                    {
                        if (adjacent[3])
                        {
                            road = Instantiate(roads[14], transform.position, Quaternion.identity) as GameObject;
                        }
                        else
                        {
                            road = Instantiate(roads[8], transform.position, Quaternion.identity) as GameObject;
                        }
                    }
                    else
                    {
                        if (adjacent[3])
                        {
                            road = Instantiate(roads[9], transform.position, Quaternion.identity) as GameObject;
                        }
                        else
                        {
                            road = Instantiate(roads[2], transform.position, Quaternion.identity) as GameObject;
                        }
                    }
                }
                else
                {
                    if (adjacent[2])
                    {
                        if (adjacent[3])
                        {
                            road = Instantiate(roads[10], transform.position, Quaternion.identity) as GameObject;
                        }
                        else
                        {
                            road = Instantiate(roads[3], transform.position, Quaternion.identity) as GameObject;
                        }
                    }
                    else
                    {
                        if (adjacent[3])
                        {
                            road = Instantiate(roads[4], transform.position, Quaternion.identity) as GameObject;
                        }
                        else
                        {
                            road = Instantiate(roads[0], transform.position, Quaternion.identity) as GameObject;
                        }
                    }
                }
            }
            road.transform.parent = transform;
        }
}
