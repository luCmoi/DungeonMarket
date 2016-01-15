using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
    
public class PnjBehavior : MonoBehaviour, IComparable<PnjBehavior> {

    public TilesBehavior container;
    public QuestLaunched quest;

    public int money;
    public int startingMoney;
    public int tick;
    public int lifeMax;
    public int life;
    public int damage;
    public int power;
    public int adventure;
    public int adventureMax;
    public int shop;
    public int shopMax;

    public Quest objectif0;
    public Dungeon objectif1;
    public Facility objectif2;
    public Entrance objectif3;
    public int adv;
    public int sho;
    public List<TilesBehavior> way = new List<TilesBehavior>();

    public TilesBehavior initTile;

    public bool inDungeon;
    public bool active;
    public int outMax;
    public int outTime;
    // Use this for initialization
    void Start () {
        money = startingMoney;
        life = lifeMax;
        adventure = adventureMax;
        shop = shopMax;
    }
    public int CompareTo(PnjBehavior other)
    {
        if (power > other.power) return 1;
        else if (power < other.power) return -1;
        else return 0;
    }
    public void Damage(int dam)
    {
        life = life -dam;
        adventure = adventure - dam;
    }
    public void Activate()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        active = true;
    }
    void outBehavior()
    {
        outTime = outTime - 1;
        if (outTime == 0)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            money = startingMoney;
            life = lifeMax;
            adventure = adventureMax;
            shop = shopMax;
        }
    }
    void wayBehavior()
    {
        if (way[0] == container)
        {
            //ATTAIN OBJECTIF
            if (way.Count == 1)
            {
                if (objectif0 != null)
                {
                    if (quest == null)
                    {
                        //ATTAIN OBJECTIF QUEST
                        quest = new QuestLaunched(objectif0);
                        way.Clear();
                        objectif0 = null;
                    }
                    else
                    {
                        //RETURNING QUEST
                        money = money + quest.quest.money;
                        quest.quest.questGiver.GetComponent<QuestGiver>().Return();
                        quest = null;
                        objectif0 = null;
                        way.Clear();
                    }

                }
                else if (objectif1 != null)
                {
                    //ATTAIN OBJECTIF DUNGEON
                    //ENTERING DUNGEON
                    if (objectif1.Entering(this))
                    {
                        objectif1 = null;
                        inDungeon = true;
                        way.Clear();
                    }
                }
                else if (objectif2 != null)
                {
                    //ATTAIN OBJECTIF FACILITY

                    if (objectif2.GetComponent<RestoreLife>() != null)
                    {
                        //IS RESTORE LIFE
                        if (objectif2.GetComponent<RestoreLife>().Use(this))
                        {
                            objectif2 = null;
                            way.Clear();
                        }
                    }
                }
                else if (objectif3 != null)
                {
                    //ATTAIN EXIT
                    objectif3 = null;
                    way.Clear();
                    outTime = outMax;
                    quest = null;
                    GetComponent<SpriteRenderer>().enabled = false;
                }
            }else
            {
                way.Remove(container);
            }
        }
        if (way.Count > 0)
        {
            //MOVING
            container = way[0];
            gameObject.transform.position = container.gameObject.transform.position;
            gameObject.transform.parent = container.gameObject.transform;
        }
    }
    void adventureChoiceBehavior()
    {
        //NEED HEALING
        if (life <= lifeMax / 5.0f)
        {
            objectif2 = GameList.Instance.TakeRestoreLife(money);
            if (objectif2 != null)
            {
                CalculateWay(gameObject.transform.parent.GetComponent<TilesBehavior>(), objectif2.GetComponent<Building>().entrance.GetComponent<TilesBehavior>());
            }
            else
            {
                //EXIT
                objectif3 = GameUtilities.Instance.entrance;
                CalculateWay(gameObject.transform.parent.GetComponent<TilesBehavior>(), objectif3.GetComponent<TilesBehavior>());
            }
        }
        else if (quest == null)
        {
            if (objectif0 == null)
            {
                //TAKE A QUEST AS OBJECTIF
                objectif0 = GameList.Instance.TakeQuest(power);
                if (objectif0 != null)
                {
                    CalculateWay(gameObject.transform.parent.GetComponent<TilesBehavior>(), objectif0.questGiver.GetComponent<Building>().entrance.GetComponent<TilesBehavior>());
                }
            }
        }
        else
        {
            //CONTINUE QUEST
            objectif1 = GameList.Instance.TakeDungeon(quest.quest);
            if (objectif1 != null)
            {
                CalculateWay(gameObject.transform.parent.GetComponent<TilesBehavior>(), objectif1.GetComponent<Building>().entrance.GetComponent<TilesBehavior>());
            }
        }
    }
    void FixedUpdate()
    {
        if (active)
        {
            if (initTile != null && transform.parent.GetComponent<TilesBehavior>() != null)
            {
                if (GameUtilities.Instance.tick != tick)
                {
                    tick = GameUtilities.Instance.tick;
                    if (!inDungeon)
                    {
                        //IS OUT
                        if (outTime != 0)
                        {
                            outBehavior();
                        }
                        else if (way != null)
                        {
                            //HAVE WAY
                            if (way.Count > 0)
                            {
                                wayBehavior();
                            }
                            //GET WAY
                            else
                            {
                                if (quest != null && quest.accomplishedNumb >= quest.quest.number)
                                {
                                    //RETURN QUEST
                                    objectif0 = quest.quest;
                                    CalculateWay(gameObject.transform.parent.GetComponent<TilesBehavior>(), objectif0.questGiver.GetComponent<Building>().entrance.GetComponent<TilesBehavior>());
                                }
                                else if (adventure <= 0 && shop <= 0)
                                {
                                    //EXIT
                                    objectif3 = GameUtilities.Instance.entrance;
                                    CalculateWay(gameObject.transform.parent.GetComponent<TilesBehavior>(), objectif3.GetComponent<TilesBehavior>());
                                }
                                else
                                {
                                     adv = UnityEngine.Random.Range(0, 10) * adventure;
                                     sho = UnityEngine.Random.Range(0, 10) * shop;
                                    if (adv >= sho)
                                    {
                                        adventureChoiceBehavior();
                                    }
                                    else
                                    {
                                        objectif2 = GameList.Instance.TakeFacility(money);
                                        if (objectif2 != null)
                                        {
                                            CalculateWay(gameObject.transform.parent.GetComponent<TilesBehavior>(), objectif2.GetComponent<Building>().entrance.GetComponent<TilesBehavior>());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void RestoreLife(int i)
    {
        life = life + i;
        if (life >= lifeMax)
        {
            life = lifeMax;
        }
    }



    public class Node
    {
        public TilesBehavior tile;
        public int g_score;
        public int f_score;
        public bool usable;
        public bool visited;
        public Node[] voisins = new Node[4];
        public Node cameFrom;
        public Node(TilesBehavior tileNew, Node[][] graph)
        {
            tile = tileNew;
            graph[tile.posX][tile.posY] = this;
            usable = tileNew.GetComponent<RoadBehavior>().activated;
            if (tile.top != null)
            {
                voisins[1] = new Node(tile.top.GetComponent<TilesBehavior>(),graph);
            }
            if (tile.gameEntrance)
            {
                if (tile.right != null)
                {
                    new Node(tile.right.GetComponent<TilesBehavior>(),graph);
                }
            }
            if (tile.left != null)
            {
                voisins[0] = graph[tile.left.GetComponent<TilesBehavior>().posX][tile.left.GetComponent<TilesBehavior>().posY];
                voisins[0].voisins[2] = this;
            }
            if (tile.down != null)
            {
                voisins[3] = graph[tile.down.GetComponent<TilesBehavior>().posX][tile.down.GetComponent<TilesBehavior>().posY];
            }
        }
        public List<TilesBehavior> Reconstruct()
        {
            List<TilesBehavior> ret = new List<TilesBehavior>();
            ret.Add(tile);
            Node reconstruct = this.cameFrom;
            while(reconstruct != null)
            {
                ret.Insert(0, reconstruct.tile);
                reconstruct = reconstruct.cameFrom;
            }
            return ret;
        }
    }
    void CalculateWay(TilesBehavior beggin, TilesBehavior destination)
    {
        Node[][] graph = new Node[8][];
        for (int i=0;i<graph.Length;i++)
        {
            graph[i] = new Node[8];
        }
        new Node(initTile,graph);
        Node end = graph[destination.posX][destination.posY];
        Node start = graph[beggin.posX][beggin.posY];
        List<Node> closedSet = new List<Node>();
        List<Node> openSet = new List<Node>();
        openSet.Add(start);
        openSet[0].g_score = 0;
        openSet[0].f_score = 0/*HeuristicEstimation(start, destination)*/;
        Node current = null;
        while (openSet.Count != 0)
        {
            /*have to list openSet by f_score*/
            current = openSet[0];
            if (current == end)
            {
                way = end.Reconstruct();
                return;
            }
            openSet.Remove(current);
            closedSet.Add(current);
            foreach (Node voisin in current.voisins)
            {
                if (voisin != null && voisin.usable)
                {
                    if (closedSet.Contains(voisin))
                    {
                        continue;
                    }
                    int new_g_score = current.g_score + 1;
                    if (!openSet.Contains(voisin))
                    {
                        openSet.Add(voisin);
                    }
                    else if (new_g_score >= voisin.g_score)
                    {
                        continue;
                    }
                    voisin.cameFrom = current;
                    voisin.g_score = new_g_score;
                    voisin.f_score = 0;//Heuristic truc chouette(voisin, end)
                }
            }
        }
        way =  null;
    }
    public int HeuristicEstimation(TilesBehavior start, TilesBehavior end)
    {
        return 0;
    }


}
