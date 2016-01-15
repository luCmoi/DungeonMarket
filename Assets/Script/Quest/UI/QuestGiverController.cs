using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestGiverController : MonoBehaviour {
    public static QuestGiverController Instance;
    public GameObject[] choices = new GameObject[3];
    public Text[] buttonText;
    public float buttonTextSize = 0.02f;
    public ButtonQuest[] buttons = new ButtonQuest[4];
    private QuestGiver questGiver;
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
        foreach (Text button in buttonText) {
            button.fontSize = CalculFont(buttonTextSize);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetQuestGiver(QuestGiver questGiverNew)
    {
        questGiver = questGiverNew;
        foreach (GameObject choice in choices)
        {
            choice.SetActive(false);
        }
        foreach (ButtonQuest button in buttons)
        {
            button.SetQuestList(questGiverNew.quests[button.id], questGiverNew.questSelected[button.id]);
        }
    }

    int CalculFont(float fontSize)
    {
        return (int)(Screen.width * fontSize);
    }

    public void SelectQuest(int row,int num)
    {
        questGiver.AddQuest(questGiver.quests[row][num], row);
        UIController.Instance.DesactivateMenu(1);
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }
}
