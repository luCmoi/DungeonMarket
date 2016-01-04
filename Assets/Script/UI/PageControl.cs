using UnityEngine;
using System.Collections;

public class PageControl : MonoBehaviour {
    public GameObject[] pages = new GameObject[3];
    public GameObject pageActive;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangePageType(int type)
    {
        if (pages[type] != pageActive)
        {
            pageActive.SetActive(false);
            pages[type].SetActive(true);
            pageActive = pages[type];
        }
    }
}
