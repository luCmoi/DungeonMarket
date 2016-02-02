using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TownsController : MonoBehaviour {
    public TownInfo activeTown;
    public TownInfo[] towns;
    public Text townName;
    public Text townDescription;
    public Text price;
    public Image townImage;
    public Sprite unknown;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Reload()
    {
        activeTown = towns[0];
        if (activeTown.levelAdvertised > -1)
        {
            townImage.sprite = activeTown.image;
            townName.text = activeTown.nameTown;
            townDescription.text = "Level advertised : " + activeTown.levelAdvertised + "\nVisitors : " + activeTown.visitor;
        }else
        {
            townImage.sprite = unknown;
            townName.text = "???????";
            townDescription.text = "????????????????";
        }
        price.text = activeTown.advertiseCost[activeTown.levelAdvertised+1].ToString();
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }
}
