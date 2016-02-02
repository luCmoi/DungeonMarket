using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour {
    public static UIController Instance;
    public bool interactible = true;

    public GameObject buildingMenu;
    public QuestGiverController questGiverMenu;
    public DungeonController dungeonController;
    public PnjClickMenuController pnjClickController;
    public TownsController townsController;
    public UnlockBigTileController unlockController;
    public FightController fightController;
    public bool inFight;

    public GameObject menuActive;
    public Button[] leavingEdges0 = new Button[4];
    public Button[] leavingEdges1 = new Button[4];
    public Button[] leavingEdges2 = new Button[4];
    // Use this for initialization
    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of GameUtilities!");
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
    public void OpenQuestGiver(QuestGiver questGiver)
    {
        ActivateMenu(1);
        questGiverMenu.SetQuestGiver(questGiver);
    }
    public void OpenUnlock(BigTileBehavior bigTile)
    {
        ActivateMenu(5);
        unlockController.SetUnlock(bigTile);
    }
    public void OpenPnjMenu(PnjBehavior pnj)
    {
        ActivateMenu(3);
        pnjClickController.SetPnj(pnj);
    }
    public void OpenDungeon(Dungeon dungeon)
    {
        ActivateMenu(2);
        dungeonController.SetDungeon(dungeon);
    }
    public void OpenTownMenu()
    {
        ActivateMenu(4);
        townsController.Reload();
    }
    public void DesactivateMenu(int menu)
    {
        if (!GameUtilities.Instance.ButtonInTick && !inFight)
        {
            GameUtilities.Instance.ButtonInTick = true;
            interactible = true;
            switch (menu)
            {
                case -1:
                case -2:
                case -3:
                    menuActive.SetActive(false);
                    menuActive = null;
                    break;
                case 0:
                    buildingMenu.SetActive(false);
                    menuActive = null;
                    break;
                case 1:
                    questGiverMenu.Desactivate();
                    menuActive = null;
                    break;
                case 2:
                    dungeonController.Desactivate();
                    menuActive = null;
                    break;
                case 3:
                    pnjClickController.Desactivate();
                    menuActive = null;
                    break;
                case 4:
                    townsController.Desactivate();
                    menuActive = null;
                    break;
                case 5:
                    unlockController.gameObject.SetActive(false);
                    menuActive = null;
                    break;
            }
            if (menuActive == null)
            {
                if (menu == 0 || menu == 1 || menu == 2 || menu == -1 || menu == 4)
                {
                    foreach (Button leave in leavingEdges0)
                    {
                        leave.gameObject.SetActive(false);
                    }
                }
                else if (menu == 3 || menu == -2)
                {
                    foreach (Button leave in leavingEdges1)
                    {
                        leave.gameObject.SetActive(false);
                    }
                }else if (menu == 5 || menu == -3)
                {
                    foreach (Button leave in leavingEdges2)
                    {
                        leave.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    public void ActivateMenu(int menu)
    {
        if (!GameUtilities.Instance.ButtonInTick && !inFight)
        {
            GameUtilities.Instance.ButtonInTick = true;
            if (menuActive == null)
            {
                interactible = false;
                switch (menu)
                {
                    case 0:
                        buildingMenu.SetActive(true);
                        menuActive = buildingMenu;
                        break;
                    case 1:
                        questGiverMenu.gameObject.SetActive(true);
                        menuActive = questGiverMenu.gameObject;
                        break;
                    case 2:
                        dungeonController.gameObject.SetActive(true);
                        menuActive = dungeonController.gameObject;
                        break;
                    case 3:
                        pnjClickController.gameObject.SetActive(true);
                        menuActive = pnjClickController.gameObject;
                        break;
                    case 4:
                        townsController.gameObject.SetActive(true);
                        menuActive = townsController.gameObject;
                        break;
                    case 5:
                        unlockController.gameObject.SetActive(true);
                        menuActive = unlockController.gameObject;
                        break;
                }
                if (menuActive != null)
                {
                    if (menu == 0 || menu == 1 || menu == 2 || menu ==4)
                    {
                        foreach (Button leave in leavingEdges0)
                        {
                            leave.gameObject.SetActive(true);
                        }
                    }
                    else if (menu == 3)
                    {
                        foreach (Button leave in leavingEdges1)
                        {
                            leave.gameObject.SetActive(true);
                        }
                    }else if (menu == 5)
                    {
                        foreach (Button leave in leavingEdges2)
                        {
                            leave.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }
    public void ActivateFight(UnlockBigTileController unlockTile)
    {
        List<Monster> monster = new List<Monster>();
        foreach (MonsterInstance mons in GameList.Instance.Monsters.ToArray())
        {
            monster.Add(mons.monster);
        }
        fightController.LaunchFight(unlockTile.bigTile.monsters, monster.ToArray());
        fightController.gameObject.SetActive(true);
    }
    public void FightEnded(bool victory)
    {
        fightController.gameObject.SetActive(false);
        unlockController.End(victory);
    }
}
