using UnityEngine;
using System.Collections;

public class SelectMonsterCOntroller : MonoBehaviour {
    int id;
    public DungeonController controller;
    public CanvasScroll canvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SelectMonster(int idNew, Dungeon dungeonNew)
    {
        id = idNew;
        canvas.ChangeSize(dungeonNew.biome.monsterAvailable.Length);
        foreach (Monster monster in dungeonNew.biome.monsterAvailable)
        {
            canvas.AddChoice(monster);
        }
    }

    public void Selected(Monster monster)
    {
        controller.Selected(id, monster);
       Desactivate();
    }
    public void Desactivate()
    {
        canvas.Desactivate();
    }

}
