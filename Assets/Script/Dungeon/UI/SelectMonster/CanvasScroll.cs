using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasScroll : MonoBehaviour {
    public int monsterNumb = 0;
    public int lines;
    public ArrayList array = new ArrayList();
    public GameObject place;
    public GameObject viewport;
    public SelectMonsterCOntroller selectMonster;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddChoice(Monster monster)
    {
        array.Add(Instantiate(place));
        ((GameObject)array[monsterNumb]).GetComponent<RectTransform>().parent = this.GetComponent<RectTransform>();
        ((GameObject)array[monsterNumb]).GetComponent<RectTransform>().anchorMin = new Vector2(0.5f * (monsterNumb%2), 1 - ((1+monsterNumb/2) * (1.0f/lines)));
        ((GameObject)array[monsterNumb]).GetComponent<RectTransform>().anchorMax = new Vector2(0.5f * (1 + (monsterNumb % 2)), 1 - (monsterNumb/2 * (1.0f/ lines)));
        ((GameObject)array[monsterNumb]).GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        ((GameObject)array[monsterNumb]).GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        ((GameObject)array[monsterNumb]).GetComponent<SelectMonsterButton>().controller = selectMonster;
        ((GameObject)array[monsterNumb]).GetComponent<SelectMonsterButton>().SetMonster(monster);
        monsterNumb++;
    }

    public void ChangeSize(int size)
    {
        if (size - 4 <= 0)
        {
            GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        }
        else{
            GetComponent<RectTransform>().anchorMin = new Vector2(0, -0.5f * ((size - 4) / 2));
        }
        lines = size / 2;
    }

    public void Desactivate()
    {
        monsterNumb = 0;
        foreach (GameObject place in array)
        {
            Destroy(place);
        }
        array = new ArrayList();
    }
}
