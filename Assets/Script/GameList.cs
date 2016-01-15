using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameList : MonoBehaviour {
    public static GameList Instance;
    public List<Dungeon> Dungeons = new List<Dungeon>();
    public List<Facility> Facilities = new List<Facility>();
    public List<RestoreLife> RestoreLifes = new List<RestoreLife>();
    public List<MonsterInstance> Monsters = new List<MonsterInstance>();
    public List<Quest> Quests = new List<Quest>();
    public List<PnjBehavior> Pnjs = new List<PnjBehavior>();
    public PnjBehavior[] Noobs = new PnjBehavior[5];
    public void AddDungeon(Dungeon dungeon)
    {
        Dungeons.Add(dungeon);
        Dungeons.Sort();
    }
    public void AddMonster(MonsterInstance monster)
    {
        Monsters.Add(monster);
        Monsters.Sort();
    }
    public void AddQuest(Quest quest)
    {
        Quests.Add(quest);
        Quests.Sort();
    }
    public void AddFacility(Facility facility)
    {
        Facilities.Add(facility);
        Facilities.Sort();
    }
    public void AddRestoreLife(RestoreLife restoreLife)
    {
        RestoreLifes.Add(restoreLife);
        RestoreLifes.Sort();
    }
    public void RemoveQuest(Quest quest)
    {
        Quests.Remove(quest);
    }
    public void AddPnj(PnjBehavior pnj)
    {
        Pnjs.Add(pnj);
        Pnjs.Sort();
    }
    public Quest TakeQuest(int power)
    {
        if (Quests.Count > 0) { 
            List<Quest> tmp = new List<Quest>();
            int powerMin = power;
            int powerMax = power;
            while (tmp.Count <= 0)
            {
                foreach (Quest quest in Quests)
                {
                    if (quest.power >= powerMin && quest.power <= powerMax)
                    {
                        tmp.Add(quest);
                    }
                    if (quest.power > powerMax)
                    {
                        break;
                    }
                }
                powerMin--;
                powerMax++;
            }
            return tmp[Random.Range(0, tmp.Count)];
        }
        else
        {
            return null;
        }
    }
    public Dungeon TakeDungeon(Quest quest)
    {
        if (Dungeons.Count > 0)
        {
            List<Dungeon> tmp = new List<Dungeon>();
            foreach (MonsterInstance monster in Monsters)
            {
                if (monster.monster == quest.creature)
                {
                    tmp.Add(monster.dungeon);
                }else if (monster.monster.power > quest.creature.power)
                {
                    break;
                }
            }
            if (tmp.Count > 0)
            {
                return tmp[Random.Range(0, tmp.Count)];
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
    public Facility TakeRestoreLife(int money)
    {
        if (RestoreLifes.Count > 0)
        {
            List<Facility> tmp = new List<Facility>();
            while (tmp.Count <= 0)
            {
                foreach (RestoreLife facility in RestoreLifes)
                {
                    if (facility.GetComponent<Facility>().price <= money)
                    {
                        tmp.Add(facility.GetComponent<Facility>());
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (tmp.Count > 0)
            {
                return tmp[Random.Range(0, tmp.Count)];
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
    public Facility TakeFacility(int money)
    {
        if (Facilities.Count > 0)
        {
            List<Facility> tmp = new List<Facility>();
            while (tmp.Count <= 0)
            {
                foreach (Facility facility in Facilities)
                {
                    if (facility.price <= money)
                    {
                        tmp.Add(facility);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (tmp.Count > 0)
            {
                return tmp[Random.Range(0, tmp.Count)];
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
    public PnjBehavior TakeNoob()
    {
        foreach (PnjBehavior naab in Noobs)
        {
            if (!naab.active)
            {
                naab.Activate();
                return naab;
            }
        }
        return null;
    }
    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of GameUtilities!");
        }
        else
        {
            Instance = this;
        }
    }
	
	// Update is called once per frame
	void Update () {
       
	}
}
