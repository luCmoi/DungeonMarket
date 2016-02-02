using UnityEngine;
using System.Collections;

public class Class : MonoBehaviour {
    public string nameClass;
    public int satisfaction;
    public int level;
    public int levelMax;
    public int[] satisfactionMax;
    public LevelUp[] levelUp;
    public GameObject[] members;
    public TownInfo town;
    public int questFinished;
    public int monsterKilled;
    public int membersActif;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        if (level != -1)
        {
            if (satisfaction >= satisfactionMax[level])
            {
                satisfaction = satisfaction - satisfactionMax[level];
                NewLevel();
            }
        }
    }
    public void NewLevel()
    {
        if (level != levelMax)
        {
            level++;
            if (level == 0)
            {
                GameUtilities.Instance.band.Activate(levelUp[level].GetImage(), nameClass + " - Discovery", levelUp[level].Activate());
            }
            else {
                GameUtilities.Instance.band.Activate(levelUp[level].GetImage(), nameClass + " - Satisfaction Up : "+level, levelUp[level].Activate());
            }
        }
    }
}
