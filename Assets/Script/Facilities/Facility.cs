using UnityEngine;
using System.Collections.Generic;
using System;

public class Facility : MonoBehaviour, IComparable<Facility>
{
    public int price;

    public int CompareTo(Facility other)
    {
        if (price > other.price) return 1;
        else if (price < other.price) return -1;
        else return 0;
    }

    public void Use(PnjBehavior pnj)
    {
        pnj.money = pnj.money - price;
        pnj.shop = pnj.shop - price;
        GameUtilities.Instance.ChangeMoney(price);
    }
}
