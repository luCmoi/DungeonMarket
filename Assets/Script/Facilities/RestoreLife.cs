using UnityEngine;
using System.Collections.Generic;
using System;

public class RestoreLife : MonoBehaviour, IComparable<RestoreLife>
{
    public int clientMax;
    public int clientNumb;
    public PnjBehavior[] clients;
    public int[] time;
    public int timeRestore;
    public int lifePerTime;
    public int tick;
    // Use this for initialization
    void Start()
    {
        GameList.Instance.Facilities.Add(GetComponent<Facility>());
        GameList.Instance.RestoreLifes.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (GameUtilities.Instance.tick != tick)
        {
            tick = GameUtilities.Instance.tick;
            for (int i = 0; i < clientMax; i++)
            {
                if (clients[i] != null)
                {
                    clients[i].RestoreLife(lifePerTime);
                    time[i] = time[i] - 1;
                    if (time[i] == 0)
                    {
                        clients[i].GetComponent<SpriteRenderer>().enabled = true;
                        clients[i].inDungeon = false;
                        clients[i] = null;
                        clientNumb--;
                    }
                }
            }
        }
    }


    public bool Use(PnjBehavior pnj)
    {
        if (clientNumb < clientMax)
        {
            clientNumb++;
            for (int i = 0; i < clientMax; i++)
            {
                if (clients[i] == null)
                {
                    clients[i] = pnj;
                    time[i] = timeRestore;
                    GetComponent<Facility>().Use(pnj);
                    pnj.GetComponent<SpriteRenderer>().enabled = false;
                    pnj.inDungeon = true;
                    break;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    public int CompareTo(RestoreLife other)
    {
        if (GetComponent<Facility>().price > other.GetComponent<Facility>().price) return 1;
        else if (GetComponent<Facility>().price < other.GetComponent<Facility>().price) return -1;
        else return 0;
    }
}
