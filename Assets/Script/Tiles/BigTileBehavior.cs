using UnityEngine;
using System.Collections;

public class BigTileBehavior : MonoBehaviour {
    public bool activated;
    public int price;
    public Monster[] monsters;
    public GameObject locker;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        UIController.Instance.OpenUnlock(this);
    }

    public void Activate()
    {
        activated = true;
        foreach (TilesBehavior tiles in GetComponentsInChildren<TilesBehavior>())
        {
            tiles.Activate();
        }
        Destroy(locker);
    }
}
