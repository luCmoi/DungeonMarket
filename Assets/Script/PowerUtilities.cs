using UnityEngine;
using System.Collections;

public class PowerUtilities : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public int CalculatePower(PnjBehavior pnj)
    {
        switch (pnj.damage)
        {
            case 1:
            case 2:
                return 1;
            case 3:
                if (pnj.life >= 18)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            case 4:
                if (pnj.life >= 22)
                {
                    return 3;
                }
                else
                {
                    if (pnj.life >= 18)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
        }
        return 1;
    }
}
