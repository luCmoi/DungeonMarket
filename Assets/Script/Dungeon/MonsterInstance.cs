using UnityEngine;
using System.Collections;
using System;

public class MonsterInstance : IComparable<MonsterInstance>
{
    public Monster monster;
    public int life;
    public int timeBeforeRespawn;
    public Dungeon dungeon;

    public MonsterInstance(Monster monsterNew,Dungeon dungeonNew)
    {
        monster = monsterNew;
        life = monster.life;
        GameList.Instance.AddMonster(this);
        dungeon = dungeonNew;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TimeFlow()
    {
        timeBeforeRespawn--;
        if (timeBeforeRespawn <= 0)
        {
            life = monster.life;
        }
    }
    public int CompareTo(MonsterInstance other)
    {
        if (monster.power > other.monster.power) return 1;
        else if (monster.power < other.monster.power) return -1;
        else return 0;
    }

    public void Damage(int d)
    {
        life = life - d;
        if (life <= 0)
        {
            timeBeforeRespawn = monster.respawnTime;
        }
    }
}
