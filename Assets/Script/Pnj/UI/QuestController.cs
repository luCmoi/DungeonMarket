using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestController : MonoBehaviour {
    public Image image;
    public Text title;
    public Text body;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetQuest(QuestLaunched quest)
    {
        if (quest != null)
        {
            image.gameObject.SetActive(true);
            image.sprite = quest.quest.image;
            title.text = quest.quest.nameQuest;
            if (quest.quest.type == 0)
            {
                body.text = "Kill " + quest.quest.number + " " + quest.quest.creature.nameMonst + "\nStatut : " + quest.accomplishedNumb + "/" + quest.quest.number;
            }
        }
        else
        {
            image.gameObject.SetActive(false);
            title.text = "No Active Quest";
            body.text = null;
        }
    }
}
