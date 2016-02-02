using UnityEngine;
using System.Collections.Generic;
using System;

public class Facility : MonoBehaviour, IComparable<Facility>
{
    public int price;
    void Start()
    {
        GameList.Instance.Facilities.Add(this);
    }
    public int CompareTo(Facility other)
    {
        if (price > other.price) return 1;
        else if (price < other.price) return -1;
        else return 0;
    }

    public void Use(PnjBehavior pnj)
    {
        pnj.gains[0] = pnj.gains[0] - price;
        pnj.shop = pnj.shop - price;
        pnj.gains[2] = pnj.gains[2] + price;
        GetComponent<Building>().gains[1] = GetComponent<Building>().gains[1] + price;
    }
}
