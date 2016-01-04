using UnityEngine;
using System.Collections;

public class GameUtilities : MonoBehaviour {
    public static GameUtilities Instance;
    public bool interactible = true;
    public bool roadCreating;
    public bool constructing;
    public GameObject building;
    public GameObject buildingMenu;
    // Use this for initialization
    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of GameUtilities!");
        }
        else {
            Instance = this;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ActiveConstructing()
    {
        constructing = true;
        roadCreating = false;
    }

    public void ActiveRoadCreating()
    {
        roadCreating = true;
        constructing = false;
    }

    public void ActivateMenu()
    {
        if (constructing)
        {
            constructing = false;
            building = null;
        }
        interactible = false;
        buildingMenu.SetActive(true);
    }
    public void DesactivateMenu()
    {
        interactible = true;
        buildingMenu.SetActive(false);
    }
}
