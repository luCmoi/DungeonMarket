using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
    public static UIController Instance;
    public bool interactible = true;

    public GameObject buildingMenu;
    public QuestGiverController questGiverMenu;
    public DungeonController dungeonController;

    public GameObject menuActive;
    public Button[] leavingEdges = new Button[4];
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
    public void OpenDungeon(Dungeon dungeon)
    {
        ActivateMenu(2);
        dungeonController.SetDungeon(dungeon);
    }
    public void DesactivateMenu(int menu)
    {
        interactible = true;
        switch (menu)
        {
            case -1:
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
        }
        if (menuActive == null)
        {
            foreach (Button leave in leavingEdges)
            {
                leave.gameObject.SetActive(false);
            }
        }
    }
    public void ActivateMenu(int menu)
    {
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
            }
            if (menuActive != null)
            {
                foreach (Button leave in leavingEdges)
                {
                    leave.gameObject.SetActive(true);
                }
            }
        }
    }
}
