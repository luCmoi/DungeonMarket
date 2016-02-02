using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
    public int size;
    public bool init;
    // Use this for initialization
    void FixedUpdate()
    {
        if (!init)
        {
            if (TextUtilities.Instance != null)
            {
                init = true;
                TextUtilities.Instance.SetSize(GetComponent<Text>(), size);
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
