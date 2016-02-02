using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectMonsterButton : MonoBehaviour {
    public Monster monster;
    public Image image;
    public Text nameSelectMonst;
    public SelectMonsterCOntroller controller;
    public Text description;
    public Text stat0;
    public Text stat1;
    public Text price;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        if (GameUtilities.Instance.research >= monster.price)
        {
            controller.Selected(monster);
        }
    }

    public void SetMonster(Monster monsterNew)
    {
        monster = monsterNew;
        nameSelectMonst.text = monster.nameMonst;
        image.sprite = monster.image;
        description.text = monster.description;
        stat0.text = "Life : " + monster.life + "\nDamage : " + monster.damage;
        stat1.text = "Difficulty : " + monster.power + "\nDefeated : " + monster.killed;
        price.text = monster.price.ToString();
        if (monster.locked)
        {
            GetComponentInChildren<UnityEngine.UI.Button>().interactable = false;
            GetComponentInChildren<UnityEngine.UI.Button>().GetComponent<Image>().color = Color.grey;
        }
        else
        {
            GetComponentInChildren<UnityEngine.UI.Button>().interactable = true;
            GetComponentInChildren<UnityEngine.UI.Button>().GetComponent<Image>().color = Color.white;
        }
    }
}
