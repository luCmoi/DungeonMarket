using UnityEngine;
using System.Collections;
using System;

public class Dungeon : MonoBehaviour, IComparable<Dungeon> {
    public MonsterInstance[] monsters = new MonsterInstance[numberMax];
    public Biome biome;
    public Sprite[] background = new Sprite[numberMax];
    public static int numberMax = 10;
    public bool[] activated = new bool[numberMax];
    public PnjDungeon[]  visitor = new PnjDungeon[numberMax];
    public int tick;
    public int power;
    // Use this for initialization
    void Start () {
        GameList.Instance.Dungeons.Add(this);
        activated[0] = true;
        activated[1] = true;
        for (int i = 0; i  < numberMax; i++)
        {
            if (i == 0 || i == numberMax/2)
            {
                background[i] = biome.backgroundStart;
            }
            else if (i == numberMax - 1 || i == numberMax/2-1)
            {
                background[i] = biome.backgroundEnd;
            }
            else
            {
                background[i] = biome.background[UnityEngine.Random.Range(0, biome.background.Length)];
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        if (GameUtilities.Instance.tick != tick)
        {
            tick = GameUtilities.Instance.tick;
            bool next = true;
            for (int i =0; i < numberMax; i++)
            {
                if (visitor[i] != null)
                {
                    if (next)
                    {
                        if (visitor[i].quart == 0)
                        {
                            visitor[i].quart = 1;
                        }
                        else if (visitor[i].quart == 1)
                        {
                            if (monsters[i].life <= 0)
                            {
                                visitor[i].quart = 2;
                            }
                            //Fight
                            else
                            {
                                Fight(i);
                            }
                        }
                        else if (visitor[i].quart == 2)
                        {
                            visitor[i].quart = 3;
                        }
                        else if (visitor[i].quart == 3)
                        {
                            //Wait for next Case
                            if (visitor[i + 1] != null)
                            {
                            }
                            //Move Case
                            else if (activated[i + 1])
                            {
                                visitor[i].casePos = i + 1;
                                visitor[i].quart = 0;
                                visitor[i + 1] = visitor[i];
                                next = false;
                                visitor[i] = null;
                            }
                            //Exit
                            else
                            {
                                Exiting(visitor[i].behavior);
                                visitor[i] = null;
                            }
                        }
                    }
                    else
                    {
                        next = true;
                    }
                }
                if (monsters[i] != null && monsters[i].timeBeforeRespawn != 0)
                {
                    monsters[i].TimeFlow();
                }
            }
        }
    }

    public void OnMouseDown()
    {
        UIController.Instance.OpenDungeon(this);
    }

    public bool Entering(PnjBehavior pnj)
    {
        if (visitor[0] == null) {
            pnj.GetComponent<SpriteRenderer>().enabled = false;
            visitor[0] = pnj.GetComponent<PnjDungeon>();
            visitor[0].Restart();
            return true;
        }else
        {
            return false;
        }
    }
    public void Exiting(PnjBehavior pnj)
    {
        pnj.GetComponent<SpriteRenderer>().enabled = true;
        pnj.inDungeon = false;
        pnj.GetComponent<PnjDungeon>().Restart();
    }

    public int CompareTo(Dungeon other)
    {
        if (power > other.power) return 1;
        else if (power < other.power) return -1;
        else return 0;
    }
    private void Fight(int i)
    {
        monsters[i].Damage(visitor[i].behavior.damage);
        visitor[i].behavior.Damage(monsters[i].monster.damage);
        if (monsters[i].life <= 0 && visitor[i].behavior.quest.quest.type == 0 && visitor[i].behavior.quest.quest.creature == monsters[i].monster)
        {
            
            visitor[i].behavior.quest.accomplishedNumb = visitor[i].behavior.quest.accomplishedNumb + 1;
        }
    }
}
