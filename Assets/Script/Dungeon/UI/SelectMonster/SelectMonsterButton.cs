using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectMonsterButton : MonoBehaviour {
    public Monster monster;
    public Image image;
    public Text nameSelectMonst;
    public SelectMonsterCOntroller controller;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        controller.Selected(monster);
    }

    public void SetMonster(Monster monsterNew)
    {
        monster = monsterNew;
        nameSelectMonst.text = monster.nameMonst;
        image.sprite = monster.image;
    }
}
