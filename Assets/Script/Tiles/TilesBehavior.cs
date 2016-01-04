﻿using UnityEngine;
using System.Collections;

public class TilesBehavior : MonoBehaviour {
    public GameObject greenCircle;
    private GameObject circle;
    public bool constructible;
    public GameObject right;
    public GameObject down;
    public GameObject top;
    public GameObject left;
    public bool gameEntrance;

	void Start () {
        if (constructible)
        {
            circle = Instantiate(greenCircle, transform.position, Quaternion.identity) as GameObject;
            circle.transform.parent = transform;
        }
        if (right != null)
        {
            right.GetComponent<TilesBehavior>().setLeft(gameObject);
        }
        if (down != null)
        {
            down.GetComponent<TilesBehavior>().setTop(gameObject);
        }
    }
	
    public void setLeft(GameObject leftNew)
    {
        left = leftNew;
    }
    public void setTop(GameObject topNew)
    {
        top = topNew;
    }
    // Update is called once per frame
    void Update () {
	
	}
    public void setConstructible (bool constructibleNew)
    {
        if (constructible != constructibleNew) {
            constructible = constructibleNew;
            if (!constructible)
            {
                Destroy(circle);
            }
            else
            {
               circle = Instantiate(greenCircle, transform.position, Quaternion.identity) as GameObject;
                circle.transform.parent = transform;
            }
        }
    }
    void OnMouseDown()
    {
        if (GameUtilities.Instance.roadCreating)
        {
            if (!GetComponent<RoadBehavior>().activated)
            {
                if (constructible)
                {
                    GetComponent<RoadBehavior>().Activate();
                }
            }
            else
            {
                if (!gameEntrance)
                {
                    GetComponent<RoadBehavior>().Desactivate();
                }
            }
        }else if (GameUtilities.Instance.constructing)
        {
            if (isConstructibleRight(GameUtilities.Instance.building.GetComponent<Building>().width))
            {
                if (isConstructibleTop(GameUtilities.Instance.building.GetComponent<Building>().height))
                {
                    GetComponent<BuildingBehavior>().Activate();
                }
            }
        }
    }

    public bool isConstructibleRight(int x)
    {
        if (!constructible)
        {
            return false;
        }
        else
        {
            if (x == 1)
            {
                return true;
            }
            else
            {
                if (right != null)
                {
                    return right.GetComponent<TilesBehavior>().isConstructibleRight(x - 1);

                }
                else
                {
                    return false;
                }
            }
        }
    }
    public bool isConstructibleTop(int y)
    {
        if (!constructible)
        {
            return false;
        }
        else
        {
            if (y == 1)
            {
                return true;
            }
            else
            {
                if (top != null)
                {
                    return top.GetComponent<TilesBehavior>().isConstructibleTop(y - 1);

                }
                else
                {
                    return false;
                }
            }
        }
    }

}
