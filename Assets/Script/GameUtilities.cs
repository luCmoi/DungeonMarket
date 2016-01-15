using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUtilities : MonoBehaviour {
    public static GameUtilities Instance;
    public bool roadCreating;
    public bool constructing;
    public GameObject building;
    public float tickTime = 1f;
    public float tickTimeLeft;
    public int tick = 0;
    public int money;
    public Text textMoney;
    public Entrance entrance;
    // Use this for initialization
    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of GameUtilities!");
        }
        else {
            Instance = this;
            tickTimeLeft = tickTime;
        }
    }
    public void ChangeMoney(int add)
    {
        money = money + add;
        textMoney.text = money.ToString();
    }
	// Update is called once per frame
	void Update () {
        if (tickTimeLeft > 0)
        {
            tickTimeLeft -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        if (tickTimeLeft <= 0)
        {
            tick++;
            tickTimeLeft = tickTime;
        }
    }
    public void ActiveConstructing()
    {
        constructing = true;
        roadCreating = false;
    }
    public void DesactiveConstructing()
    {
        constructing = false;
    }
    public void ActiveRoadCreating()
    {
        roadCreating = true;
        constructing = false;
    }
    public void ActivateConstructingMenu()
    {
        if (constructing)
        {
            constructing = false;
            building = null;
        }
        UIController.Instance.ActivateMenu(0);
    }


}
