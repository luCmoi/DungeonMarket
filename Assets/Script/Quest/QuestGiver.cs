using UnityEngine;
using System.Collections;

public class QuestGiver : MonoBehaviour {
    public Quest[] quest0 = new Quest[3];
    public Quest[] quest1 = new Quest[3];
    public Quest[] quest2 = new Quest[3];
    public Quest[] quest3 = new Quest[3];
    public Quest[][] quests = new Quest[4][];
    public Quest[] questSelected = new Quest[4];
    public int unlocked;
    public GameObject newQuest;
    public GameObject upActif;
    // Use this for initialization
    void Start () {
        quests[0] = quest0;
        quests[1] = quest1;
        quests[2] = quest2;
        quests[3] = quest3;
        upActif = Instantiate(newQuest, transform.position, Quaternion.identity) as GameObject;
        upActif.transform.Translate(new Vector3(0, 0.15f, -9));
    }

    // Update is called once per frame
    void Update () {
	
	}

   public void LevelUp()
    {
        unlocked++;
        if (upActif == null)
        {
            upActif = Instantiate(newQuest, transform.position, Quaternion.identity) as GameObject;
            upActif.transform.Translate(new Vector3(0,0.15f,-9));
        }
    }
    public void OnMouseDown()
    {
        UIController.Instance.OpenQuestGiver(this);
    }
    public void AddQuest(Quest quest ,int row)
    {
        questSelected[row] = quest;
        questSelected[row].questGiver = gameObject;
        GameList.Instance.AddQuest(questSelected[row]);
        if (row >= unlocked)
        {
            Destroy(upActif);
            upActif = null;
        }
    }

    public void Return(PnjBehavior pnj) {
        pnj.gains[0] = pnj.gains[0] + pnj.quest.quest.money;
        pnj.gains[1] = pnj.gains[1] + ((pnj.quest.quest.power*2)* (pnj.quest.quest.power *2));
        pnj.quest.quest.Executed();
        GetComponent<Building>().gains[0] = GetComponent<Building>().gains[0] + 1;
        GetComponent<Building>().gains[2] = GetComponent<Building>().gains[2] + (pnj.quest.quest.power* pnj.quest.quest.power);
    }
    public void Change(int row)
    {
        GameList.Instance.RemoveQuest(questSelected[row]);
        Destroy(questSelected[row]);
        if (upActif == null)
        {
            upActif = Instantiate(newQuest, transform.position, Quaternion.identity) as GameObject;
            upActif.transform.Translate(new Vector3(0, 0.15f, -9));
        }
    }
}
