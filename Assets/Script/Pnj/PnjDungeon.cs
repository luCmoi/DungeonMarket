using UnityEngine;
using System.Collections;

public class PnjDungeon : MonoBehaviour
{
    public PnjBehavior behavior;
    public int quart = 0;
    public int casePos = 0;
// Use this for initialization
void Start () {
        behavior = GetComponent<PnjBehavior>();
	}
	public void Restart()
    {
        quart = 0;
        casePos = 0;
}
	// Update is called once per frame
	void Update () {
	
	}
}
