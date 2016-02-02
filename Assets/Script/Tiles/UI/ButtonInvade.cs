using UnityEngine;
using System.Collections;

public class ButtonInvade : MonoBehaviour {
    public UnlockBigTileController container;
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
            container.Invade();
        }
    }
}
