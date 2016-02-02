using UnityEngine;
using System.Collections;

public class LevelUp : MonoBehaviour {
    public PnjBehavior pnj1;
    public PnjBehavior pnj2;
    public Class class1;
    public Quest quest1;
    public Monster monster1;
    public Building building1;
    public int adventure;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public string Activate()
    {
        string retuningString = "";
        if (pnj1 != null)
        {
            GameUtilities.Instance.entrance.MakeEnter(pnj1);
            retuningString += "New visitors : " + pnj1.pnjName;
            pnj1.classOf.town.visitor = pnj1.classOf.town.visitor + 1;
            pnj1.classOf.membersActif++;
            if (pnj2 != null)
            {
                GameUtilities.Instance.entrance.MakeEnter(pnj2);
                retuningString += ", " + pnj2.pnjName;
                pnj2.classOf.town.visitor = pnj2.classOf.town.visitor + 1;
                pnj2.classOf.membersActif++;
            }
            retuningString += "\n";
        }
        if (class1 != null)
        {
            class1.NewLevel();
            retuningString += "New class discovered : " + class1.nameClass + "\n";
        }if (quest1 != null)
        {
            quest1.locked = false;
            retuningString += "New quest unlocked : " + quest1.nameQuest + "\n";
        }
        if (building1 != null)
        {
            building1.locked = false;
            retuningString += "New building unlocked : " + building1.nameBuilding + "\n";
        }
        if (monster1 != null)
        {
            monster1.locked = false;
            retuningString += "New monster unlocked : " + monster1.nameMonst + "\n";
        }
        if (adventure != 0)
        {
            GameUtilities.Instance.ChangeResearch(adventure);
            retuningString += "Adventure points gained : " + adventure;
        }
        return retuningString;
    }

    public Sprite GetImage()
    {
        if (pnj1 != null)
        {
            return pnj1.GetComponent<SpriteRenderer>().sprite;
        }else if (class1 != null)
        {
            return class1.members[0].GetComponent<SpriteRenderer>().sprite;
        }else if (building1 != null)
        {
            return building1.image;
        }else if (monster1 != null)
        {
            return monster1.image;
        }else if (adventure != 0)
        {
            return GameUtilities.Instance.compass;
        }
        return null;
    }
}
