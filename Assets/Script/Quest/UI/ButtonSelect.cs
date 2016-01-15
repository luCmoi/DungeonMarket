using UnityEngine;
using System.Collections;

public class ButtonSelect : MonoBehaviour {
    public int questRow;
    public int questNum;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        QuestGiverController.Instance.SelectQuest(questRow, questNum);
    }
}
