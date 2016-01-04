using UnityEngine;
using System.Collections;

public class ButtonMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        if (GameUtilities.Instance.interactible)
        {
            GameUtilities.Instance.ActivateMenu();
        }
    }
}
