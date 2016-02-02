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
    public Camera cam;
    public int money;
    public Text textMoney;
    public int research;
    public Text textResearch;
    public Band band;
    public Sprite compass;
    public Entrance entrance;
    public bool ButtonInTick;
    public float buttonTime;
    public float buttonTimeMax;
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
            textMoney.text = money.ToString();
            textResearch.text = research.ToString();
        }
    }
    public void ChangeMoney(int add)
    {
        money = money + add;
        textMoney.text = money.ToString();
    }
    public void ChangeResearch(int add)
    {
        research = research + add;
        textResearch.text = research.ToString();
    }
    // Update is called once per frame
    void Update () {
        if (tickTimeLeft > 0)
        {
            tickTimeLeft -= Time.deltaTime;
        }
        if (buttonTime > 0)
        {
            buttonTime -= Time.deltaTime;
            if (buttonTime <= 0)
            {
                buttonTime = 0;
                ButtonInTick = false;
            }
        }else if (ButtonInTick)
        {
            buttonTime = buttonTimeMax;
        }
    }
    void FixedUpdate()
    {
        if(buttonTime < 0)
        {

        }
        if (tickTimeLeft <= 0)
        {
            tick++;
            tickTimeLeft = tickTime;
            ButtonInTick = false;
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
