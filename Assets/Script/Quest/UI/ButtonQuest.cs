using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class ButtonQuest : MonoBehaviour {
    public GameObject[] choices = new GameObject[3];
    public Text[] nameButton = new Text[3];
    public float nameSize = 0.02f;
    public Text[] text = new Text[3];
    public float textSize = 0.02f;
    public Image[] image = new Image[3];
    public int id;
    public Text[] buttons = new Text[3];
    public Quest[] list;
    public Quest selected;

    // Use this for initialization
    void Start () {
        foreach (Text nam in nameButton)
        {
            nam.fontSize = CalculFont(nameSize);
        }
        foreach (Text tex in text)
        {
            tex.fontSize = CalculFont(textSize);
        }
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
            nameButton[1].text = selected.nameQuest;
            text[1].text = selected.text;
            image[1].sprite = selected.image;
            buttons[1].text = "Selected";
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                if (list[i] != null)
                {
                    choices[i].SetActive(true);
                    nameButton[i].text = list[i].nameQuest;
                    text[i].text = list[i].text;
                    image[i].sprite = list[i].image;
                    buttons[i].text = "Select";
                    buttons[i].transform.parent.GetComponent<ButtonSelect>().questRow = id;
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
    }
}
