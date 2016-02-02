using UnityEngine;
using System.Collections;

public class ButtonAdvertise : MonoBehaviour {
    public TownsController controller;

    public void OnClick()
    {
        if (GameUtilities.Instance.money >= controller.activeTown.GetAdvertiseCost())
        {
            controller.activeTown.Advertise();
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
