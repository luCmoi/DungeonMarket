using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class ButtonQuest : MonoBehaviour {
    public GameObject[] choices = new GameObject[3];
    public float nameSize = 0.02f;
    public Text[] text = new Text[3];
    public float textSize = 0.02f;
    public Image[] image = new Image[3];
    public int id;
    public Text[] buttons = new Text[3];
    public Text[] titleQuest = new Text[3];
    public Quest[] list;
    public Text[] info = new Text[6];
    public Quest selected;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void OnClick()
    {
        if (selected != null)
        {
            choices[0].SetActive(false);
            choices[2].SetActive(false);
            choices[1].SetActive(true);
            text[1].text = selected.text;
            image[1].sprite = selected.image;
            titleQuest[1].text = selected.nameQuest;
            info[2].text = "Objectif : " + selected.number + "\nMoney : " + selected.money;
            info[3].text = "Difficulty : " + selected.power + "\nExecuted : "+selected.executed;
            if (selected.mastered)
            {
                titleQuest[1].text += " - Mastered";
            }
            if (!selected.mastered)
            {
                buttons[1].text = "Selected";
            }
            else
            {
                buttons[1].text = "Change";
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                if (list[i] != null)
                {
                    choices[i].SetActive(true);
                    text[i].text = list[i].text;
                    image[i].sprite = list[i].image;
                    buttons[i].text = "Select";
                    buttons[i].transform.parent.GetComponent<ButtonSelect>().questRow = id;
                    titleQuest[i].text = list[i].nameQuest;
                    info[i * 2].text = "Objectif : " + list[i].number + "\nMoney : " + list[i].money;
                    info[i * 2+1].text = "Difficulty : " + list[i].power+ "\nExecuted : " + list[i].executed;
                    if (list[i].mastered)
                    {
                        titleQuest[1].text += " - Mastered";
                    }
                    if (list[i].locked)
                    {
                        buttons[i].gameObject.transform.parent.GetComponent<UnityEngine.UI.Button>().interactable = false;
                        buttons[i].gameObject.transform.parent.GetComponent<Image>().color = Color.grey;
                    }
                    else
                    {
                        buttons[i].gameObject.transform.parent.GetComponent<UnityEngine.UI.Button>().interactable = true;
                        buttons[i].gameObject.transform.parent.GetComponent<Image>().color = Color.white;
                    }
                }
                else
                {
                    choices[i].SetActive(false);
                }
            }

        }
    }
    int CalculFont(float fontSize)
    {
        return (int)(Screen.width * fontSize);
    }

    public void SetQuestList(Quest[] newList, Quest newSelected)
    {
        list = newList;
        selected = newSelected;
        if (list != null)
        {
            GetComponent<UnityEngine.UI.Button>().interactable = true;
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            GetComponent<UnityEngine.UI.Button>().interactable = false;
            GetComponent<Image>().color = Color.grey;
        }
    }
}
