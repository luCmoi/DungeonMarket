using UnityEngine;
using System.Collections.Generic;

public class Building : MonoBehaviour {
    public int width;
    public int height;
    public int entranceX;
    public int entranceY;
    public int price;
    public GameObject alerteSignal;
    public GameObject entrance;
    public bool activated;
    //XP, Adventure, Money
    public int[] gains = new int[3];
    public int xp;
    public int[] xpMax;
    public int level;
    public GameObject buildingPopUp;
    public string nameBuilding;
    public List<GameObject> info = new List<GameObject>();
    public Sprite image;

    public bool locked = true;
    public bool enhancement;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void newLevel()
    {
        if (!enhancement)
        {
            if (GetComponent<QuestGiver>() != null)
            {
                GetComponent<QuestGiver>().LevelUp();
            }
            xp = xp - xpMax[level];
            level++;
        }
    }
    void FixedUpdate()
    {
        if (!enhancement)
        {
            GameObject instance;
            //XP
            if (gains[0] != 0)
            {
                xp = xp + gains[0];
                if (xp >= xpMax[level])
                {
                    newLevel();
                }
                gains[0] = 0;
            }
            //Money
            if (gains[1] != 0)
            {
                GameUtilities.Instance.ChangeMoney(gains[1]);
                instance = Instantiate(buildingPopUp, new Vector3(gameObject.transform.position.x + (0.15f * (width / 3)), gameObject.transform.position.y + (0.15f * (height / 1.5f)), -7), Quaternion.identity) as GameObject;
                instance.GetComponent<PnjPopupInfo>().setText(0, gains[1].ToString(), info);
                info.Add(instance);
                gains[1] = 0;
            }
            //Adventure
            if (gains[2] != 0)
            {
                GameUtilities.Instance.ChangeResearch(gains[2]);
                instance = Instantiate(buildingPopUp, new Vector3(gameObject.transform.position.x + (0.15f * (width / 3)), gameObject.transform.position.y + (0.15f * (height / 1.5f)), -7), Quaternion.identity) as GameObject;
                instance.GetComponent<PnjPopupInfo>().setText(1, gains[2].ToString(), info);
                info.Add(instance);
                gains[2] = 0;
            }
        }
    }



    public void setEntrance(GameObject newEntrance)
    {
        if (!enhancement)
        {
            if (newEntrance != null)
            {
                activated = true;
                entrance = newEntrance;
                alerteSignal.SetActive(false);
            }
            else
            {
                activated = false;
                entrance = null;
                alerteSignal.SetActive(true);
            }
        }
    }

    public void OnMouseDown()
    {
        if (!enhancement)
        {
            if (GetComponent<QuestGiver>() != null)
            {
                GetComponent<QuestGiver>().OnMouseDown();
            }
            if (GetComponent<Dungeon>() != null)
            {
                GetComponent<Dungeon>().OnMouseDown();
            }
        }
    }
}
