using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PnjClickMenuController : MonoBehaviour {
    public PersonnageController personnageController;
    public QuestController questController;
    public ClassController classController;
    public PnjBehavior pnj;
    public Text title;
    public ProgressBar bar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetPnj(PnjBehavior pnj)
    {
        personnageController.SetPnj(pnj);
        questController.SetQuest(pnj.quest);
        classController.SetClass(pnj.classOf);
        bar.SetPnj(pnj);
        title.text = pnj.pnjName + " - Level " + pnj.level;
    }

    public void Desactivate()
    {

    }
}
