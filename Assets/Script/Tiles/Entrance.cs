using UnityEngine;
using System.Collections;

public class Entrance : MonoBehaviour {
    public bool entranceOpen;
    public int visitorMax = 1;
    public int visitor = 0;
    public GameObject pnj;
    public TilesBehavior initTile;
    public int tick;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        if (GameUtilities.Instance.tick != tick)
        {
            tick = GameUtilities.Instance.tick;
            if (entranceOpen)
            {
                if (visitor < visitorMax)
                {
                    PnjBehavior pnjNew = GameList.Instance.TakeNoob();
                    pnjNew.transform.parent = transform;
                    visitor++;
                    pnjNew.GetComponent<PnjBehavior>().initTile = initTile;
                    GameList.Instance.AddPnj(pnjNew.GetComponent<PnjBehavior>());
                }
            }
        }
    }
}
