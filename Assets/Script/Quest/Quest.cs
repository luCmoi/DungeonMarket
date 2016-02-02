using UnityEngine;
using System.Collections;
using System;

public class Quest : MonoBehaviour, IComparable<Quest> {
    public string nameQuest;
    public string text;
    public Sprite image;
    public int type;
    public int number;
    public int power;
    public Monster creature;
    public int money;

    public bool mastered;
    public int executeMaster;
    public int executed;
    public LevelUp master;

    public bool locked = true;

    public GameObject questGiver;

    //Type 0 = kill number of creature;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Executed()
    {
            executed++;
            if (!mastered && executed >= executeMaster)
            {
                mastered = true;
                master.Activate();
                GameUtilities.Instance.band.Activate(image, nameQuest + " - Mastered", master.Activate());
            }
    }

    public int CompareTo(Quest other)
    {
        if (power > other.power) return 1;
        else if (power< other.power) return -1;
        else return 0;
    }
}
