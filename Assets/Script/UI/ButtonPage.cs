using UnityEngine;
using System.Collections;

public class ButtonPage : MonoBehaviour {
    public GameObject pageControl;
    public int type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        pageControl.GetComponent<PageControl>().ChangePageType(type);
    }
}
