using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DungeonController : MonoBehaviour {
    public CaseController[] cases = new CaseController[10];
    public SelectMonsterCOntroller selectMonster;
    public Button[] leavingEdges = new Button[4];
    private Dungeon dungeon;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetDungeon(Dungeon dungeonNew)
    {
        dungeon = dungeonNew;
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
        dungeon.monsters[id] = new MonsterInstance(monster, dungeon);
        dungeon.power = dungeon.power + monster.power;
        GameList.Instance.Dungeons.Sort();
        DesactivateMenu();
    }
}
