using UnityEngine;
using System.Collections;

public class QuestGiver : MonoBehaviour {
    public Quest[] quest0 = new Quest[3];
    public Quest[] quest1 = new Quest[3];
    public Quest[] quest2 = new Quest[3];
    public Quest[] quest3 = new Quest[3];
    public Quest[][] quests = new Quest[4][];
    public Quest[] questSelected = new Quest[4];
    // Use this for initialization
    void Start () {
        quests[0] = quest0;
        quests[1] = quest1;
        quests[2] = quest2;
        quests[3] = quest3;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void OnMouseDown()
    {
        UIController.Instance.OpenQuestGiver(this);
    }
    public void AddQuest(Quest quest ,int row)
    {
        questSelected[row] = Instantiate(quest);
        questSelected[row].questGiver = gameObject;
        GameList.Instance.AddQuest(questSelected[row]);
    }

    public void Return() { }
}
