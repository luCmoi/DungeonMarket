using UnityEngine;
using System.Collections;

public class Entrance : MonoBehaviour {
    public TilesBehavior initTile;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void MakeEnter(PnjBehavior pnj)
    {
        pnj.transform.parent = transform;
        pnj.GetComponent<PnjBehavior>().initTile = initTile;
        pnj.GetComponent<PnjBehavior>().container = GetComponent<TilesBehavior>();
        GameList.Instance.AddPnj(pnj.GetComponent<PnjBehavior>());
        pnj.Activate();
    }
}
