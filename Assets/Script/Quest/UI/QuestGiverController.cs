using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestGiverController : MonoBehaviour {
    public static QuestGiverController Instance;
    public GameObject[] choices = new GameObject[3];
    public Text[] buttonText;
    public float buttonTextSize = 0.02f;
    public ButtonQuest[] buttons = new ButtonQuest[4];
    public Text nameQuestGiver;
    private QuestGiver questGiver;
    public ProgressBar bar;
	// Use this for initialization
	void Start () {
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

    public void SetQuestGiver(QuestGiver questGiverNew)
    {
        questGiver = questGiverNew;
        nameQuestGiver.text = questGiver.GetComponent<Building>().nameBuilding + " - Level " + questGiver.GetComponent<Building>().level;
        foreach (GameObject choice in choices)
        {
            choice.SetActive(false);
        }
        foreach (ButtonQuest button in buttons)
        {
            if (button.id <= questGiver.unlocked)
            {
                button.SetQuestList(questGiverNew.quests[button.id], questGiverNew.questSelected[button.id]);
            }else
            {
                button.SetQuestList(null, null);
            }
        }
        bar.SetQuestGiver(questGiver.GetComponent<Building>());
    }

    public void SelectQuest(int row,int num)
    {
        if (questGiver.questSelected[row] != null)
        {
            if (questGiver.questSelected[row].mastered)
            {
                questGiver.Change(row);
                SetQuestGiver(questGiver);
            }
        }
        else
        {
            questGiver.AddQuest(questGiver.quests[row][num], row);
            UIController.Instance.DesactivateMenu(1);
        }
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }
}
