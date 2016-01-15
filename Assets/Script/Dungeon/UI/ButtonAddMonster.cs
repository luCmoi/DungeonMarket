using UnityEngine;
using System.Collections;

public class ButtonAddMonster : MonoBehaviour {
    public DungeonController controller;
    public int id;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        controller.SelectMonster(id);
    }
}
