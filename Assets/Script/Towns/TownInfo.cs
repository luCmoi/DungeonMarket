using UnityEngine;
using System.Collections;

public class TownInfo : MonoBehaviour {
    public string nameTown;
    public int[] advertiseCost;
    public int levelAdvertised = -1;
    public LevelUp[] levelUp;
    public Sprite image;
    public int visitor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Advertise()
    {
        levelAdvertised = levelAdvertised + 1;
        if (levelAdvertised == 0)
        {
            GameUtilities.Instance.band.Activate(image, nameTown + " - Advertised", levelUp[levelAdvertised].Activate());
        }
        else
        {
            GameUtilities.Instance.band.Activate(image, nameTown + " - Advertised Up : "+levelAdvertised, levelUp[levelAdvertised].Activate());
        }
        GameUtilities.Instance.ChangeMoney(-advertiseCost[levelAdvertised]);
        UIController.Instance.DesactivateMenu(4);
    }

    public int GetAdvertiseCost()
    {
        return advertiseCost[levelAdvertised+1];
    }
}
