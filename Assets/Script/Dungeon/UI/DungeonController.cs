using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DungeonController : MonoBehaviour {
    public CaseController[] cases = new CaseController[10];
    public SelectMonsterCOntroller selectMonster;
    public Button[] leavingEdges = new Button[4];
    private Dungeon dungeon;
    public Text title;
    // Use this for initialization
    void Start () {
	     
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetDungeon(Dungeon dungeonNew)
    {
        dungeon = dungeonNew;
        title.text = dungeon.GetComponent<Building>().nameBuilding;
        foreach (CaseController case0 in cases)
        {
            case0.SetDungeon(dungeon);
        }
    }

    public void SelectMonster(int id)
    {
        selectMonster.gameObject.SetActive(true);
        selectMonster.SelectMonster(id, dungeon);
        foreach (Button leav in leavingEdges)
        {
            leav.gameObject.SetActive(true);
        }
    }

    public void DesactivateMenu()
    {
        selectMonster.Desactivate();
        selectMonster.gameObject.SetActive(false);
        foreach (Button leav in leavingEdges)
        {
            leav.gameObject.SetActive(false);
        }
    }

    public void Desactivate()
    {
        dungeon = null;
        foreach (CaseController case0 in cases)
        {
            case0.SetDungeon(dungeon);
        }
        gameObject.SetActive(false);
    }

    public void Selected(int id, Monster monster)
    {
        cases[id].SetMonster(monster);
        dungeon.NewMonster(id, monster);
        DesactivateMenu();
        if (id < 9) {
            cases[id + 1].ActivateButton();
        }
    }
}
