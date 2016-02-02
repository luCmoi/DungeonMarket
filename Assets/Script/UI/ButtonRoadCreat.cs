using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonRoadCreat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        if (!GameUtilities.Instance.ButtonInTick)
        {
            GameUtilities.Instance.ButtonInTick = true;
            if (GameUtilities.Instance.roadCreating)
            {
                GameUtilities.Instance.roadCreating = false;
            }
            else
            {
                GameUtilities.Instance.ActiveRoadCreating();
            }
        }
    }
}
