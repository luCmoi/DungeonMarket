using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
    public int width;
    public int height;
    public int entranceX;
    public int entranceY;
    public GameObject alerteSignal;
    private GameObject entrance;
    private bool activated;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void fixedUpdate()
    {

    }

    public void setEntrance(GameObject newEntrance)
    {
        if (newEntrance != null)
        {
            activated = true;
            entrance = newEntrance;
            alerteSignal.SetActive(false);
        }
        else
        {
            activated = false;
            entrance = null;
            alerteSignal.SetActive(true);
        }
    }
}
